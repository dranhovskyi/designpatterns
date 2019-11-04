using System;
using System.Threading;

namespace MyDesignPatterns.Creational
{
    //1) Simplicity + thread-safe + «Lazy»! .NET 4.0+
    public sealed class LazySingleton
    {
        private static readonly Lazy<LazySingleton> instance =
            new Lazy<LazySingleton>(() => new LazySingleton());

        LazySingleton() { }

        public Coordinate CurrentLocation { get; set; }

        public Coordinate GetCurrentLocation()
        {
            Random random = new Random();
            return CurrentLocation = new Coordinate() { lat = random.NextDouble() * 90.0, lon = random.NextDouble() * 180 };
        }

        public static LazySingleton Instance { get { return instance.Value; } }
    }

    public struct Coordinate
    {
        public double lat;
        public double lon;
    }

    //2)Thread safe with volatile keyword
    public sealed class DoubleCheckedLockSingleton
    {
        //Volatile!
        private static volatile DoubleCheckedLockSingleton instance;
        private static readonly object syncRoot = new object();

        DoubleCheckedLockSingleton() { }

        public static DoubleCheckedLockSingleton Instance
        {
            get
            {
                if (instance == null)
                {
                    lock (syncRoot)
                    {
                        if (instance == null)
                        {
                            instance = new DoubleCheckedLockSingleton();
                        }
                    }
                }
                return instance;
            }
        }
    }

    //3 Ambient Context не гарантирует наличия одного экземпляра, а лишь обеспечивает глобальную
    //точку доступа к некоторой зависимости
    public interface ILogger
    {
        void Write();
    }

    internal class DefaultLogger : ILogger
    {
        public void Write() { }
    }

    public class GlobalLogger
    {
        private static ILogger logger = new DefaultLogger();

        public static ILogger Logger
        {
            get { return logger; }
            internal set { logger = value; }
        }
    }

    public class SingletonDemo
    {
        public static void Run()
        {
            LazySingleton.Instance.GetCurrentLocation();
            Thread.Sleep(1000);
            Console.WriteLine($"lat: {LazySingleton.Instance.CurrentLocation.lat}; lon:{LazySingleton.Instance.CurrentLocation.lon}");
            LazySingleton.Instance.GetCurrentLocation();
            Thread.Sleep(1000);
            Console.WriteLine($"lat: {LazySingleton.Instance.CurrentLocation.lat}; lon:{LazySingleton.Instance.CurrentLocation.lon}");
            LazySingleton.Instance.GetCurrentLocation();
            Thread.Sleep(1000);
            Console.WriteLine($"lat: {LazySingleton.Instance.CurrentLocation.lat}; lon:{LazySingleton.Instance.CurrentLocation.lon}");
        }
    }
}
