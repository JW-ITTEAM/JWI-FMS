namespace Domain.Models
{
    public class VM_OIM
    {
        public string F_RMH_ID {
            get
            {
                return (F_RefNo) + "#" + (F_MBLNo ?? "") + "#" + (F_HBLNo ?? "");
            }
        }
        public string F_RefNo { get; set; }
        public string? F_MBLNo { get; set; }
        public string? F_HBLNo { get; set; }
        public string? F_LoadingPort { get; set; }
        public DateTime? F_ETA { get; set; }
        public DateTime? F_ETD { get; set; }
    }
}
