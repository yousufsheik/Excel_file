using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;

namespace ImpotrsFiles.Models
{
    public class User
    {
        [Key]
        public int User_Id { get; set; }
        public string User_name { get; set; }
        public int User_Age { get; set; }



    }
}