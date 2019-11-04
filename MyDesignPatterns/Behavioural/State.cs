using System;
namespace MyDesignPatterns.Behavioural
{
    class Context
    {
        private State state = null;

        public Context(State state)
        {
            this.TransitionTo(state);
        }

        public void TransitionTo(State state)
        {
            Console.WriteLine($"Context: Transition to {state.GetType().Name}.");
            this.state = state;
            this.state.SetContext(this);
        }

        public void Request1()
        {
            this.state.Handle1();
        }

        public void Request2()
        {
            this.state.Handle2();
        }
    }

    abstract class State
    {
        protected Context context;

        public void SetContext(Context context)
        {
            this.context = context;
        }

        public abstract void Handle1();

        public abstract void Handle2();
    }

    class ConcreteStateA : State
    {
        public override void Handle1()
        {
            Console.WriteLine("ConcreteStateA handles request1.");
            Console.WriteLine("ConcreteStateA wants to change the state of the context.");
            this.context.TransitionTo(new ConcreteStateB());
        }

        public override void Handle2()
        {
            Console.WriteLine("ConcreteStateA handles request2.");
        }
    }

    class ConcreteStateB : State
    {
        public override void Handle1()
        {
            Console.Write("ConcreteStateB handles request1.");
        }

        public override void Handle2()
        {
            Console.WriteLine("ConcreteStateB handles request2.");
            Console.WriteLine("ConcreteStateB wants to change the state of the context.");
            this.context.TransitionTo(new ConcreteStateA());
        }
    }

    public class StateDemo
    {
        public static void Run()
        {
            var context = new Context(new ConcreteStateA());
            context.Request1();
            context.Request2();
        }
    }
}
