namespace FMS_API.Models
{
    public class OceanShipmentXML
    {
        
        public string Header_Version { get; set; }
        public string Header_SenderId { get; set; }
        public string Master_MblNo { get; set; }
        public string Master_Etd { get; set; }
        public string Master_Eta { get; set; }
        public string Master_VesselName { get; set; }
        public string Master_Voyage { get; set; }
        public string Master_FreightTerm { get; set; }
        public string Master_ShipMode { get; set; }
        //FCL FCL
        //LCL LCL
        //FAK FAK
        //BLK BULK
        public string Master_ServiceTermFrom { get; set; }
        //CY CY
        //CF CFS
        //DR DOOR
        //FT FOT
        //FI FI
        //FO FO
        //TK TACKLE
        //BT BT
        public string Master_ServiceTermTo { get; set; }
        //CY CY
        //CF CFS
        //DR DOOR
        //FT FOT
        //FI FI
        //FO FO
        //TK TACKLE
        //BT BT
        //RM RAMP
        public string Master_WeightUnit { get; set; }
        //KG KG
        //LB LB
        public string Master_MeasureUnit { get; set; }
        //CBM CBM
        //CFT CFT
        public string Carrier_ScacCode { get; set; }
        public string Carrier_Name { get; set; }
        public string BlAcctCarrier_Name { get; set; }
        public string PortOfLoading_Code { get; set; }
        public string PortOfDischarge_Code { get; set; }
        public string PlaceOfDelivery_Code { get; set; }
        public string House_HblNo { get; set; }
        public string House_ServiceTermFrom { get; set; }
        public string House_ServiceTermTo { get; set; }
        public string House_WeightUnit { get; set; }
        public string House_MeasureUnit { get; set; }
        public string House_Shippername { get; set; }
        public string House_Shipperaddress { get; set; }
        public string Consignee_Name { get; set; }
        public string Consignee_Address { get; set; }
        public string Notify_Name { get; set; }
        public string Notify_Address { get; set; }  
        public string Commodity_CommodityDescription { get; set; }
        public string AgentRefNo { get; set; }

    }
}
