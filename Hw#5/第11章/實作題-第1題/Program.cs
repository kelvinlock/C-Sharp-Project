using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace 實作題_第一題
{
    internal class Program
    {
        static void Main(string[] args) {
            Console.Write("Enter a number and calculate the cube of that number: ");
            String input = Console.ReadLine();
            DetectNumberType(input);
            Console.Write("Enter 3 or 4 numbers and get the smallest number:");
            String numbers = Console.ReadLine();
            Print(numbers);
        }
        static int cube(int value)
        {
            return (value * value * value);
        }
        static double cube(double value)
        {
            return (value * value * value);
        }
        static void DetectNumberType(string input)
        {
            if (int.TryParse(input, out _))
                Console.WriteLine($"Cube number of {input} is {cube(int.Parse(input))}");
            else if (double.TryParse(input, out _))
                Console.WriteLine($"Cube number of {input} is {cube(double.Parse(input))}");
            else
                Console.Write("Not a number.");
        }
        static void Print(String input)
        {
            String[] arr = input.Split(new[] { ',' }, StringSplitOptions.RemoveEmptyEntries);
            if (arr.Length == 3)
            {
                int a  = int.Parse(arr[0]);
                int b  = int.Parse(arr[1]);
                int c  = int.Parse(arr[2]);
                Console.Write("Minimum value: "+MinElement(a, b, c));
            }
            else if (arr.Length == 4)
            {
                int a = int.Parse(arr[0]);
                int b = int.Parse(arr[1]);
                int c = int.Parse(arr[2]);
                int d = int.Parse(arr[3]);
                Console.Write("Minimum value: " + MinElement(a, b, c, d));
            }
        }
        static int MinElement(int a, int b, int c)
        {
            int minelement = a;
            int[] arr = { a, b, c };
            for(int i = 0;i < arr.Length; i++)
            {
                if ( minelement > arr[i] )
                   minelement = arr[i];
            }
            return minelement;
        }
        static int MinElement(int a, int b, int c, int d)
        {
            int minelement = a;
            int[] arr = { a, b, c ,d };
            for (int i = 0; i < arr.Length; i++)
            {
                if ( minelement > arr[i] )
                    minelement = arr[i];
            }
            return minelement;
        }
    }
}
