using System;

namespace mis.Items
{
    public class Patient
    {
        public Guid Id { get; set; }
        public string Name { get; set; }
        public string Sex { get; set; }
        public DateTime Birth { get; set; }       
        public int InsuranceID { get; set; }
        public int Phone { get; set; }
        public string Address { get; set; }
        public int SnilsID { get; set; }
    }
}
