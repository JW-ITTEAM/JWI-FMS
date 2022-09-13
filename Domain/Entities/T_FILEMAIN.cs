namespace Domain.Entities
{
    public class T_FILEMAIN
    {
        public int F_ID { get; set; }
        public int? F_FILETYPE { get; set; }
        public string? F_TableName { get; set; }
        public int? F_TableId { get; set; }
        public string? F_RefNo { get; set; }
        public string? F_BLNO { get; set; }
        public string? F_FILENAME { get; set; }
        public string? F_FILEPATH { get; set; }
        public int? F_FILESTATUS { get; set; }
        public string? F_APIKEY { get; set; }
        public string? F_JSON { get; set; }
        public int? F_UserId { get; set; }
        public string? F_UserName { get; set; }
        public int? F_CompanyId { get; set; }
        public DateTime? F_UploadTime { get; set; }
        public DateTime? F_DeletedTime { get; set; }
    }
}
