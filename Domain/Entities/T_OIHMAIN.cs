namespace Domain.Entities
{
    public class T_OIHMAIN
    {
        public int F_ID { get; set; }
        public int? F_OIMMAINID { get; set; }
        public string F_HBLNo { get; set; }
        public int? F_Customer { get; set; }
        public int? F_Shipper { get; set; }
        public string? F_SName { get; set; }
        public int? F_Consignee { get; set; }
        public string? F_CName { get; set; }
        public int? F_Notify { get; set; }
        public string? F_NName { get; set; }
        public int? F_Broker { get; set; }
        public string? F_BName { get; set; }
        public string? F_CustRefNo { get; set; }
        public string? F_Commodity { get; set; }
        public string? F_HSCODE { get; set; }
        public int? F_TotalContainer { get; set; }
        public string? F_MarkPkg { get; set; }
        public string? F_Description { get; set; }
        public string? F_MarkGross { get; set; }
        public string? F_MarkMeasure { get; set; }
        public string? F_ExpRLS { get; set; }
        public int? F_CFSLocation { get; set; } // pickup place
        public int? F_CYLocation { get; set; }
        //public int? F_FCode { get; set; }
        //public string? F_FinalDest { get; set; }
        public DateTime? F_FETA { get; set; }
        //public string? F_ITClass { get; set; }
        public DateTime? F_PickupDate { get; set; }
        //public int? F_ITCarrier { get; set; }
        //public string? F_ITNo { get; set; }
        //public string? F_ITPlace { get; set; }
        //public DateTime? F_ITDate { get; set; }
        public string? F_DcodeCustom { get; set; }
        public string? F_FcodeCustom { get; set; }
        public string? F_ForeignDest { get; set; }
        public string? F_PPCC { get; set; }
        //public string? F_PaidPlace { get; set; }
        public string? F_Mark { get; set; }
        public string? F_FileClosed { get; set; }
        public string? F_ClosedBy { get; set; }
        //public string? F_Operator { get; set; }
        public string? F_MoveType { get; set; }
        public string? F_Nomi { get; set; }
        public float? F_DefaultRate { get; set; }
        public int? F_INVOICETO { get; set; }
        public string? F_AMSBLNO { get; set; }
        public string? F_ISFNO { get; set; }
        public string? F_Memo { get; set; }
    }
}
