//------------------------------------------------------------------------------
// <auto-generated>
//     This code was generated from a template.
//
//     Manual changes to this file may cause unexpected behavior in your application.
//     Manual changes to this file will be overwritten if the code is regenerated.
// </auto-generated>
//------------------------------------------------------------------------------

namespace PoshakBioSciences.DbModel
{
    using System;
    using System.Collections.Generic;
    
    public partial class M_ProductMaster
    {
        public int ProductId { get; set; }
        public string ProductName { get; set; }
        public string ProductSubTitle { get; set; }
        public string ProdDescription { get; set; }
        public string KeyFeatures { get; set; }
        public string Composition { get; set; }
        public string ProdApplication { get; set; }
        public string ProdPresentation { get; set; }
        public string ImgPath1 { get; set; }
        public string ImgPath2 { get; set; }
        public string ImgPath3 { get; set; }
        public string CreatedBy { get; set; }
        public System.DateTime CreatedDate { get; set; }
        public string ModifiedBy { get; set; }
        public System.DateTime ModifiedDate { get; set; }
        public bool Active { get; set; }
    }
}
