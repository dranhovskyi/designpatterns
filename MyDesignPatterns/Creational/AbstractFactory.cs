using System;
using System.Collections.Generic;

namespace MyDesignPatterns.Creational
{
    interface IFurnitureFactory
    {
        Chair CreateChair();
        Table CreateTable();
    }

    class WoodenFurnitureFactory : IFurnitureFactory
    {
        public Chair CreateChair()
        {
            return new WoodenChair(Guid.NewGuid());
        }

        public Table CreateTable()
        {
            return new WoodenTable(Guid.NewGuid());
        }
    }

    class PlasticFurnitureFactory : IFurnitureFactory
    {
        public Chair CreateChair()
        {
            return new PlasticChair(Guid.NewGuid());
        }

        public Table CreateTable()
        {
            return new PlasticTable(Guid.NewGuid());
        }
    }

    interface IFurniture
    {
        Guid SerialNumber { get; set; }
        string ProductName { get; set; }
    }

    class Table : IFurniture
    {
        public Guid SerialNumber { get; set; }
        public string ProductName { get; set; }

        public Table(Guid guid, string productName)
        {
            SerialNumber = guid;
            ProductName = productName;
        }
    }

    class Chair : IFurniture
    {
        public Guid SerialNumber { get; set; }
        public string ProductName { get; set; }

        public Chair(Guid guid, string productName)
        {
            SerialNumber = guid;
            ProductName = productName;
        }
    }

    class WoodenTable : Table
    {
        private Func<Guid> newGuid;

        public WoodenTable(Guid guid)
            : base(guid, "Wooden table")
        {
        }
    }

    class WoodenChair : Chair
    {
        public WoodenChair(Guid guid)
            : base(guid, "Wooden chair")
        {
        }
    }

    class PlasticTable : Table
    {
        public PlasticTable(Guid guid)
            : base(guid, "Plastic table")
        {
        }
    }

    class PlasticChair : Chair
    {
        public PlasticChair(Guid guid)
            : base(guid, "Plastic chair")
        {
        }
    }

    public class AbstractFactoryDemo
    {
        public static void Run()
        {
            RunWoodenFurnitureFactory();
            RunPlasticFurnitureFactory();
        }

        private static void RunWoodenFurnitureFactory()
        {
            IFurnitureFactory abstractFactory = new WoodenFurnitureFactory();
            var table = abstractFactory.CreateTable();

            //Create random number of chairs
            List<Chair> chairs = new List<Chair>();
            Random random = new Random();
            int randomNumber = random.Next(1, 5);
            for (int i = 0; i < randomNumber; i++)
            {
                chairs.Add(abstractFactory.CreateChair());
            }

            Console.WriteLine("Created 1 {0} {1}", table.ProductName, table.SerialNumber);
            for (int j = 0; j < chairs.Count; j++)
            {
                Console.WriteLine("Created {0} {1}", chairs[j].ProductName, chairs[j].SerialNumber);
            }
        }

        private static void RunPlasticFurnitureFactory()
        {
            IFurnitureFactory abstractFactory = new PlasticFurnitureFactory();
            var table = abstractFactory.CreateTable();

            //Create random number of chairs
            List<Chair> chairs = new List<Chair>();
            Random random = new Random();
            int randomNumber = random.Next(1, 5);
            for (int i = 0; i < randomNumber; i++)
            {
                chairs.Add(abstractFactory.CreateChair());
            }

            Console.WriteLine("Created 1 {0} {1}", table.ProductName, table.SerialNumber);
            for (int j = 0; j < chairs.Count; j++)
            {
                Console.WriteLine("Created {0} {1}", chairs[j].ProductName, chairs[j].SerialNumber);
            }
        }

        //Example: public sealed class SqlClientFactory : System.Data.Common.DbProviderFactory .NET Framework
        //that creates DbCommand DbConnection objects
    }
}
