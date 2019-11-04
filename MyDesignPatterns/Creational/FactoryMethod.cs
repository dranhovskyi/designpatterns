using System;
using System.Collections.Generic;
using System.Linq;

namespace MyDesignPatterns.Creational
{
    enum NotificationProviders
    {
        SMS,
        Email,
        Application
    }

    interface INotification
    {
        void SendNotification(string message);
    }

    class SMSProvider : INotification
    {
        public void SendNotification(string message)
        {
            var list = new List<int>();
            list.Select(x => x);
            Console.WriteLine($"SMS: {message}");
        }
    }

    class EmailProvider : INotification
    {
        public void SendNotification(string message)
        {
            Console.WriteLine($"Email: {message}");
        }
    }

    class ApplicationProvider : INotification
    {
        public void SendNotification(string message)
        {
            Console.WriteLine($"Push notification: {message}");
        }
    }

    class NotificationProviderFactory
    {
        public static INotification GetLoggingProvider(NotificationProviders notificationProviders)
        {
            switch (notificationProviders)
            {
                case NotificationProviders.Email:
                    return new EmailProvider();
                case NotificationProviders.Application:
                    return new ApplicationProvider();
                default:
                    return new SMSProvider();
            }
        }
    }

    public class FactoryMethodDemo
    {
        public static void Run()
        {
            //Set provider type
            var providerType = NotificationProviders.SMS;
            INotification notification = NotificationProviderFactory.GetLoggingProvider(providerType);
            notification.SendNotification("Don't forget to buy a bread and milk!");
        }
    }
    //Task.Factory.StartNew(some Action, ...);

    //В чем разница между abstractfactory и фабричным методом?
    /*
     The main difference between a "factory method" and an "abstract factory" is
     that the factory method is a single method, and an abstract factory is an object.

    - The abstract factory is an object that has multiple factory methods on it.

    The main difference between the two is that with the Abstract Factory
    pattern, a class delegates the responsibility of object instantiation to another
    object via composition whereas the Factory Method pattern uses
    inheritance and relies on a subclass to handle the desired object
    instantiation

     */
}
