using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;

namespace ImpotrsFiles.Models
{
    public class Employed
    {
        [Key]
        public int Emp_Id { get; set; }
        public int Emp_name { get; set; }
        public int Emp_Age { get; set; }
        public int Emp_Salary { get; set; }

    }
}