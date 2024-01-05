using System;

namespace CSharpFundas
{
    public class InheritanceParent
    {
        private String val1 = "Have a nice day!!!";

        public void setData(String val)
        {
            Console.WriteLine($"The value from the child class is {val}");
        }
    }
}