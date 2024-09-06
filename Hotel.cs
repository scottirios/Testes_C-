using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Hotel
{
    public class Hotel
    {
        private int _capacidadeMaxima;
        private List<Reserva> _reservas = new List<Reserva>();

        public Hotel(int capacidadeMaxima)
        { 
            _capacidadeMaxima = capacidadeMaxima;
        }

        public void CriarReserva(DateTime dataCheckIn, 
            DateTime dataCheckOut, int quartos)
        {
            // Validações de entrada
            if (dataCheckIn >= dataCheckOut) 
            {
                throw new ArgumentException("Data de checkin deve ser " +
                    "anterior a data de checkout");
            }

            if(quartos > _capacidadeMaxima)
            {
                throw new InvalidOperationException("Numero de quartos excede" +
                    "a capacidade maxima");
            }

            // Criar uma nova reserva e adicionar à lista
            var reserva = new Reserva(dataCheckIn, dataCheckOut, quartos);
            _reservas.Add(reserva);
        }

        public void CancelarReserva(DateTime checkIn, DateTime checkOut)
        {
            // Remove todas as reservas que coincidem com as datas
            _reservas.RemoveAll(r => r.DataCheckIn == checkIn && 
                r.DataCheckOut == checkOut);
        }

        public List<Reserva> ObterReservas()
        {
            return _reservas;
        }

        public decimal CalcularValorTotalReserva(DateTime checkIn, 
            DateTime checkOut, int quartos, decimal precoPorQuarto)
        {
            int noites = (checkOut - checkIn).Days;
            return noites * quartos * precoPorQuarto;
        }
    }
}
