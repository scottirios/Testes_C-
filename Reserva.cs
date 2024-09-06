using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Hotel
{
    public class Reserva
    {
        public DateTime DataCheckIn { get; private set; }
        public DateTime DataCheckOut { get; private set; }
        public int Quartos { get; private set; }

        public Reserva(DateTime dataCheckIn, DateTime dataCheckOut, int quartos)
        {
            DataCheckIn = dataCheckIn;
            DataCheckOut = dataCheckOut;
            Quartos = quartos;
        }
    }
}
