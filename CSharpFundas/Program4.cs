using OpenQA.Selenium;
using OpenQA.Selenium.Chrome;
using System;
using System.Collections;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using WebDriverManager.DriverConfigs.Impl;

namespace CSharpFundas
{
    class Program4
    {
        String name;
        /*static void Main(string[] args)
        {

            *//*String[] a = { "hello", "bye", "rahul", "sheety" };
            int[] b = { 1, 2, 3, 4, };

            String[] a1 = new String[4];
            a1[0] = "hello";
            a1[2] = "bye";

            Console.WriteLine(a1[0]);

            for (int i = 0; i < a1.Length; i++)
            {
                Console.WriteLine(a1[i]);
                if (a[i] == "hello")
                {
                    Console.WriteLine("Match found");
                    break;
                }
            }

            ArrayList alist = new ArrayList();
            alist.Add("hello");
            alist.Add("bye");
            alist.Add("Rahul");
            alist.Add("Apple");

            foreach (String item in alist)
            {
                Console.WriteLine(item);
            }

            Console.WriteLine(alist.Contains("Rahul"));

            Console.WriteLine(alist[1]);

            alist.Sort();

            foreach (String item in alist)
            {
                Console.WriteLine(item);
            }

            Console.Read();*//*

            new WebDriverManager.
                  DriverManager().SetUpDriver(new ChromeConfig());
            IWebDriver driver = new ChromeDriver();
            driver.Url = "https://google.com";
        }*/
    }
}
