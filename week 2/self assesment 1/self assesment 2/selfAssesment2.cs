using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace self_assesment_2
{
    internal class selfAssesment2
    {
class Program
    {
        static void Main(string[] args)
        {
 
            Calculator calculator = new Calculator();

            Console.WriteLine("Addition: 5 + 3 = " + calculator.Add(5, 3));

            Console.WriteLine("Subtraction: 10 - 4 = " + calculator.Subtract(10, 4));

            Console.WriteLine("Multiplication: 6 * 7 = " + calculator.Multiply(6, 7));

            try
            {
                Console.WriteLine("Division: 20 / 4 = " + calculator.Divide(20, 4));
                Console.WriteLine("Division: 10 / 0 = " + calculator.Divide(10, 0)); // This will throw an exception
            }
            catch (DivideByZeroException ex)
            {
                Console.WriteLine(ex.Message);
            }

            Console.ReadLine();
        }
    }

}
}
public class Calculator
{
    // Constructor
    public Calculator()
    {
        Console.WriteLine("Calculator initialized.");
    }

    // Method for Addition
    public double Add(double a, double b)
    {
        return a + b;
    }

    // Method for Subtraction
    public double Subtract(double a, double b)
    {
        return a - b;
    }

    // Method for Multiplication
    public double Multiply(double a, double b)
    {
        return a * b;
    }

    // Method for Division
    public double Divide(double a, double b)
    {
        if (b == 0)
        {
            throw new DivideByZeroException("Cannot divide by zero.");
        }
        return a / b;
    }
}
