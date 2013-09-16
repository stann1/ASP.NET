using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace _01.CarsPlatform
{
    public class Manufacturer
    {
        public string Name { get; set; }
        public List<string> Models { get; set; }

        public Manufacturer()
        {
            this.Models = new List<string>();
        }
    }
}