using FMS_API.Models;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Newtonsoft.Json;
using Newtonsoft.Json.Linq;
using System;
using System.IO;
using System.Net;
using System.Net.Http.Headers;
using System.Text;
using System.Web;
using System.Xml;

namespace FMS_API.Controllers
{

    [ApiController]
    public class FileUploadController : ControllerBase
    {


        [Route("api/FileUpload/OnPostUploadAsync")]
        [HttpPost]
        public async Task<IActionResult> OnPostUploadAsync([FromForm] FileModel files)
        {

            try
            {
                //var file = Request.Form.Files[0];
                var folderName = Path.Combine("Resources", "Test");
                var pathToSave = Path.Combine(Directory.GetCurrentDirectory(), folderName);
                string callresult = "";
                if (!Directory.Exists(pathToSave))
                    Directory.CreateDirectory(pathToSave);

                if (files.UploadFiles[0].Length > 0)
                {
                    var fileName = files.UploadFiles[0].FileName.Trim('"');
                    var fullPath = Path.Combine(pathToSave, fileName);
                    var dbPath = Path.Combine(folderName, fileName);
                    using (var stream = new FileStream(fullPath, FileMode.Create))
                    {
                        files.UploadFiles[0].CopyTo(stream);
                    }

                    var fileReturn = new FileReturnModel();
                    fileReturn.originalFilename = fileName;
                    fileReturn.fileSize = files.UploadFiles[0].Length;
                    fileReturn.fileId = 300001;  // Db context link
                                                 //1. call POWERGEN OCI
                                                 // getToken / process files / get result JSON
                                                 // 

                    string ext = System.IO.Path.GetExtension(fileName);

                    //call POWERGEN ocr API to extract data into JSOn file.

                    if (ext.ToLower().Equals(".pdf"))
                    {

                        CallpowergenOCRAPI(files.UploadFiles[0], fullPath, fileName);

                    }
                    //call GoFreight API to make a Shipment from JSON result file from  POWERGEN OCR
                    else if (ext.ToLower().Equals(".json"))
                    {
                        //2. call GoFreight API

                        fileReturn.fileReturnMsg = CallgofreightAPI(fullPath);
                    }
                    else
                    {
                        return BadRequest();
                        //String isSuccess = ParsingAndSave(filePath);
                        //test
                        //String isSuccess = ParsingRec(filePath);

                    }






                    

                    

                    return Ok(fileReturn);
                }
                else
                {
                    return BadRequest();
                }
            }
            catch (Exception ex)
            {
                return StatusCode(500, $"Internal server error: {ex}");
            }

        }

