using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace jooledotnet.Models
{
    public class Product
    {
        public int ProductID { get; set; }
        public string Menufacture { get; set; }
        public string Category { get; set; }
        public string Description { get; set; }
        public string Series { get; set; }
        public string Model { get; set; }
        public double Price { get; set; }
        public DateTime DateMenufactured { get; set; }


        
       
       
    }
}