using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace Ajax_First_pro.Models
{
    public class ModelLayar
    {
        public int ID { get; set; }
        public string Name { get; set; }
        public double Salary { get; set; }
        public string DOB { get; set; }
        public string Email { get; set; }
        public string Address { get; set; }
        public string Gender { get; set; }
        public string Qualification { get; set; }

    }
    public class Keyval
    {
        public string key { get; set; }
        public string value { get; set; }
    }
}