        //call POWERGEN OCR api to make document JSON
        public static async void CallpowergenOCRAPI(IFormFile postedFiles, string filepath, string fileName)
        {

            //call GENOCR API : getToken
            string returntoken = "";
            var jsonobj = JObject.FromObject(new
            {
                username = "GENO_01",
                password = "genocr123!"
            });
            var url = "http://192.168.10.88/api/v1/get_token";


            HttpClient tokenclient = new HttpClient();
            using (var content1 = new StringContent(JsonConvert.SerializeObject(jsonobj), System.Text.Encoding.UTF8, "application/json"))
            {

                HttpResponseMessage res = tokenclient.PostAsync(url, content1).Result;
                res.EnsureSuccessStatusCode();
                var reContent = res.Content.ReadAsStringAsync();

                var reJson = new JObject();
                if (reContent is not null)
                    reJson = (JObject)JsonConvert.DeserializeObject(reContent.Result.ToString());

                if (reJson != null)
                {
                    returntoken = reJson["token"].ToString();
                    res.Dispose();
                }


            }


            //call GENocr file processing api
            string return_ap_idx = "";
            url = "http://192.168.10.88/api/v1/request_images";
            using var fs = new FileStream(filepath, FileMode.Open, FileAccess.Read);
            //var streamContent = new StreamContent(fs);

            using var sr = new StreamReader(fs, Encoding.UTF8);
            string content = sr.ReadToEnd();

            byte[] bytes = System.IO.File.ReadAllBytes(filepath);

            HttpClient filelient = new HttpClient();
            using (var mfdc = new MultipartFormDataContent())
            {
                mfdc.Add(new StringContent(returntoken), "token");
                mfdc.Add(new StringContent("J235d"), "process_idx");
                mfdc.Add(new StringContent("j235-11"), "instance_idx");
                mfdc.Add(new StringContent("test1"), "ap_description");
                mfdc.Add(new StringContent("N"), "full_text");
                mfdc.Add(new StringContent("N"), "only_img_file");
                mfdc.Add(new ByteArrayContent(bytes, 0, bytes.Length), "files", fileName);
                try
                {
                    var response_ = await filelient.PostAsync(url, mfdc);
                    response_.EnsureSuccessStatusCode();
                    var reContent = response_.Content.ReadAsStringAsync();

                    var reJson = new JObject();
                    if (reContent is not null)
                        reJson = (JObject)JsonConvert.DeserializeObject(reContent.Result.ToString());

                    if (reJson != null)
                    {
                        return_ap_idx = reJson["ap_idx"].ToString();
                        response_.Dispose();
                        fs.Close();
                    }

                }
                catch (Exception ex)
                {

                    Console.WriteLine("FMS-API call GENocr file processing api : " + ex.Message);
                }
            }



            //get Json result
            //test\
            //returntoken = "c5758821e3ab67edb4c69b8e957f6073f59de3c2";
            //return_ap_idx = "4c1eaac2-9689-4565-b541-cd46c507d13a";

            HttpClient jsonresultClient = new HttpClient();
            string endpointurl = "http://192.168.10.88:63779/api/v1/result"; //?token=" + returntoken + "&ap_idx=" + return_ap_idx;
            var builder = new UriBuilder(endpointurl);
            builder.Port = -1;
            var query = HttpUtility.ParseQueryString(builder.Query);
            query["token"] = returntoken;
            query["ap_idx"] = return_ap_idx;
            builder.Query = query.ToString();
            url = builder.ToString();


            jsonresultClient.DefaultRequestHeaders.Add("Accept", "application/json");
            HttpResponseMessage response = jsonresultClient.GetAsync(url).Result;
            response.EnsureSuccessStatusCode();
            var responseContent = response.Content.ReadAsStringAsync().Result;
            if (responseContent != null)
            {
                //file save
                var FileDic = Path.Combine("Resources", "Test");
                var FilePath = Path.Combine(Directory.GetCurrentDirectory(), FileDic);

                if (!Directory.Exists(FilePath))
                    Directory.CreateDirectory(FilePath);

                var jsonfileName = postedFiles.FileName.Replace("pdf", "json");
                jsonfileName = jsonfileName.Replace("PDF", "json");
                var jsonfilePath = System.IO.Path.Combine(FilePath, jsonfileName);


                using (StreamWriter sw = new StreamWriter(jsonfilePath))
                {
                    sw.WriteLine(responseContent);
                };
                //sw.WriteLine(responseContent);
            }
        }

