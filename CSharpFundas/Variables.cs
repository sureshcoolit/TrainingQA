using System;
using System.Diagnostics;

namespace CSharpFundas
{
    class Variables
    {
        public void getData()
        {
            Console.WriteLine("I am inside the first method");
        }
        static void Main(string[] args)
        {
            Variables v = new Variables();
            v.getData();
            Debug.WriteLine("Welcome Neelima"); //will write the output in the Output section
            Console.WriteLine("Welcome Neelu"); //Will display the output in the console window
            //Datatypes
            //Static Datatypes - int,string,char,float, double etc.,
            //Dynamic Datatypes - var, dynamic

            int a = 4;
            Console.WriteLine("Number is "+a);
            Console.WriteLine($"Number is {a}"); //Evaluated String

            String name = "Neelima";
            Console.WriteLine(name);

            var age = 25;
            Console.WriteLine($"Age is {age}");
            //age = "hello"; //will throw an error like cannot convert string to target type int

            dynamic height = 13.2;
            Console.WriteLine($"Height is {height}");

            height = "hello";
            Console.WriteLine($"Height is {height}");
        }
    }
}
