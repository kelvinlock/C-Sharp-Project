using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace 實作題_第3題
{
    delegate double MyDelegate(double value);
    internal class Program
    {
        static void Main(string[] args)
        {
            Program prg = new Program();
            Console.WriteLine("This is a Feet to Inches or Yard to Inches Convertor:");
            Console.Write("What is your input Feet or Yard? ");
            String input = Console.ReadLine();
            Console.Write("Value: ");
            double value = Convert.ToDouble(Console.ReadLine());
            if (input.ToLower() == "Feet")
            {
                MyDelegate handler = new MyDelegate(prg.FeetToInches);
                Console.Write($"{value} Feet is {handler(value)} Inches");
            }
            else if (input.ToLower() == "Yard")
            {
                MyDelegate handler = new MyDelegate(prg.YardToInches);
                Console.Write($"{value} Yard is {handler(value)} Inches");
            }
            else
                throw new Exception("Input only available Feet and Yard!");
        }
        double FeetToInches(double value)
        {
            return value * 12;
        }
        double YardToInches(double value)
        {
            return value * 36;
        }
    }
}
