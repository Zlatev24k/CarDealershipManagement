using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Runtime.CompilerServices;
using System.Runtime.ConstrainedExecution;
using System.Text;
using System.Threading.Tasks;

namespace CarDealershipManagement
{
    public class Program
    {
        private const string filePath = "../../Car.txt";
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
                        ShowActionTitle("Добавяне на нов автомобил:");
                        AddNewCar();
                        break;
                    case "2":
                        ShowActionTitle("Купуване на автомобил:");
                        BuyCar();
                        break;
                    case "3":
                        ShowActionTitle("Търсене на автомобила:");
                        CheckAvailableCar();
                        break;
                    case "4":
                        ShowActionTitle("Списък с налични автомобили:");
                        CarsList();
                        break;
                    case "x":
                    case "X":
                        Exit();
                        break;
                    default:
                        ShowActionTitle("Въведете някое от дадените!");
                        BackToMenu();
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
            BackToMenu();
        }

        private static void PrintCarInfo(Car car)
        {
            Console.WriteLine($"\t Номер на автомобила: {car.CarID}");
            Console.WriteLine($"\t Марка на автомобила: {car.Brand}");
            Console.WriteLine($"\t Модел на автомобила: {car.Model}");
            Console.WriteLine($"\t Година на производство: {car.Year}");
            Console.WriteLine($"\t Цена на автомобила: {car.Price} лв");
            Console.WriteLine($"\t Наличност на автомобила: {car.AvailableCar}");
            Console.WriteLine();
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
            BackToMenu();
        }

        private static void ShowResultMessage(string message)
        {
            AddLine();
            Console.WriteLine("\t" + message);
        }

        //TODO
        private static void BuyCar()
        {
            Console.Write("\tВъведете номер или модел на автомобила: ");
            string filter = Console.ReadLine();
            AddLine();

            var availableCars = cars
                .Where(f => (f.CarID == filter || f.Model == filter) && f.AvailableCar)
                .ToList();
            if (availableCars.Count > 0)
            {
                SellCar(availableCars[0]);
                SaveCars();
                ShowResultMessage($"Поздравления, вие успешно закупихте автомобила на стойност {availableCars[0].Price} лв!");
            }
            else
            {
                ShowResultMessage($"Търсеният от вас автомобил не е намерен.");
            }
            BackToMenu();
        }

        private static void SellCar(Car carForSale)
        {
            foreach (Car car in cars)
            {
                if (carForSale.CarID.Equals(car.CarID) || carForSale.Model.Equals(car.Model))
                {
                    car.AvailableCar = false;
                }
            }
        }

        private static void AddNewCar()
        {
            while (true)
            {
                Console.Write("\tМарка на автомобила: ");
                string brand = Console.ReadLine();

                Console.Write("\tМодел на автомобила: ");
                string model = Console.ReadLine();

                Console.Write("\tГодина на производство: ");
                string year = Console.ReadLine();

                Console.Write("\tЦена на автомобила: ");
                string price = Console.ReadLine();

                Console.Write("\tНаличност на автомобила: ");
                string availableCar = Console.ReadLine();

                try
                {
                    string carId = (int.Parse(cars[cars.Count() - 1].CarID) + 1).ToString();
                    Car newCar = new Car(carId, brand, model, int.Parse(year), decimal.Parse(price), bool.Parse(availableCar));
                    cars.Add(newCar);
                    ShowResultMessage($"Автомобилът с номер {carId} и марка {brand} е добавен успешно.");
                    break;
                }
                catch (Exception)
                {
                    ShowResultMessage($"Невалидни данни за автомобил,въведете данните отново:");
                }
            }
            SaveCars();
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
            Console.Clear();

            AddLine();
            Console.WriteLine("\tМ Е Н Ю");
            AddLine();
            Console.WriteLine("\tМоля изберете желаното действие:");
            AddLine();
            Console.WriteLine("\t[1]: Добавяне на нов автомобил");
            Console.WriteLine("\t[2]: Купуване на автомобил ");
            Console.WriteLine("\t[3]: Търсене на автомобил");
            Console.WriteLine("\t[4]: Списък с всички автомобили");
            Console.WriteLine("\t[x]: Изход от програмата");
            AddLine();
            Console.Write("\tВашият избор: ");
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
