//------------------------------------------------------------------------------
// <auto-generated>
//     This code was generated from a template.
//
//     Manual changes to this file may cause unexpected behavior in your application.
//     Manual changes to this file will be overwritten if the code is regenerated.
// </auto-generated>
//------------------------------------------------------------------------------

namespace CrudRiosoft.Models
{
    using System;
    using System.Collections.Generic;
    
    public partial class TELEFONE
    {
        public int CLI_COD { get; set; }
        public string DDD { get; set; }
        public string NUMERO { get; set; }
    
        public virtual CLIENTE CLIENTE { get; set; }
    }
}
