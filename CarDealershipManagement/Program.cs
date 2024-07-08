using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Runtime.ConstrainedExecution;
using System.Text;
using System.Threading.Tasks;

namespace CarDealershipManagement
{
    public class Program
    {
        private const string filePath = "../../../Car.txt";
        private static List<Car> cars = new List<Car>();
        private static string menuActionChoice;
        static void Main(string[] args)
        {
            Console.InputEncoding = Encoding.Unicode;
            Console.OutputEncoding = Encoding.Unicode;

            PrintMenu();

            LoadCars();

            while (true)
            {
                menuActionChoice = Console.ReadLine();
                switch (menuActionChoice)
                {
                    case "1":
                        ShowActionTitle("Добавяне на нов автомобил");
                        AddNewCar();
                        break;
                    case "2":
                        BuyCar();
                        break;
                    case "3":
                        ShowActionTitle("Търсене на автомобила");
                        CheckAvailableCar();
                        break;
                    case "4":
                        ShowActionTitle("Списък с налични автомобили");
                        CarsList();
                        break;
                    case "x":
                    case "X":
                        Exit();
                        break;
                    default:
                        break;
                }
            }
        }
        private static void SaveCars()
        {
            StreamWriter writer = new StreamWriter(filePath, false, Encoding.Unicode);
            using (writer)
            {
                foreach (Car car in cars)
                {
                    writer.WriteLine(car);
                }
            }
        }
        private static void LoadCars()
        {
            StreamReader reader = new StreamReader(filePath, Encoding.Unicode);
            using (reader)
            {
                string line;
                while ((line = reader.ReadLine()) != null)
                {
                    string[] carInfo = line.Split(',');
                    string carId = carInfo[0];
                    string brand = carInfo[1];
                    string model = carInfo[2];
                    int year = int.Parse(carInfo[3]);
                    decimal price = decimal.Parse(carInfo[4]);
                    bool available = bool.Parse(carInfo[5]);

                    Car currentCar = new Car(carId, brand, model, year, price, available);
                    cars.Add(currentCar);
                }
            }
        }

        private static void Exit()
        {
            Environment.Exit(0);
        }

        private static void CarsList()
        {
            foreach(Car car in cars)
            {
                PrintCarInfo(car);
                AddLine();
            }
        }

        private static void PrintCarInfo(Car car)
        {
            Console.WriteLine($"\t Номер на автомобила {car.CarID}");
            Console.WriteLine($"\t Марка на автомобила {car.Brand}");
            Console.WriteLine($"\t Модел на автомобила {car.Model}");
            Console.WriteLine($"\t Година на производство {car.Year}");
            Console.WriteLine($"\t Цена на автомобила{car.Price}");
            Console.WriteLine($"\t Наличност на автомобила {car.AvailableCar}");
        }

        private static void CheckAvailableCar()
        {
            Console.Write("\tВъведете марка или модел на автомобила: ");
            string filter = Console.ReadLine();
            AddLine();

            var availableCars = cars
                .Where(f => f.Brand == filter || f.Model == filter)
                .ToList();
            if (availableCars.Count > 0)
            {
                foreach (var car in availableCars)
                {
                    if (availableCars != null)
                    {
                        PrintCarInfo(car);
                    }
                }
            }
            else
            {
                ShowResultMessage($"Търсеният от вас автомобил не е намерен.");
            }
        }

        private static void ShowResultMessage(string message)
        {
            AddLine();
            Console.WriteLine("\t" + message);
        }

        //TODO
        private static void BuyCar()
        {
            throw new NotImplementedException();
        }

        private static void AddNewCar()
        {
            Console.Write("\tНомер на автомобила: ");
            string carId = Console.ReadLine();

            Console.Write("\tМарка на автомобила: ");
            string brand = Console.ReadLine();

            Console.Write("\tМодел на автомобила: ");
            string model = Console.ReadLine();

            Console.Write("\tГодина на производство: ");
            int year = int.Parse(Console.ReadLine());

            Console.Write("\tЦена на автомобила: ");
            decimal price = decimal.Parse(Console.ReadLine());

            Console.Write("\tНаличност на автомобила: ");
            bool availableCar = bool.Parse(Console.ReadLine());

            try
            {
                Car newCar = new Car(carId, brand, model, year, price, availableCar);
                cars.Add(newCar);
                ShowResultMessage($"Автомобилът с номер {carId} и марка {brand} е добавен успешно.");
            }
            catch (ArgumentException)
            { 
                ShowResultMessage($"Невалидни данни за автомобил");
            }
            BackToMenu();
        }

        private static void BackToMenu()
        {
            AddLine();
            Console.Write("\tНатисни произвлен клавиш обратно към МЕНЮ: ");
            Console.ReadLine();
            PrintMenu();
        }
        private static void PrintMenu()
        {
            throw new NotImplementedException();
        }

        private static void AddLine(int count = 1)
        {
            for (int i = 0; i < count; i++)
            {
                Console.WriteLine(Environment.NewLine);
            }
        }

        private static void ShowActionTitle(string title)
        {
            Console.Clear();
            AddLine();
            Console.WriteLine("\t" + title);
            AddLine();
        }
    }
}
