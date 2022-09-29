using FMS_API.Models;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Newtonsoft.Json;
using Newtonsoft.Json.Linq;
using System;
using System.IO;
using System.Net.Http.Headers;
using System.Text;
using System.Web;

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

                        CallgofreightAPI(fullPath);
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
        public static async void CallgofreightAPI(string filepath)
        {

        }
    }
}
