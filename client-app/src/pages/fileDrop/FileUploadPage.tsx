import FileUploadForm from './FileUploadForm';
import { useState } from 'react';
import {ApiResponse, FileItem } from "../../components/fileResponse"

export default function FileUploadPage() {
  const [fileItems, setFileItems] = useState<Array<FileItem>>([]);
  return (
    <div>
      <div>

      </div>
      <div>
        <FileUploadForm fileItems = {fileItems} setFileItems={setFileItems}/>
      </div>
      <label>{ fileItems[0]?.refNo??"" } </label>
    </div>
  );
}

