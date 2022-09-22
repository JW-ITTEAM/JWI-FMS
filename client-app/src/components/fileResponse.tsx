/**
 * Common response type
 */
 export interface ApiResponse<T> {
    resultCode:number;
    message:string;
    data:T;
    timestamp:number;
    error?:ErrorSet;
  }
  
  /**
   *  ErrorSet
   */
 export  interface ErrorSet {
    errorCode : string;
    errorMessage : string;
    alertMessage? : string;
  }
  
export interface FileItem {
    idx:number;
    originalFilename:string;
    fileExtension:string;
    fileSize:number;
    refNo:string;
    fileType:string;
  }
