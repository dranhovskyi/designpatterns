using System;
using System.Collections.Generic;

namespace MyDesignPatterns.Behavioural
{
    interface IHandler
    {
        IHandler SetNext(IHandler handler);

        object HandleRequest(object request);
    }

    abstract class AbstractHandler : IHandler
    {
        private IHandler nextHandler;

        public IHandler SetNext(IHandler handler)
        {
            this.nextHandler = handler;

            return handler;
        }

        public virtual object HandleRequest(object request)
        {
            if (this.nextHandler != null)
            {
                return this.nextHandler.HandleRequest(request);
            }
            return null;
        }
    }

    class PlasticHandler : AbstractHandler
    {
        public override object HandleRequest(object request)
        {
            Console.WriteLine($"{this.GetType().Name} processing: {request}");
            if (request is string str && str == "Plastic")
            {
                return $"{this.GetType().Name}: I'll take the {request.ToString()}.\n";
            }
            return base.HandleRequest(request);
        }
    }

    class GlassHandler : AbstractHandler
    {
        public override object HandleRequest(object request)
        {
            Console.WriteLine($"{this.GetType().Name} processing: {request}");
            if (request is string str && str == "Glass")
            {
                return $"{this.GetType().Name}: I'll take the {request.ToString()}.\n";
            }
            return base.HandleRequest(request);
        }
    }

    class MetalHandler : AbstractHandler
    {
        public override object HandleRequest(object request)
        {
            Console.WriteLine($"{this.GetType().Name} processing: {request}");
            if (request is string str && str == "Metal")
            {
                return $"{this.GetType().Name}: I'll take the {request.ToString()}.\n";
            }
            return base.HandleRequest(request);
        }
    }

    class PaperHandler : AbstractHandler
    {
        public override object HandleRequest(object request)
        {
            Console.WriteLine($"{this.GetType().Name} processing: {request}");
            if (request is string str && str == "Paper")
            {
                return $"{this.GetType().Name}: I'll take the {request.ToString()}.\n";
            }
            return base.HandleRequest(request);
        }
    }

    class OrganicHandler : AbstractHandler
    {
        public override object HandleRequest(object request)
        {
            Console.WriteLine($"{this.GetType().Name} processing: {request}");
            if (request is string str)
            {
                switch (str)
                {
                    case "Apple":
                    case "Orange":
                        return $"{this.GetType().Name}: I'll take the {str}.\n";
                }
            }
            return base.HandleRequest(request);
        }
    }

    public class ChainOfResponsibilityDemo
    {
        public static void Run()
        {
            var plastic = new PlasticHandler();
            var glass = new GlassHandler();
            var metal = new MetalHandler();
            var paper = new PaperHandler();
            var organic = new OrganicHandler();

            plastic.SetNext(glass).SetNext(metal).SetNext(paper);//.SetNext(organic);

            var trashCollection = new List<string> { "Glass", "Orange", "Paper" ,"Metal", "Plastic", "Apple" };

            foreach (var trash in trashCollection)
            {
                Console.WriteLine("\n");
                Console.WriteLine($"Transporter: what about {trash}?");

                var result = plastic.HandleRequest(trash);

                if (result != null)
                {
                    Console.Write($"   {result}");
                }
                else
                {
                    Console.WriteLine($"   {trash} is organic.");
                }
            }
        }
    }
}
