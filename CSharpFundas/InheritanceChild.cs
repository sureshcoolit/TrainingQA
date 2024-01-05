using System;
using OpenQA.Selenium.DevTools.V85.Network;

namespace CSharpFundas
{
    public class InheritanceChild : InheritanceParent
    {
        static void Main(string[] args)
        {
            InheritanceParent child = new InheritanceParent();
            child.setData("This is a child class, and accessing the parent class method");
        }
    }
}