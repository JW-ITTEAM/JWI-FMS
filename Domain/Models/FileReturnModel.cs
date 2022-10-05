namespace Domain.Models
{
    public class FileReturnModel
    {
        public int fileId { get; set; }
        public string originalFilename { get; set; }
        public string fileExtension { get; set; }
        public float fileSize { get; set; }
        public string fileReturnMsg { get; set; }


    }
}
