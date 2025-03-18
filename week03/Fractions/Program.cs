using System;

class Program
{
    static void Main(string[] args)
    {
        Console.WriteLine("Hello World! This is the Fractions Project.");

        Fraction fraction1 = new Fraction();        
        Fraction fraction2 = new Fraction(5);       
        Fraction fraction3 = new Fraction(3, 4);    
        Fraction fraction4 = new Fraction(1, 3);    

        PrintFraction(fraction1);
        PrintFraction(fraction2);
        PrintFraction(fraction3);
        PrintFraction(fraction4);
    }

    static void PrintFraction(Fraction fraction)
    {
        Console.WriteLine(fraction.GetFractionString());
        Console.WriteLine(fraction.GetDecimalValue());
        Console.WriteLine(); 
    }
}