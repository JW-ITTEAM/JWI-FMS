using Microsoft.AspNetCore.Http;

namespace FMS_API.Models
{
    public class FileModel
    {
        public string userId { get; set; }
        public string FileName { get; set; }
        public string FileSelect { get; set; }
        public IFormFile[] UploadFiles { get; set; }
    }
}
