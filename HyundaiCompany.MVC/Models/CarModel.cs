using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace HyundaiCompany.MVC.Models
{
    public class CarModel
    {
        public int ID { get; set; }
        public string CarName { get; set; }
        public string Price { get; set; }
        public string Model { get; set; }
        public string Colour { get; set; }
    }
}