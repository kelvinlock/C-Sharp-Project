using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace 实作题_第二题
{
    public class Box
    {
        private double Width, Height, Length;
        public Box(double width, double height, double length) 
        { 
            this.Width = width;
            this.Height = height;
            this.Length = length;
        }
        public double Volume()
        {
            return (Width * Height * Length);
        }
        public (double rectangle_lw, double rectangle_wh,double rectangle_lh, double square) Area()
        {
            double rectangle_lw = Length * Width;
            double rectangle_wh = Width * Height;
            double rectangle_lh = Length * Height;
            if (Width == Height && Width == Length)
            {
                return (0,0,0,(Width * Length));
            }
            else if (Width == Height)
            {
                double square = Width * Height;
                return (rectangle_lw, 0, 0, square);
            }
            else
            {
                return (rectangle_lw, rectangle_wh, rectangle_lh, 0);
            }
        }
    }
    internal class Program
    {
        static void Main(string[] args)
        {
            Console.WriteLine("Calculate Area and Volume:");
            Console.Write("Input Length: ");
            string length = Console.ReadLine();
            Console.Write("Input Width: ");
            string width = Console.ReadLine();
            Console.Write("Input Height: ");
            string height = Console.ReadLine();
            double lengthValue = Convert.ToDouble(length);
            double widthValue = Convert.ToDouble(width);
            double heightValue = Convert.ToDouble(height);
            Box box = new Box(widthValue, heightValue, lengthValue);

            if (widthValue == heightValue && widthValue == lengthValue)
            {
                Console.Write($"Area: {box.Area().square}\nVolume: {box.Volume()}");
            }
            else if (widthValue == heightValue)
            {
                Console.Write($"Area:\n rectangle(Length*Width): {box.Area().rectangle_lw}\n square: {box.Area().square}\nVolume: {box.Volume()}");
            }
            else
            {
                Console.Write($"Area:\n rectangle(Length * Width): {box.Area().rectangle_lw}\n rectangle(Width * Heigth): {box.Area().rectangle_wh}\n rectangle(Length * Heigth): {box.Area().rectangle_lh}\nVolume: {box.Volume()}");
            }
        }
    }
}
