using System;
using HW5_10_3;

namespace HWS_10_3
{
    class Program
    {
        static void Main()
        {
            Car myCar = new Car("Toyota", 800000);
            Console.WriteLine("車名: " + myCar.GetName());
            Console.WriteLine("價格: " + myCar.GetPrice());
        }
    }
}
