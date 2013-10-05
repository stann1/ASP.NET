using _02.Calculator.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace _02.Calculator.Controllers
{    
    public class HomeController : Controller
    {
        private List<CalculatorModel> values;

        public HomeController()
        {
            this.values = new List<CalculatorModel>()
            {
                new CalculatorModel("bit", 0.125),
                new CalculatorModel("byte", Math.Pow(1024, 0)),
                new CalculatorModel("kilobyte", Math.Pow(1024, 1)),
                new CalculatorModel("megabyte", Math.Pow(1024, 2)),
                new CalculatorModel("gigabyte", Math.Pow(1024, 3)),
                new CalculatorModel("terabyte", Math.Pow(1024, 4)),
                new CalculatorModel("petabyte", Math.Pow(1024, 5)),
                new CalculatorModel("exabyte", Math.Pow(1024, 6))
            };
        }

        [HttpGet]
        public ActionResult Index()
        {
            List<CalculatorModel> dataValues = this.values;
            
            return View(dataValues);
        }

        [HttpPost]
        public ActionResult Index(string inputQuantity, string inputType)
        {
            int quantity =  int.Parse(inputQuantity);
            double byteVal = double.Parse(inputType);

            List<CalculatorModel> results = new List<CalculatorModel>();
            for (int i = 0; i < this.values.Count; i++)
            {
                CalculatorModel item = new CalculatorModel()
                {
                    Name = this.values[i].Name,
                    SizeInBytes = quantity * (byteVal / this.values[i].SizeInBytes) 
                };
                results.Add(item);
            }
           
            ViewBag.Results = results;

            return View(this.values);
        }

        public ActionResult About()
        {
            ViewBag.Message = "Your application description page.";

            return View();
        }

        public ActionResult Contact()
        {
            ViewBag.Message = "Your contact page.";

            return View();
        }
    }
}