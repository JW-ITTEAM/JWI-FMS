import axios from "axios";
import { useState, useEffect } from 'react';
import {ApiResponse, FileItem } from "../../components/fileResponse";
import { Form, Dropdown, ButtonGroup } from 'react-bootstrap';
import { useHistory } from "react-router-dom";



export interface IFileUploadForm {}

export default function FileUploadForm({fileItems, setFileItems} : {fileItems:Array<FileItem>, 
                                        setFileItems: React.Dispatch<React.SetStateAction<FileItem[]>>}) {

  //
  const history = useHistory();
  // state for uploading files
  const [file, setFile] = useState<File>(); 
  const [refNo, setRefNo] = useState({refNo : 'oim-12345'});  
    
  const [fileSelect, setfileSelect] = useState<string>();  
  // This function is triggered when the select changes
 
  const selectChange = (event: React.ChangeEvent<HTMLSelectElement>) => {
    const value = event.target.value;
    setfileSelect(value);
  }; 
   
  // available file extension and file size
  const ALLOW_FILE_EXTENSION = "pdf, docx, jpg, png, json, xml";
  const FILE_SIZE_MAX_LIMIT = 5 * 1024 * 1024;  // 5MB
   
  /**
   * when file  is selected :  onChangeHandler
   * file validation : file extension and size
   * assign file state : file state에 값을 할당.
   * @param e 
   * @returns 
   */
  const fileUploadValidHandler = (e:any) => {
    const target = e.currentTarget;
    const files = (target.files as FileList)[0];

    if(files === undefined) {
      return ;
    }

    // file extension check
    if(!fileExtensionValid(files)) {
      target.value = '';
      alert(`This file is not allowd to upload [avaiable extension : ${ALLOW_FILE_EXTENSION}]`)
      return;
    }

    // file size check
    if(files.size > FILE_SIZE_MAX_LIMIT) {
      target.value = '';
      alert('Maximum file size is 5MB.')
      return;
    }

    // validated File
    setFile(files);
  }


  /**
   * file upload button clickHandler
   * call Backend API and then upload this file to server(backend) and get the result status.
   */
  const fileUploadHandler = async () => {

    if(file !== undefined) {
      try{
        // !!Important :  input data from form using "FormData"
        const formData = new FormData();
        //test 
        formData.append("userId", "3EYJ3");
        formData.append("FileName", file.name);
        //formData.append("FileSelect", "master");
        formData.append("UploadFiles", file);
        formData.append("FileSelect", fileSelect || '');
        //formData.append("fileType", 'nnonononoononono' );
        // console.log("file name is " + file.name);
        // using Axios to upload files into the backend Server
        // !!important : "header :  content-type =  multipart/form-data"

        console.log(formData);
        
        const response = await axios.post
                                (
                                  "https://localhost:7077/api/FileUpload/OnPostUploadAsync", 
                                  formData, 
                                  {headers : {
                                    "Content-Type" : "multipart/form-data"
                                  }},
                                );
        
       /*
        const response = await axios({
          method: "POST",
          url: "https://localhost:7077/api/FileUpload/OnPostUploadAsync",
          data: formData,
          headers : {"content-type" : "multipart/form-data"},
          transformRequest: (data, error) => {
              return formData;
          }
         }); */

        // File upload success!
        alert('Upload Success!!!!');
        //alert('Upload Success!!!!' +response.data.data );
        const res:FileItem = response.data.data;
        setFileItems([...fileItems, {...res}]);
      } catch(e) {
        console.error(e);
        alert((e as {message : string}).message);
      }
    }
  }

  // ----------------------------------------------------------------

  /**
   * function for checking file extension.
   * @param param
   * @returns true: avaiable extension, false : unavaiable 
   */
  const fileExtensionValid = ({name} : {name : string}):boolean =>{
    // file extension
    const extension = removeFileName(name);

    if(!(ALLOW_FILE_EXTENSION.indexOf(extension) > -1) || extension === '') {
      return false;
    }
    return true;
  }

  /**
   * return only file extension.
   * @param originalFileName upload file name
   * @returns  only extension right after   "."
   */
  const removeFileName = (originalFileName:string):string => {
    // file extension after .
    const lastIndex = originalFileName.lastIndexOf(".");

    // in case file name doesn't have "."
    if(lastIndex < 0) {
      return "";
    }

    return originalFileName.substring(lastIndex+1).toLocaleLowerCase();
  }
  
  return (      
      <div className="row">
          <Form.Group>
          <div className="row">
              <div className="form-group row">
                <div className="card-body">
                    <h3 className="card-title">File Upload</h3>              
                    <div className="form-group row" style={{ fontSize: "0.8em" }} >
                        <p className="card-description col-sm-3">File type</p>                      
                        <select  style={{ marginBottom: "1.0em" }}  className="col-md-6 shadow" onChange={selectChange}>
                          <option  selected disabled>
                            Choose one
                          </option>
                          <option  value="master">Master B/L</option>
                          <option  value="house">House B/L</option>
                        </select>
                    </div>
                    <div className="form-group row" style={{ fontSize: "0.8em" }} >
                        <p className="card-description col-sm-3">File</p>
                        <input className="col-md-9"  style={{ padding : "0rem 0rem" }}  type="file" onChange={fileUploadValidHandler}/>
                    </div>
                    <button className="btn btn-primary me-2" onClick={fileUploadHandler}>Submit</button>                    
                </div>  
            </div>
            </div>
          </Form.Group>
      </div> 
  )
}