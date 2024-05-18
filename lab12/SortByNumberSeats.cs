using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Collections;
using lab10;

namespace ClassLibrary1
{
    public class SortByNumberSeats : IComparer<PassengerWagon>
    {
        public int Compare(PassengerWagon x, PassengerWagon y)
        {
            if (x == null && y == null)
                return 0;
            if (x == null)
                return -1;
            if (y == null)
                return 1;

            // Сравниваем по количеству сидячих мест
            return x.NumberSeats.CompareTo(y.NumberSeats);
        }
    }
}
