using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace _02.Calculator.Models
{
    public class CalculatorModel
    {
        public string Name { get; set; }
        public double SizeInBytes { get; set; }

        public CalculatorModel()
        {

        }

        public CalculatorModel(string name, double sizeInBytes)
        {
            this.Name = name;
            this.SizeInBytes = sizeInBytes;
        }
    }

}