        //call GoFreight  api to make shipment with JSON
        public string CallgofreightAPI(string filepath)
        {
            try
            {
                //OceanShipmentJson osjson = new OceanShipmentJson();
                OceanShipmentXML osxml = new OceanShipmentXML();
                List<OceanShipmentJSON> items = new List<OceanShipmentJSON>();
                List<OceanContainer> oclist = new List<OceanContainer>();

                StreamReader r = new StreamReader(filepath);
                string json = r.ReadToEnd();

                var newjson = JObject.Parse(json).SelectToken("data").ToString();  //get rid of root


                /*
                var jsonReader = new JsonTextReader(new StringReader(newjson))
                {
                    SupportMultipleContent = true // This!!!
                };

                var jsonSerializer = new JsonSerializer();
                while (jsonReader.Read())
                {
                    OceanShipmentJSON item = jsonSerializer.Deserialize<OceanShipmentJSON>(jsonReader);
                    items.Add(item);
                }
                */

                items = JsonConvert.DeserializeObject<List<OceanShipmentJSON>>(newjson);
                if (items.Count > 0)

                {

                    var FileDic = "Resources";
                    var uncodefilePath = Path.Combine(Directory.GetCurrentDirectory(), FileDic);

                    if (!Directory.Exists(uncodefilePath))
                        Directory.CreateDirectory(uncodefilePath);

                    //POrt Code file read
                    //string uncodefilePath = System.IO.Path.Combine(Environment.WebRootPath, "js");
                    string[] lines = System.IO.File.ReadAllLines(uncodefilePath + "\\" + "UNPORT.txt");



                    //load template xmldoc
                    XmlDocument doc = new XmlDocument();
                    doc.Load(uncodefilePath + "\\" + "AgentEDI_JWI.xml");
                    if (doc == null)
                    {

                    }
                    for (int i = 0; i < items.Count; i++)
                    {
                        if (items[i].field_cd.Equals("MASTER_BL_NUMBER"))
                        {
                            osxml.Master_MblNo = items[i].value;
                            doc.SelectSingleNode("//Edi/EdiBody/Mbl/MblNo").InnerText = items[i].value;
                        }
                        if (items[i].field_cd.Equals("HOUSE_BL_NUMBER"))
                        {
                            osxml.Master_MblNo = "TEMPMBL" + items[i].value;
                            osxml.House_HblNo = items[i].value;
                            doc.SelectSingleNode("//Edi/EdiBody/Mbl/MblNo").InnerText = osxml.Master_MblNo;
                            doc.SelectSingleNode("//Edi/EdiBody/Mbl/Hbl/HblNo").InnerText = items[i].value;
                        }
                        if (items[i].field_cd.Equals("CUSTOMER_REF_NO"))
                        {
                            osxml.AgentRefNo = items[i].value;
                            doc.SelectSingleNode("//Edi/EdiBody/Mbl/AgentRefNo").InnerText = items[i].value;
                        }
                        if (items[i].field_cd.Equals("ISSUE_DATE"))
                        {
                            DateTime tempedidate = DateTime.Parse(items[i].value);
                            string edtdate = tempedidate.ToString("yyyy-MM-dd");
                            osxml.Master_Etd = edtdate;
                            osxml.Master_Eta = tempedidate.AddDays(14).ToString("yyyy-MM-dd");

                            doc.SelectSingleNode("//Edi/EdiBody/Mbl/Etd").InnerText = edtdate;
                            doc.SelectSingleNode("//Edi/EdiBody/Mbl/Eta").InnerText = osxml.Master_Eta;
                        }
                        if (items[i].field_cd.Equals("VESSEL"))
                        {
                            string[] svessel = items[i].value.Split(' ');
                            osxml.Master_VesselName = svessel[0];
                            osxml.Master_Voyage = svessel[1].Trim();
                            doc.SelectSingleNode("//Edi/EdiBody/Mbl/VesselName").InnerText = osxml.Master_VesselName;
                            doc.SelectSingleNode("//Edi/EdiBody/Mbl/Voyage").InnerText = osxml.Master_Voyage;
                        }
                        if (items[i].field_cd.Equals("PAID_TYPE"))
                        {
                            if (items[i].value.IndexOf("COLLECT") > 0)
                                osxml.Master_FreightTerm = "C";
                            else
                                osxml.Master_FreightTerm = "P";

                            doc.SelectSingleNode("//Edi/EdiBody/Mbl/FreightTerm").InnerText = osxml.Master_FreightTerm;
                        }

                        if (items[i].field_cd.Equals("GROSS_WEIGHT_UNIT"))
                        {
                            if (items[i].value.Contains("LB"))
                                osxml.Master_WeightUnit = "LB";
                            else
                                osxml.Master_WeightUnit = "KG";

                            doc.SelectSingleNode("//Edi/EdiBody/Mbl/WeightUnit").InnerText = osxml.Master_WeightUnit;
                            doc.SelectSingleNode("//Edi/EdiBody/Mbl/Hbl/WeightUnit").InnerText = osxml.Master_WeightUnit;
                        }
                        if (items[i].field_cd.Equals("MEASUREMENT"))
                        {
                            if (items[i].value.IndexOf("CFT") > 0)
                            {
                                osxml.Master_MeasureUnit = "CFT";
                            }
                            else
                            {
                                osxml.Master_MeasureUnit = "CBM";
                            }
                            doc.SelectSingleNode("//Edi/EdiBody/Mbl/MeasureUnit").InnerText = osxml.Master_MeasureUnit;
                            doc.SelectSingleNode("//Edi/EdiBody/Mbl/Hbl/MeasureUnit").InnerText = osxml.Master_MeasureUnit;
                        }
                        if (items[i].field_cd.Equals("PORT_OF_LOADING"))
                        {
                            string portcode = items[i].value;
                            string smallcaseitemvalue = items[i].value.Replace(".", "").Trim().ToLower();
                            if (smallcaseitemvalue.Contains("states"))
                                smallcaseitemvalue = smallcaseitemvalue.ToLower().Replace("united states", "usa");
                            foreach (string line in lines)
                            {
                                string[] parts = line.Split(',');
                                if (smallcaseitemvalue.Contains(parts[1].Trim().ToLower()) &&
                                    (smallcaseitemvalue.Contains(parts[2].Trim().ToLower()) || smallcaseitemvalue.Contains(parts[3].Trim().ToLower()))
                                   )
                                {
                                    portcode = parts[0];
                                    break;
                                }
                            }
                            osxml.PortOfLoading_Code = portcode;
                            doc.SelectSingleNode("//Edi/EdiBody/Mbl/PortOfLoading/Code").InnerText = portcode;
                            doc.SelectSingleNode("//Edi/EdiBody/Mbl/PlaceOfReceipt/Code").InnerText = portcode;
                        }

                        if (items[i].field_cd.Equals("PORT_OF_DISCHARGE"))
                        {
                            string portcode = items[i].value;
                            string smallcaseitemvalue = items[i].value.Replace(".", "").Trim().ToLower();
                            if (smallcaseitemvalue.Contains("states"))
                                smallcaseitemvalue = smallcaseitemvalue.ToLower().Replace("united states", "usa");
                            foreach (string line in lines)
                            {
                                string[] parts = line.Split(',');
                                //prts0 : port code prts1 : city   parts 2: state or blank  parts3 : country
                                if (smallcaseitemvalue.Contains(parts[1].Trim().ToLower()) &&
                                    (smallcaseitemvalue.Contains(parts[2].Trim().ToLower()) || smallcaseitemvalue.Contains(parts[3].Trim().ToLower()))
                                   )
                                {
                                    portcode = parts[0];
                                    break;
                                }
                            }

                            osxml.PortOfDischarge_Code = portcode;
                            doc.SelectSingleNode("//Edi/EdiBody/Mbl/PortOfDischarge/Code").InnerText = portcode;
                            doc.SelectSingleNode("//Edi/EdiBody/Mbl/PlaceOfDelivery/Code").InnerText = portcode;
                        }
                        if (items[i].field_cd.Equals("SHIPPER"))
                        {   //name
                            string[] shipperstring = items[i].value.Split('\n');
                            osxml.House_Shippername = shipperstring[0];
                            //address
                            string addressstr = "";
                            for (int j = 1; j < shipperstring.Length; j++)
                            {
                                addressstr += shipperstring[j];
                            }
                            osxml.House_Shipperaddress = addressstr;
                            doc.SelectSingleNode("//Edi/EdiBody/Mbl/Hbl/Shipper/Name").InnerText = osxml.House_Shippername;
                            doc.SelectSingleNode("//Edi/EdiBody/Mbl/Hbl/Shipper/LocalAddress").InnerText = addressstr;
                        }

                        if (items[i].field_cd.Equals("CONSIGNEE"))
                        {
                            string[] consigneestring = items[i].value.Split('\n');
                            osxml.Consignee_Name = consigneestring[0];

                            string addressstr = "";
                            for (int j = 1; j < consigneestring.Length; j++)
                            {
                                addressstr += consigneestring[j];
                            }
                            osxml.Consignee_Address = addressstr;
                            doc.SelectSingleNode("//Edi/EdiBody/Mbl/Hbl/Consignee/Name").InnerText = osxml.Consignee_Name;
                            doc.SelectSingleNode("//Edi/EdiBody/Mbl/Hbl/Consignee/LocalAddress").InnerText = addressstr;
                        }

                        if (items[i].field_cd.Equals("NOTIFY_PARTY"))
                        {
                            string[] npstring = items[i].value.Split('\n');
                            osxml.Notify_Name = npstring[0];

                            string addressstr = "";
                            for (int j = 1; j < npstring.Length; j++)
                            {
                                addressstr += npstring[j];
                            }
                            osxml.Notify_Address = addressstr;

                            doc.SelectSingleNode("//Edi/EdiBody/Mbl/Hbl/Notify/Name").InnerText = osxml.Notify_Name;
                            doc.SelectSingleNode("//Edi/EdiBody/Mbl/Hbl/Notify/LocalAddress").InnerText = addressstr;
                        }

                        if (items[i].field_cd.Equals("COMMODITY"))
                        {
                            if (items[i].value.Length <= 128)
                                osxml.Commodity_CommodityDescription = items[i].value;
                            else
                                osxml.Commodity_CommodityDescription = items[i].value.Substring(10, 128);

                            doc.SelectSingleNode("//Edi/EdiBody/Mbl/Hbl/Commodity/CommodityDescription").InnerText = osxml.Commodity_CommodityDescription;
                        }


                        if (items[i].field_cd.Equals("CONTAINER_NO"))
                        {
                            OceanContainer oc = new OceanContainer();
                            oc.ContainerNo = items[i].value;
                            oc.ContainerSize = "40HC";
                            oclist.Add(oc);

                        }

                    } //end for 

                    if (oclist.Count > 0)
                    {
                        OceanContainer[] ocArray = oclist.ToArray();
                        for (int i = 0; i < ocArray.Length; i++)
                        {
                            if (i == 0)
                            {
                                doc.SelectSingleNode("//Edi/EdiBody/Mbl/MblContainer/ContainerNo").InnerText = ocArray[0].ContainerNo;
                                doc.SelectSingleNode("//Edi/EdiBody/Mbl/MblContainer/ContainerSize").InnerText = ocArray[0].ContainerSize ?? "40HC";
                                doc.SelectSingleNode("//Edi/EdiBody/Mbl/Hbl/HblContainer/ContainerNo").InnerText = ocArray[0].ContainerNo;
                            }
                            else
                            {

                                XmlNode mblcontainerNode = doc.CreateElement("MblContainer");
                                XmlNode cnnoNode = doc.CreateElement("ContainerNo");
                                XmlNode cnsizeNode = doc.CreateElement("ContainerSize");
                                XmlNode cnnoHNode = doc.CreateElement("ContainerNo");

                                cnnoNode.InnerText = ocArray[i].ContainerNo;
                                cnnoHNode.InnerText = ocArray[i].ContainerNo;
                                cnsizeNode.InnerText = ocArray[i].ContainerSize ?? "40HC";
                                mblcontainerNode.AppendChild(cnnoNode);
                                mblcontainerNode.AppendChild(cnsizeNode);


                                XmlNode hblcontainerNode = doc.CreateElement("HblContainer");
                                hblcontainerNode.AppendChild(cnnoHNode);

                                XmlNode rootM = doc.SelectSingleNode("//Edi/EdiBody/Mbl");
                                XmlNode rootH = doc.SelectSingleNode("//Edi/EdiBody/Mbl/Hbl");
                                var lastMContainerNode = doc.SelectSingleNode("//Edi/EdiBody/Mbl/MblContainer");
                                rootM.InsertAfter(mblcontainerNode, lastMContainerNode);
                                var lastHContainerNode = doc.SelectSingleNode("//Edi/EdiBody/Mbl/Hbl/HblContainer");
                                rootH.InsertAfter(hblcontainerNode, lastHContainerNode);
                            }

                        }
                    }




                    //file save                    
                    var FileDicrectory = Path.Combine("Resources", "EDIXMLFiles"); 
                    string basePath = System.IO.Path.Combine(Directory.GetCurrentDirectory(), FileDicrectory);
                    if (!Directory.Exists(basePath))
                    {
                        Directory.CreateDirectory(basePath);
                    }
                    var newFileName = string.Format("{0}{1}", items[0].master_doc_nm.Split('.')[0], ".xml");

                    doc.Save(basePath + "\\" + newFileName);



                    //edi test API CAll
                    string url = "https://eval-edi.gofreight.co/edi/ocean-import-shipment/1/xml/";
                    //string url = "https://jwi.gofreight.co/edi/ocean-import-shipment/1/xml/";
                    string AUTHkeystring = new string("EdiAuthToken 10135633e0a122ea7e3f6cddb7aa4646d99516d6");
                    //string AUTHkeystring = new string("EdiAuthToken d2e52b5575732058ab59dedb81bcfc992fe3b801");


                    var request = (HttpWebRequest)WebRequest.Create(url);
                    request.Headers.Add("Authorization", AUTHkeystring);
                    byte[] requestBytes = Encoding.ASCII.GetBytes(doc.InnerXml);
                    request.ContentType = "application/xml";
                    request.ContentLength = requestBytes.Length;
                    request.Method = "POST";



                    Stream requestStream = request.GetRequestStream();
                    requestStream.Write(requestBytes, 0, requestBytes.Length);
                    requestStream.Close();

                    HttpWebResponse response;
                    try
                    {
                        response = (HttpWebResponse)request.GetResponse();
                        XmlDocument xmlResultDoc = new XmlDocument();
                        xmlResultDoc.Load(response.GetResponseStream());
                        if (xmlResultDoc.SelectSingleNode("//EdiResponse/Result").InnerText == "SUCCESS")
                        {
                           return "EDI File uploaded successfully";
                        }
                        else
                        {
                            return xmlResultDoc.SelectSingleNode("//EdiResponse/Detail/Error/Description").InnerText;
                        }
                    }
                    catch (WebException ex)
                    {
                        response = (HttpWebResponse)ex.Response;
                        Console.WriteLine(ex.Message);
                        Console.WriteLine(response.GetResponseStream().ToString());
                        return response.GetResponseStream().ToString();
                    }
                }
                else
                    return "Error  : no JSON file extracted.";
            }
            catch (Exception ex)
            {
                return "Error ex.message : " + ex.Message;
            }
        }
    }
}
