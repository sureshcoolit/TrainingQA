using System;

namespace CSharpFundas
{
    public class ConstructorsAndThisKeyword
    {
        private String name;
        private String firstName;
        private String lastName;

        public ConstructorsAndThisKeyword()
        {
            Console.WriteLine("constructor with no params is called");
        }
        
       public ConstructorsAndThisKeyword(String name1)
        {
            this.name = name1;
        }
       
       public ConstructorsAndThisKeyword(String firstName,String lastname)
       {
           this.firstName = firstName;
           this.lastName = lastname;
           Console.WriteLine($"constructor with 2 params is called {this.firstName} {this.lastName}");
       }

        public void getName()
        {
            Console.WriteLine($"My name is {this.name}");
        }
        
        public static void Main(String[] args)
        {
            ConstructorsAndThisKeyword p = new ConstructorsAndThisKeyword();
            ConstructorsAndThisKeyword c = new ConstructorsAndThisKeyword("Neelima");
            ConstructorsAndThisKeyword d = new ConstructorsAndThisKeyword("Neelima", "Bathula");
            c.getName();
        }

    }
}