using System;
namespace MyDesignPatterns.Creational
{
    class IPhone
    {
        public string Model { get; set; }
        public string Color { get; set; }
        public int Capacity { get; set; }
        public string CarrierType { get; set; }        

        public override string ToString()
        {
            return $"{Model} {Color} {Capacity}Gb {CarrierType}";
        }
    }

    //1)_________________________
    abstract class IPhoneBuilder
    {
        protected IPhone IPhone { get; private set; }

        public void CreateNewIPhone()
        {
            IPhone = new IPhone();
        }

        public IPhone GetMyIPhone()
        {
            return IPhone;
        }

        public abstract void SetModel();
        public abstract void SetColor();
        public abstract void SetCapacity();
        public abstract void SetCarrierType();
    }

    class IPhone11ProMaxMidnightGreen128GbSIMFree : IPhoneBuilder
    {
        public override void SetModel()
        {
            IPhone.Model = "IPhone 11 Pro Max";
        }

        public override void SetColor()
        {
            IPhone.Color = "Midnight Green";
        }

        public override void SetCapacity()
        {
            IPhone.Capacity = 128;
        }

        public override void SetCarrierType()
        {
            IPhone.CarrierType = "SIM-free";
        }
    }

    class IPhone7JetBlack64GbSIM : IPhoneBuilder
    {
        public override void SetModel()
        {
            IPhone.Model = "IPhone 7";
        }

        public override void SetColor()
        {
            IPhone.Color = "Jet Black";
        }

        public override void SetCapacity()
        {
            IPhone.Capacity = 64;
        }

        public override void SetCarrierType()
        {
            IPhone.CarrierType = "SIM";
        }
    }

    class Director
    {
        private IPhoneBuilder iPhoneBuilder;
        public void SetIPhoneBuilder(IPhoneBuilder iPhoneBuilder)
        {
            this.iPhoneBuilder = iPhoneBuilder;
        }

        public IPhone GetPhone()
        {
            return iPhoneBuilder.GetMyIPhone();
        }

        public void ConstructPhone()
        {
            iPhoneBuilder.CreateNewIPhone();
            iPhoneBuilder.SetModel();
            iPhoneBuilder.SetColor();
            iPhoneBuilder.SetCapacity();
            iPhoneBuilder.SetCarrierType();
        }
    }

    //2)_________________________
    sealed class PhoneBuilder
    {
        private readonly IPhone phone = new IPhone();

        public PhoneBuilder Model(string model)
        {
            phone.Model = model;
            return this;
        }

        public PhoneBuilder Color(string color)
        {
            phone.Color = color;
            return this;
        }

        public PhoneBuilder Capacity(int capacity)
        {
            phone.Capacity = capacity;
            return this;
        }

        public PhoneBuilder CarrierType(string carrierType)
        {
            phone.CarrierType = carrierType;
            return this;
        }

        public IPhone Build()
        {
            return phone;
        }
    }

    public class BuilderDemo
    { 
        public static void Run()
        {
            //1
            var iPhone1 = new IPhone7JetBlack64GbSIM();
            var director = new Director();
            director.SetIPhoneBuilder(iPhone1);
            director.ConstructPhone();

            IPhone myIPhone = director.GetPhone();
            Console.WriteLine(myIPhone.ToString());

            //2
            var iPhone2 = new PhoneBuilder()
                .Model("IPhone 7")
                .Color("Jet Black")
                .Capacity(64)
                .CarrierType("SIM")
                .Build();

            Console.WriteLine(iPhone2.ToString());
        }

        //Example StringBuilder().Append("X").ToString();
    }
}
