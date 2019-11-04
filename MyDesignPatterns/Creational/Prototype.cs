using System;
namespace MyDesignPatterns.Creational
{
    //C# has IClonable interface for cloning objects
    class Person
    {
        public int Age;
        public String Name;
        public DateTime BirthDate;
        public IdInfo IdInfo;

        public Person ShallowCopy()
        {
            return (Person)this.MemberwiseClone();
        }

        public Person DeepCopy()
        {
            Person clone = (Person)this.MemberwiseClone();
            clone.IdInfo = new IdInfo(IdInfo.IdNumber);
            clone.Name = String.Copy(Name);
            return clone;
        }
    }

    //class PersonCloneable : Person, ICloneable
    //{
    //    public object Clone()
    //    {
    //        return (Person)this.MemberwiseClone();
    //    }
    //}

    class IdInfo
    {
        public int IdNumber;

        public IdInfo(int idNumber)
        {
            this.IdNumber = idNumber;
        }
    }

    public class PrototypeDemo
    {
        public static void Run()
        {
            Person p1 = new Person
            {
                Age = 22,
                BirthDate = Convert.ToDateTime("1996-01-01"),
                Name = "Nazar",
                IdInfo = new IdInfo(777)
            };

            Person p2 = p1.ShallowCopy();
            Person p3 = p1.DeepCopy();

            Console.WriteLine("Original values of p1, p2, p3:");
            Console.WriteLine("   p1 instance values: ");
            DisplayValues(p1);
            Console.WriteLine("   p2 instance values:");
            DisplayValues(p2);
            Console.WriteLine("   p3 instance values:");
            DisplayValues(p3);

            // Изменить значение свойств p1 и отобразить значения p1, p2 и p3.
            p1.Age = 32;
            p1.BirthDate = Convert.ToDateTime("1992-01-01");
            p1.Name = "Ivan";
            p1.IdInfo.IdNumber = 7878;
            Console.WriteLine("\nValues of p1, p2 and p3 after changes to p1:");
            Console.WriteLine("   p1 instance values: ");
            DisplayValues(p1);
            Console.WriteLine("   p2 instance values (reference values have changed):");
            DisplayValues(p2);
            Console.WriteLine("   p3 instance values (everything was kept the same):");
            DisplayValues(p3);
        }

        private static void DisplayValues(Person p)
        {
            Console.WriteLine("   Name: {0:s}, Age: {1:d}, BirthDate: {2:MM/dd/yy}", p.Name, p.Age, p.BirthDate);
            Console.WriteLine("   ID#: {0:d}", p.IdInfo.IdNumber);
        }
    }
}
