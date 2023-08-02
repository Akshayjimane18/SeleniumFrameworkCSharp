using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CSharpFundas
{
    class Program : Program3
    {
        String name;
        String lastName;
        //default constructor
        public Program(String name)
        {

            this.name = name;
        }

        public Program(String name, String lastName)
        {

            this.name = name;
            this.lastName = lastName;
        }

        public void getName()
        {
            Console.WriteLine("My name is " + this.name);
        }

        public void getFullName()
        {
            Console.WriteLine("My name is " + this.name + " " + this.lastName);
        }
        static void Main(string[] args)
        {
            Program2 p2 = new Program2();
            p2.getData();
            Program p = new Program("Akshay");
            p.getName();
            p.setData();
            Program p1 = new Program("Akshay", "Mane");
            p1.getFullName();
            Console.WriteLine("Hello World");
            int a = 4;
            //Double = 3.23
            Console.WriteLine("Number is " + a);

            String name = "Akshay";
            Console.WriteLine(name);

            Console.WriteLine($"Name is {name}");

            //any value first time only
            var age = "29";


            Console.WriteLine("Age is " + age);

            //dynamic will change every time
            dynamic height = 13.2;
            Console.WriteLine($"Height is " + height);

            height = "Height";
            Console.WriteLine($"Height is " + height);

            Console.Read();
        }
    }
}
