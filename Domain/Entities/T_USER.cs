using Microsoft.AspNetCore.Identity;

namespace Domain.Entities
{
    public class T_USER
    {
        public int F_ID { get; set; }
        public string F_UserId { get; set; }
        public string? F_UserPwd { get; set; }
        public string? F_UserName { get; set; }
        public string? F_UserEmail { get; set; }
        public string? F_Phone { get; set; }
        public string? F_FAX { get; set; }
        public int? F_Level { get; set; }
        public string? F_Dept { get; set; }
        public int? F_CompanyId { get; set; }
        public int? F_Status { get; set; }
        public DateTime? F_LastLogin { get; set; }
        public DateTime? F_CreateTime { get; set; }
        public int? F_CreateBy { get; set; }
        public DateTime? F_UpdateTime { get; set; }
        public int? F_UpdateBy { get; set; }        
    }
}
