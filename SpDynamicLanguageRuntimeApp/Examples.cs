using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SpDynamicLanguageRuntimeApp
{
    public class Examples
    {
        public static void DynamicExample()
        {
            object obj = 100;
            int result = (int)obj + 200;
            // obj += 200; // non compile


            //dyn = "Hello";
            int number = 100;
            var var1 = number;
            var1 += 200;


            dynamic dyn = 100;
            dyn += 100;
            dyn = "Hello";
            Console.WriteLine(dyn.Length);

            //obj = "Hello";

            //var var1 = 100;
            //var var2 = "Hello"; 

            Person person = new Person();
            person.SetId(100);
            person.SetId("ASD");

        }

    }

    class Person
    {
        public string Name { get; set; }

        dynamic id;

        public void SetId(dynamic id)
        {
            this.id = id;
        }

        public dynamic GetId()
        {
            return this.id;
        }

    }
}
