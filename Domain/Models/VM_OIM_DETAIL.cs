namespace Domain.Models
{
    public class VM_OIM_DETAIL
    {
        // Master
        public string F_RefNo { get; set; }
        public string? F_MBLNo { get; set; }
        public string? F_M_SName { get; set; }
        public string? F_M_CName { get; set; }
        public string? F_M_NName { get; set; }
        public string? F_CarrierName { get; set; }
        public DateTime? F_M_PostDate { get; set; } // Issue Date

        // House
        public string? F_HBLNo { get; set; }
        public int? F_Customer { get; set; } // No Customer Name
        public string? F_CustRefNo { get; set; }
        public string? F_H_SName { get; set; }
        public string? F_H_CName { get; set; }
        public string? F_H_NName { get; set; }
        public DateTime? F_H_PostDate { get; set; } // Issue Date

        // Shipping
        public string? F_Vessel { get; set; }
        public string? F_BookingNo { get; set; } // OXMMAIN 전용
        public string? F_Voyage { get; set; }
        public string? F_LoadingPort { get; set; }
        public DateTime? F_ETD { get; set; }
        public string? F_DisCharge { get; set; }
        public DateTime? F_ETA { get; set; }
        public string? F_FinalDelivery { get; set; }
        public DateTime? F_FETA { get; set; }
        public string? F_MoveType { get; set; }
        public int? F_CYLocation { get; set; }
        public int? F_CFSLocation { get; set; }
        public string? F_PaidPlace { get; set; } // receipt of place

        // RAIL
        public string? F_ITNo { get; set; }
        public string? F_ITPlace { get; set; }
        public DateTime? F_ITDate { get; set; }

        public string? F_LCLFCL { get; set; }
        public string? F_Nomi { get; set; }
        public string? F_AMSBLNO { get; set; }
        public string? F_ISFNO { get; set; }
        public string? F_ExpRLS { get; set; }

        // CONTAINERS
        public ICollection<VM_CONTAINER>? VM_CONTAINERS { get; set; }
    }
}
