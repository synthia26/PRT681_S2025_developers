using System;
using System.Collections.Generic;
using System.Linq;
using System.Security;
using System.Text;
using System.Threading.Tasks;

namespace ClassField
{
    internal class Program
    {
        class Person
        {
            private string Name;
            private int Age;

            public Person(string name, int age)
            {
                Name = name;
                Age = age;
            }   

            public void setName(string name)
            {
                if(!string.IsNullOrEmpty(name))
                {
                    Name = name;
                }
                else
                {
                    throw new ArgumentException("Name cannot be null or empty");
                }
            }

            public string getName() => Name;
            //public void setAge(int age)
            //{
            //    if(age > 0 && age <150)
            //    {
            //        Age = age;
            //    }
            //    else
            //    {
            //        throw new ArgumentException("Age must be greater than zero");
            //    }
            //}
            public void setAge(int age) => Age = (age > 0 && age < 150) ? age : -1;


            public int getAge() => Age;
        }
        static void Main(string[] args)
        {
            Person shaikat = new Person("Shaikat", 30);
            Person noDee = new Person("NoDee", 25);
            noDee.setName("Ananna");
            Console.WriteLine(noDee.getName());
            Console.WriteLine(shaikat.getName());
            shaikat.setAge(20);
            Console.WriteLine(shaikat.getAge());

            //Person shaikat = new Person;
            //shaikat.setName("Shaikat");
        }
    }
}
