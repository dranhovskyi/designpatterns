using System;

namespace MyDesignPatterns.Behavioural
{
    interface ICommand
    {
        void Execute();
    }

    class SimpleCommand : ICommand
    {
        private string payload = string.Empty;

        public SimpleCommand(string payload)
        {
            this.payload = payload;
        }

        public void Execute()
        {
            Console.WriteLine($"SimpleCommand: See, I can do simple things like printing ({this.payload})");
        }
    }

    class ComplexCommand : ICommand
    {
        private Receiver receiver;

        private string a;
        private string b;
        
        public ComplexCommand(Receiver receiver, string a, string b)
        {
            this.receiver = receiver;
            this.a = a;
            this.b = b;
        }

        // Commands can delegate execution to any receiver methods.
        public void Execute()
        {
            Console.WriteLine("ComplexCommand: Complex stuff should be done by a receiver object.");
            this.receiver.DoSomething(this.a);
            this.receiver.DoSomethingElse(this.b);
        }
    }
    
    class Receiver
    {
        public void DoSomething(string a)
        {
            Console.WriteLine($"Receiver: Working on ({a}.)");
        }

        public void DoSomethingElse(string b)
        {
            Console.WriteLine($"Receiver: Also working on ({b}.)");
        }
    }

    class Invoker
    {
        private ICommand onStart;
        private ICommand onFinish;

        // Command init
        public void SetOnStart(ICommand command)
        {
            this.onStart = command;
        }

        public void SetOnFinish(ICommand command)
        {
            this.onFinish = command;
        }

        public void DoSomethingImportant()
        {
            Console.WriteLine("Invoker: Does anybody want something done before I begin?");
            if (this.onStart is ICommand)
            {
                this.onStart.Execute();
            }

            Console.WriteLine("Invoker: ...doing something really important...");

            Console.WriteLine("Invoker: Does anybody want something done after I finish?");
            if (this.onFinish is ICommand)
            {
                this.onFinish.Execute();
            }
        }
    }

    public class CommandDemo
    {
        public static void Run()
        {
            Invoker invoker = new Invoker();
            invoker.SetOnStart(new SimpleCommand("Say Hi!"));

            Receiver receiver = new Receiver();
            invoker.SetOnFinish(new ComplexCommand(receiver, "Send email", "Save report"));

            invoker.DoSomethingImportant();
        }
    }
}
