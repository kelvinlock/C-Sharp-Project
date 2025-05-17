using System;
using HW5_12_3;

namespace UnitConverter
{
    public delegate double ConvertToInches(double value);
    class Program
    {
        static void Main(string[] args)
        {
            Console.Write("請輸入數值：");
            double input = Convert.ToDouble(Console.ReadLine());

            Console.WriteLine("請選擇轉換方式：");
            Console.WriteLine("1. 英尺轉英吋");
            Console.WriteLine("2. 英碼轉英吋");
            Console.Write("請輸入選項（1 或 2）：");
            string choice = Console.ReadLine();

       
            ConvertToInches converter = null;

            if (choice == "1")
            {
                FeetConverter feet = new FeetConverter();
                converter = feet.FeetToInches;
            }
            else if (choice == "2")
            {
                YardConverter yard = new YardConverter();
                converter = yard.YardToInches;
            }
            else
            {
                Console.WriteLine("無效的選項！");
                return;
            }

            
            double result = converter(input);
            Console.WriteLine("轉換結果為：" + result + " 英吋");
        }
    }
}
