namespace Domain.Models
{
    public class OceanShipmentJSON
    {
        public string pro_doc_idx { get; set; }
        public string master_doc_nm { get; set; }
        public string src_doc_no { get; set; }
        public int page_no { get; set; }
        public string field_cd { get; set; }
        public string field_nm { get; set; }
        public int value_row { get; set; }
        public string value { get; set; }
        public string confirm_value { get; set; }
        public string second_value { get; set; }
        public float confidence { get; set; }

    }
}
