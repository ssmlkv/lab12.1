using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace lab10
{
    public class FreightWagon:Carriage
    {
        protected string cargoTransported;
        protected int tonnage;

        public string CargoTransported
        {
            get => cargoTransported;
            set
            {
                if (!string.IsNullOrEmpty(value))
                    cargoTransported = value;
                else
                    cargoTransported = "Unknown";
            }
        }

        public int Tonnage
        {
            get => tonnage;
            set
            {
                if (value < 0)
                    tonnage = 0;
                else
                    tonnage = value;
            }
        }

        public FreightWagon() : base() 
        {
            CargoTransported = "";
        }
        public FreightWagon(IdNumber id, int number, int maxSpeed, string cargoTransported, int tonnage) : base(id, number, maxSpeed)
        {
            CargoTransported = cargoTransported;
            Tonnage = tonnage;
        }
        public Carriage GetBase
        {
            get => new Carriage(id, number, maxSpeed);
        }

        public override void ShowVirtual()
        {
            base.ShowVirtual();
            Console.Write("Грузовой вагон: ");
            Console.WriteLine($"Какой груз можно перевозить {CargoTransported}, тоннаж: {Tonnage}");
        }

        public override string ToString()
        {
            return base.ToString() + $"Какой груз можно перевозить {CargoTransported}, тоннаж: {Tonnage}";
        }
        public void Show()
        {
            base.Show();
            Console.Write("Грузовой вагон: ");
            Console.WriteLine($"Какой груз можно перевозить {CargoTransported}, тоннаж: {Tonnage}");
        }

        public virtual void Init()
        {
            base.Init();
            Console.WriteLine("Введите назначение (какой груз можно перевозить)");
            try
            {
                CargoTransported = Console.ReadLine();
            }
            catch
            {
                CargoTransported = "Метал";
            }
            Console.WriteLine("Введите тоннаж");
            try
            {
                Tonnage = int.Parse(Console.ReadLine());
            }
            catch
            {
                Tonnage = 50;
            }
        }
        public virtual void RandomInit()
        {
            base.RandomInit();
            CargoTransported = cargoTransporteds[rnd.Next(cargoTransporteds.Length)];
            Tonnage = rnd.Next(1, 100);
        }

        public override bool Equals(object obj)
        {
            if (obj == null) return false;
            if (obj is FreightWagon w)
                return CargoTransported == w.CargoTransported && Tonnage == w.Tonnage;
            return false;
            
        }
    }
}
