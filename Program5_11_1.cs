using System;

namespace OverloadExample
{
    class MathTool
    {
        public int Cube(int n)
        {
            return n * n * n;
        }

        public double Cube(double n)
        {
            return n * n * n;
        }

        public int MinElement(int a, int b, int c)
        {
            return Math.Min(a, Math.Min(b, c));
        }

        public int MinElement(int a, int b, int c, int d)
        {
            return Math.Min(a, Math.Min(b, Math.Min(c, d)));
        }
    }

    class Program
    {
        static void Main(string[] args)
        {
            MathTool tool = new MathTool();

            Console.WriteLine("請選擇操作類型：");
            Console.WriteLine("1. Cube(int)");
            Console.WriteLine("2. Cube(double)");
            Console.WriteLine("3. MinElement(3 ints)");
            Console.WriteLine("4. MinElement(4 ints)");
            Console.Write("輸入選項（1~4）：");
            string choice = Console.ReadLine();

            switch (choice)
            {
                case "1":
                    Console.Write("請輸入一個整數：");
                    int intVal = Convert.ToInt32(Console.ReadLine());
                    Console.WriteLine("立方為：" + tool.Cube(intVal));
                    break;

                case "2":
                    Console.Write("請輸入一個小數：");
                    double doubleVal = Convert.ToDouble(Console.ReadLine());
                    Console.WriteLine("立方為：" + tool.Cube(doubleVal));
                    break;

                case "3":
                    Console.WriteLine("請輸入三個整數：");
                    int a = Convert.ToInt32(Console.ReadLine());
                    int b = Convert.ToInt32(Console.ReadLine());
                    int c = Convert.ToInt32(Console.ReadLine());
                    Console.WriteLine("最小值為：" + tool.MinElement(a, b, c));
                    break;

                case "4":
                    Console.WriteLine("請輸入四個整數：");
                    int x = Convert.ToInt32(Console.ReadLine());
                    int y = Convert.ToInt32(Console.ReadLine());
                    int z = Convert.ToInt32(Console.ReadLine());
                    int w = Convert.ToInt32(Console.ReadLine());
                    Console.WriteLine("最小值為：" + tool.MinElement(x, y, z, w));
                    break;

                default:
                    Console.WriteLine("無效的選項！");
                    break;
            }
        }
    }
}


