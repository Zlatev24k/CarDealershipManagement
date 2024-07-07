﻿using System;
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
        private decimal price;
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
        public bool AvailableCar
        {
            get
            {                       
                 return availableCar;              
            }
            private set
            {
                if (value  )
                {
                    throw new ArgumentException("Наличните коли трябва да са положителни!");
                }
                availableCar = value;
            }
        }
        public decimal Price
        {
            get
            {
                return price;
            }
            private set
            {
                if (value <= 0)
                {
                    throw new ArgumentException("Цената на колата трябва да е положително число!");
                }
                price = value;
            }
        }

        public Car(int year, decimal price, bool availableCar, string carID, string brand, string model)
        {
            Year = year;
            Price = price;
            AvailableCar = availableCar;
            CarID = carID;
            Brand = brand;
            Model = model;
        }
        public override string ToString() 
        { 
            return $"{CarID},{Brand},{Model},{Year},{AvailableCar},{Price}";
        }
        
    }
}
