import axios from "axios";
import { useState, useEffect } from 'react';
import {ApiResponse, FileItem } from "../../components/fileResponse";
import { Form, Dropdown, ButtonGroup } from 'react-bootstrap';
//test EYJ
import classNames from 'classnames'


export interface IFileUploadForm {}

export default function FileUploadForm({fileItems, setFileItems} : {fileItems:Array<FileItem>, 
                                        setFileItems: React.Dispatch<React.SetStateAction<FileItem[]>>}) {

  
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
  const ALLOW_FILE_EXTENSION = "pdf,docx, jpg,png";
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

    // validation을 정상적으로 통과한 File
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

    /**
     * 허용가능한 확장자가 있는지 확인하는 부분은 indexOf를 사용해도 괜찮고, 
     * 새롭게 나온 includes를 사용해도 괜찮고, 그밖의 다른 방법을 사용해도 좋다.
     * 성능과 취향의 따라 사용하면 될것같다.
     * 
     * indexOf의 경우
     * 허용가능한 확장자가 있을경우 
     * ALLOW_FILE_EXTENSION 상수의 해당 확장자 첫 index 위치값을 반환
     */
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
    // 마지막 .의 위치를 구한다
    // 마지막 .의 위치다음이 파일 확장자를 의미한다
    const lastIndex = originalFileName.lastIndexOf(".");

    // 파일 이름에서 .이 존재하지 않는 경우이다.
    // 이경우 파일 확장자가 존재하지 않는경우(?)를 의미한다.
    if(lastIndex < 0) {
      return "";
    }

    // substring을 함수를 이용해 확장자만 잘라준다
    // lastIndex의 값은 마지막 .의 위치이기 때문에 해당 위치 다음부터 끝까지 문자열을 잘라준다.
    // 문자열을 자른 후 소문자로 변경시켜 확장자 값을 반환 해준다.
    return originalFileName.substring(lastIndex+1).toLocaleLowerCase();
  }
  
  return (      
      <div className="row">
          <Form.Group>
            <h4>File upload</h4>

            <div className="row">
              <label className="col-sm-8 col-form-label">Choose only 1 file</label>
              <select onChange={selectChange}>
                <option selected disabled>
                  Choose one
                </option>
                <option value="master">Master B/L</option>
                <option value="house">House B/L</option>
              </select>             
            </div>
            <div className="row">
              <input type="file" onChange={fileUploadValidHandler}/>
      <br/>
      <button onClick={fileUploadHandler}>Submit</button>
            </div>           
          </Form.Group>
      </div> 
  )
}