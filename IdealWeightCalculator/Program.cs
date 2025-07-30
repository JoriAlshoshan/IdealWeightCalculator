using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace IdealWeightCalculator;

public class Program
{
    static void Main(string[] args)
    {
        Console.BackgroundColor = ConsoleColor.White;
        Console.ForegroundColor = ConsoleColor.Black;


        WeightCalculator weightCalculator = new WeightCalculator
        {
            Height = 180,
            Sex = 'm'
        };

        double weight = weightCalculator.GetIdealBodyWeight();

        Console.WriteLine($"The Ideal Body Weight: {weight}");

        if (weight == 72.5)
        {
            Console.ForegroundColor = ConsoleColor.Green;
            Console.WriteLine("Test Sucusseded :) ");
        }
        else
        {
            Console.ForegroundColor = ConsoleColor.Red;
            Console.WriteLine("Test Failed :(  ");
        }

        weightCalculator.Sex = 'w';
        weight = weightCalculator.GetIdealBodyWeight();


        if (weight == 72.5)
        {
            Console.ForegroundColor = ConsoleColor.Green;
            Console.WriteLine("Test Sucusseded :) ");
        }
        else
        {
            Console.ForegroundColor = ConsoleColor.Red;
            Console.WriteLine("Test Failed :(  ");
        }

        Console.ReadKey();

    }

}