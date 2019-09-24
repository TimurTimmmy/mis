using mis.MKB;
using System;
using System.Collections.Generic;

namespace mis.Items
{
    public class VisitDetails
    {
        //public Guid VisitDetailsId { get; set; }
        //public Guid VisitId { get; set; }
        public int VisitPurpose { get; set; }
        public int VisitCase { get; set; }
        public int VisitCharacter { get; set; }
        public Mkb VisitMkb { get; set;  }
        //public string VisitComment { get; set; }
        public string VisitСomplaints { get; set; }
        public string VisitСheckup { get; set; }
        public string VisitDiagnosis { get; set; }
        public string VisitСonclusion { get; set; }
        public string VisitTreatment { get; set; }
    }
}
