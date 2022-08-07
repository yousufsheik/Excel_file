using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Linq;
using System.Web;

namespace ImpotrsFiles.Models
{
    public class ContextClass:DbContext
    {
        public ContextClass():base("Con")
        {

        }
        public DbSet<User> Users { get; set; }
        public DbSet<Employed> Employeds { get; set; }  
    }
}