//------------------------------------------------------------------------------
// <auto-generated>
//    This code was generated from a template.
//
//    Manual changes to this file may cause unexpected behavior in your application.
//    Manual changes to this file will be overwritten if the code is regenerated.
// </auto-generated>
//------------------------------------------------------------------------------

namespace Aspcrud.Models
{
    using System;
    using System.Collections.Generic;
  using System.ComponentModel;

  public partial class article
    {
        public short id { get; set; }
        public string category { get; set; }
        public string description { get; set; }
        public string source { get; set; }
        public System.DateTime timer { get; set; }
        public Nullable<int> vote { get; set; }
        public string Title { get; set; }
        [DisplayName("Image URL")]
        public string imageurl { get; set; }
        public long userid { get; set; }
    
        public virtual member member { get; set; }
    }
}
