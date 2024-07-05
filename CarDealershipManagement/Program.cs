using System;
using System.Collections.Generic;
using System.Linq;
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
                        AddNewCar();
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

        private static void LoadCars()
        {
            throw new NotImplementedException();
        }

        private static void PrintMenu()
        {
            throw new NotImplementedException();
        }

        private static void Exit()
        {
            throw new NotImplementedException();
        }

        private static void CheckAvailableCar()
        {
            throw new NotImplementedException();
        }

        private static void BuyCar()
        {
            throw new NotImplementedException();
        }

        private static void ShowActionTitle(string v)
        {
            throw new NotImplementedException();
        }

        private static void AddNewCar()
        {
            throw new NotImplementedException();
        }
    }
}
