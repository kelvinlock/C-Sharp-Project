using System;
using System.Collections.Generic;
using System.Dynamic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace 實作題_第三題
{
    internal class Program
    {
        static void Main(string[] args)
        {
            List<string> CarName = new List<string>();
            List<double> CarPrice= new List<double>();
            string inputName;
            string inputPrice;
            bool flag = false;
            int i = 0;

            Console.WriteLine("Enter car name and price. Type 'done' as name to stop input.");
            while (true)
            {
                Console.Write("Enter car name: ");
                inputName = Console.ReadLine();

                if (inputName.ToLower() == "done")
                    break;

                Console.Write("Enter car price: ");
                inputPrice = Console.ReadLine();

                if (double.TryParse(inputPrice, out double price))
                {
                    CarName.Add(inputName);
                    CarPrice.Add(price);
                }
                else
                {
                    Console.WriteLine("Invalid price. Please try again.");
                }
            }

            // Create Car object and display data
            Car car = new Car(CarName.ToArray(), CarPrice.ToArray());
        }
    }
    interface IPrice
    {
        void GetPrice();
    }
    class Car : IPrice 
    {
        public double[] Price;
        public string[] Name;
        public Car(string[] name,double[] price)
        {
            this.Price = price;
            this.Name = name;
            GetName();
            GetPrice();
        }
        public void GetPrice()
        {
            Console.WriteLine("\nCar Prices:");
            for (int a = 0; a < Price.Length; a++)
            {
                Console.WriteLine($"{Price[a]:C}");
            }
        }
        public void GetName()
        {
            Console.WriteLine("\nCar Names:");
            for (int a = 0; a < Name.Length; a++)
            {
                Console.WriteLine($"{Name[a]}");
            }
        }
    }
}
