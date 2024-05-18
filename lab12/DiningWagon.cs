using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace lab10
{
    public class DiningWagon : PassengerWagon
    {
        public string operatingMode;
        protected int quantitybeds;

        public string OperatingMode
        {
            get => operatingMode;
            set
            {
                if (!string.IsNullOrEmpty(value) && ValidateOperatingMode(value))
                    operatingMode = value;
                else
                    operatingMode = "Unknown";
            }
        }

        public int Quantitybeds
        {
            get => quantitybeds;
            set
            {
                if (value < 0)
                    quantitybeds = 0;
                else
                    quantitybeds = value;
            }
        }
        

        public DiningWagon(): base()
        {
            NumberBeds = 0;
            OperatingMode = "";
        }
        public DiningWagon(IdNumber id, int number, int maxSpeed, string operatingMode, int numberBeds, int numberSeats) : base(id, number, maxSpeed, numberBeds, numberSeats)
        {
            OperatingMode = operatingMode;
            NumberBeds = 0;
        }

        public void Show()
        {
            base.Show();
            Console.Write("Вагон-ресторан: ");
            Console.WriteLine($"Режим работы: {OperatingMode}, Количество койко-мест: {NumberBeds}");
        }
        public override void ShowVirtual()
        {
            Console.Write("Вагон-ресторан: ");
            Console.WriteLine($"Количество сидячих мест: {NumberSeats}, Количество койко-мест: {NumberBeds}");
            Console.WriteLine($"Режим работы: {OperatingMode}, Количество койко-мест: {NumberBeds}");
        }

        public virtual void Init()
        {
            base.Init();
            Console.WriteLine("Введите режим работы");
            try
            {
                OperatingMode = Console.ReadLine();
            }
            catch
            {
                OperatingMode = "12:00-23:00";
            }
        }
        public virtual void RandomInit()
        {
            id.Id = rnd.Next(0, 100);
            NumberBeds = 0;
            NumberSeats = rnd.Next(1, 10);
            Number = rnd.Next(1, 100);
            MaxSpeed = rnd.Next(1, 200);
            OperatingMode = "12-23";
        }
        private bool ValidateOperatingMode(string mode)
        {
            foreach (char c in mode)
            {
                if (!char.IsDigit(c) && c != ':' && c != '-')
                    return false;
            }
            return true;
        }
    }
}
