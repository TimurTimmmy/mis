using System;

namespace mis.Items
{
    public class Visit
    {
        public Guid Id { get; set; }
        public Patient Patient { get; set; }
        public DateTime VisitDate { get; set; }
        public Doctor Doc { get; set; }
        public Guid GuidDoc { get; set; }
        public VisitDetails VisitDetails { get; set; }
    }
}