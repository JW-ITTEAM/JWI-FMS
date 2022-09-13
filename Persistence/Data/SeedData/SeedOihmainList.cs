using Domain.Entities;

namespace Persistence.Data.SeedData
{
    public class SeedOihmainList
    {
        public List<T_OIHMAIN> get_OIHMAIN_Seed()
        {
            return new List<T_OIHMAIN>()
            {
                new T_OIHMAIN
                {
                    F_OIMMAINID = 1,
                    F_HBLNo = "PI TW NYC 050439",
                    F_Customer = 128,
                    F_Shipper = 127,
                    F_SName = "VINH PHU GARMENT CO., LTD.\nNO. 84/7 BLOCK3, TAN THOI NHAT WARD.\nDISTRICT 12\nHOCHIMINH  VIETNAM",
                    F_Consignee = 128,
                    F_CName = "SEP PLUS, INC.\n1400 BROADWAY SUITE 913\nNEW YORK, NY 10018\nTEL :212-819-1286/7 FAX :212-819-1718",
                    F_Notify = 52,
                    F_NName = "SAME AS ABOVE",
                    F_Broker = 129,
                    F_BName = "EXCEL INT'L\nNEW YORK CORP.\n146-27 167TH ST.\nJAMAICA, NY 11434",
                    //F_BTel
                    //F_BFax
                    //F_BEmail
                    //F_BContact,
                    F_CustRefNo = "",
                    F_Commodity = "",
                    F_HSCODE = null,
                    F_TotalContainer = null,
                    F_MarkPkg = "13 CTNS",
                    F_Description = "WOMEN WOVEN SUIT- 429 SETS\n\nCNTR NO. : WHLU5330984\n\nFREIGHT COLLECT",
                    F_MarkGross = "369.95 KGS\n815.59 LBS",
                    F_MarkMeasure = "1.900 CBM\n67 CFT",
                    ////F_PKGS = 13,
                    ////F_Punit = "CTNS",
                    ////F_CBM = 1.9f,
                    //F_DevanCBM
                    ////F_KGS = 369.95f,
                    //F_DevanKGS
                    ////F_LBS = 815.59f,
                    //F_DevanLBS
                    //F_OBLCol
                    //F_OBLDate
                    F_ExpRLS = "0",
                    //F_RLSDate,
                    //F_ReleaseBy
                    F_CFSLocation = 141,
                    //F_FCode = 1,
                    //F_FinalDest = "NEW YORK, NY",
                    F_FETA = new DateTime(2022,7,20, 0,0,0),
                    //F_ITClass = "",
                    F_PickupDate = null,
                    //F_ITCarrier = 0,
                    //F_ITNo = "816225270",
                    //F_ITPlace = "LONG BEACH, CA",
                    //F_ITDate = new DateTime(2022,5,2,0,0,0),
                    F_DcodeCustom = "2704",
                    F_FcodeCustom = "1001",
                    F_ForeignDest = "",
                    F_PPCC = "",
                    ////F_SManID = "",
                    F_Mark = "LCL/LCL\nCONT/SEAL NO.\n\nSHIPPING MARK\nSEPPLUS\nSTYLE # 02-1209-2\nCOLOR # DEEP ORANGE\nSIZE:\nQ'TY:35 SETS\nCARTON# OF\nMADE IN VIETNAM",
                    //F_GODate
                    //F_LastFreeday
                    F_FileClosed = "3",
                    F_ClosedBy = "",
                    //F_OtherDescript
                    //F_Operator = "LAURA",
                    //F_SelectContainer
                    F_MoveType = "CFS/CFS",
                    F_Nomi = "N",
                    ////F_IMemo = "",
                    ////F_PMemo = "LOAD-STOP # 36577-1.5",
                    F_DefaultRate = 1,
                    //F_U1ID
                    //F_U1Date
                    //F_U2ID
                    //F_U2Date
                    //X_PAID
                    //X_PCHKNO
                    //X_PAIDDATE
                    //F_MultiNameID
                    //F_SubMblSurFix
                    F_INVOICETO = 128,
                    ////F_DoorMove = "0",
                    //F_AvialDate
                    //F_PrevITno
                    //F_PrevITClass
                    //F_PrevITDate
                    //F_PrevItPort
                    //F_ClearPort
                    //F_ClearDate
                    //F_AmsStatus
                    //F_AmsDate
                    //F_HTSNO
                    //F_AMSLinkUserID
                    //F_AMSLinkID
                    //F_AMSLinkDate
                    //F_CfmCharge
                    F_AMSBLNO = "ACLPAMCU8488898",
                    F_ISFNO = "ISFNO TEMP DATA",
                    F_Memo = "MEMO TEMP DATA",
                    //F_TruckLoadNo
                    //F_ReceiptPlace
                    //F_Complete
                    //F_InvoiceYN
                    //F_CustomStatus
                    //F_ROR
                    //F_DoorDIvLocation
                    //F_DoorDIvETA
                    //F_ForignETA
                    //F_FDARlsDate
                    //F_FDAHold
                    //F_PODRcvd
                    //F_ITDestination
                    //F_ISFNO
                    //F_APYN
                    //F_APVendor
                    //F_InvoiceTransmit
                    //F_ProjectNo
                    //F_SONo
                    //F_PimsLinkUserID
                    //F_PimsLinkID
                    //F_PimsLinkDate
                    //F_IncoTerms
                    //F_PIMSPOID
                    //F_SHIPMENTID
                    //F_NOTICEDATE
                    //F_EHBLNO
                },
            };
        }
    }
}
