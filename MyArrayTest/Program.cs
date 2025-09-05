// See https://aka.ms/new-console-template for more information
using System.ComponentModel;

namespace MyArrayTest
{
    class Program
    {
        static void Main(string[] args)
        {
            //System.Console.WriteLine("Hello, World!");
            /*
            string[] names = { "Rumana", "Sadia", "Nabila", "Mim" };
            foreach (string name in names)
            {
                System.Console.WriteLine(name);
            */

            /*

            int[] inventory = [230, 200, 400, 120, 450];
            int sum = 0;
            int bin = 0;
            foreach (int items in inventory)
            {
                sum += items;
                bin++;
                System.Console.WriteLine($"Bin {bin} = {items} items. (Running total: {sum})");
            }
            System.Console.WriteLine($"We have total {sum} items in our inventory.");
            */

            string[] names = new string[8];
            names[0] = "Rumana";
            names[1] = "Sadia";
            names[2] = "Nabila";
            names[3] = "Mim";
            names[4] = "Anika";
            names[5] = "Mitu";
            names[6] = "Sabina";
            names[7] = "Tania";

            foreach (string name in names)
            {
                if (name.StartsWith("S"))
                {
                    System.Console.WriteLine($"{name} starts with the letter 'S'");
                }

                if (name.Contains("b"))
                {
                    System.Console.WriteLine($"{name} contains the letter 'b'");
                }
            }

        }
    }
}
