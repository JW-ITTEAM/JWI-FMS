namespace Domain.Models
{
    public class VM_USER
    {
        public string? F_UserName { get; set; }
        public string? F_UserEmail { get; set; }
        public string? F_Phone { get; set; }
        public string? F_FAX { get; set; }
        public bool F_EmailVerified { get; set; } = false;
    }
}
