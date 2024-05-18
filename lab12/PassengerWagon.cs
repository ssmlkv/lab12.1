﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Net.NetworkInformation;
using System.Numerics;
using System.Text;
using System.Threading.Tasks;

namespace lab10
{
    public class PassengerWagon : Carriage, IComparable<PassengerWagon>
    {
        protected int numberBeds;
        protected int numberSeats;

        public int NumberBeds
        {
            get => numberBeds;
            set
            {
                if (value < 0)
                    numberBeds = 0;
                else
                    numberBeds = value;
            }
        }
        public int NumberSeats
        {
            get => numberSeats;
            set
            {
                if (value < 0)
                    numberSeats = 0;
                else
                    numberSeats = value;
            }
        }

        public PassengerWagon() : base()
        {
            NumberBeds = 50;
            NumberSeats = 50;
        }
        public PassengerWagon(IdNumber id, int number, int maxSpeed, int numberBeds, int numberSeats):base(id,number, maxSpeed) 
        {
            NumberBeds = numberBeds;
            NumberSeats = numberSeats;
        }

        public void Show()
        {
            base.Show();
            Console.Write("Пассажирский вагон: ");
            Console.WriteLine($"Количество сидячих мест: {NumberSeats}, Количество койко-мест: {NumberBeds}");
        }

        public override void ShowVirtual()
        {
            base.ShowVirtual();
            Console.Write("Пассажирский вагон: ");
            Console.WriteLine($"Количество сидячих мест: {NumberSeats}, Количество койко-мест: {NumberBeds}");
        }

        public override void Init()
        {
            base.Init();
            Console.WriteLine("Введите количество лежачих мест");
            try
            {
                NumberBeds = int.Parse(Console.ReadLine());
            }
            catch
            {
                NumberBeds = 50;
            }
            Console.WriteLine("Введите количество сидячих мест");
            try
            {
                NumberSeats = int.Parse(Console.ReadLine());
            }
            catch
            {
                NumberSeats = 50;
            }
        }
        public override void RandomInit()
        {
            base.RandomInit();
            NumberBeds = rnd.Next(1, 100);
            NumberSeats = rnd.Next(1, 100);
        }

        public override bool Equals(object obj)
        {
            if (obj == null) return false;
            if (obj is PassengerWagon w)
                return base.Equals(obj) && NumberBeds == w.NumberBeds && NumberSeats == w.NumberSeats;
            return false;
        }

        public object ShallowCopy()
        {
            return this.MemberwiseClone();
        }

        public void ShowBeds()
        {
            Console.WriteLine("Сумма койко-мест всех вагонов поезда " + NumberBeds);
        }

        public int CompareTo(PassengerWagon other)
        {
            if (other == null)
                return 1;

            // Сравниваем по количеству лежачих мест
            return this.NumberBeds.CompareTo(other.NumberBeds);
        }
    }
}
