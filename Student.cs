//------------------------------------------------------------------------------
// <auto-generated>
//     This code was generated from a template.
//
//     Manual changes to this file may cause unexpected behavior in your application.
//     Manual changes to this file will be overwritten if the code is regenerated.
// </auto-generated>
//------------------------------------------------------------------------------

namespace Login
{
    using System;
    using System.Collections.Generic;
    
    public partial class Student
    {
        public int roll_no { get; set; }
        public string name { get; set; }
        public Nullable<int> teacher_id { get; set; }
    
        public virtual Teacher Teacher { get; set; }
    }
}
