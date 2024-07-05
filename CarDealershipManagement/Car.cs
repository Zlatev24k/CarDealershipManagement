using System;
using System.Collections.Generic;
using System.Linq;
using System.Management.Instrumentation;
using System.Text;
using System.Threading.Tasks;

namespace CarDealershipManagement
{
    internal class Car
    {
        public string CarID {  get;private set; }
        public string Brand {  get;private set; }
        public string Model {  get;private set; }
        public int Year { get;private set; }
        public double Price { get;private set; }
        public bool Available { get;private set; }
    }
}
