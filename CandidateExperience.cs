//------------------------------------------------------------------------------
// <auto-generated>
//     This code was generated from a template.
//
//     Manual changes to this file may cause unexpected behavior in your application.
//     Manual changes to this file will be overwritten if the code is regenerated.
// </auto-generated>
//------------------------------------------------------------------------------

namespace JobShop
{
    using System;
    using System.Collections.Generic;
    
    public partial class CandidateExperience
    {
        public int IdExp { get; set; }
        public Nullable<int> Id_CV { get; set; }
        public string Description { get; set; }
        public Nullable<System.DateTime> DateStart { get; set; }
        public Nullable<System.DateTime> DateEnd { get; set; }
    
        public virtual Candidates Candidates { get; set; }
    }
}