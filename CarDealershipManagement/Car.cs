using System;
using System.Collections.Generic;
using System.Linq;
using System.Management.Instrumentation;
using System.Text;
using System.Threading.Tasks;

namespace CarDealershipManagement
{
    public class Car
    {
        private int year;
        private double price;
        private bool availableCar;
        public string CarID {  get;private set; }
        public string Brand {  get;private set; }
        public string Model {  get;private set; }

        public int Year
        {
            get
            {
                return year;
            }
            private set
            {
                if (year != value) 
                {
                    throw new ArgumentException("Годината на производствдо да е по назад от сегашната година");
                }
                year = value;
            }
        }
        
    }
}
