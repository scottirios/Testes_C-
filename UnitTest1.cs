namespace Hotel.Tests
{
    public class ReservaTests
    {
        // Teste para validar criação de reserva com 
        // diferentes entradas
        [Theory]
        [InlineData("2024-08-01", "2024-08-05", 2, true)] // Reserva válida
        [InlineData("2024-08-01", "2024-07-31", 1, false)] // Data de checkin é depois do checkout
        [InlineData("2024-08-01", "2024-08-05", 11, false)] // Excede a capacidade máxima
        public void CriarReserva_DeveValidarEntrada(string dataCheckIn, string dataCheckOut, int quartos, bool resultadoEsperado)
        {
            // Arrange: Criar um hotel com capacidade máxima de 10 quartos
            var hotel = new Hotel(capacidadeMaxima: 10);

            // Act: Tentar criar uma reserva e capturar o resultado
            bool resultado;

            try
            {
                hotel.CriarReserva(DateTime.Parse(dataCheckIn), 
                    DateTime.Parse(dataCheckOut), quartos);
                resultado = true;
            }
            catch (Exception) 
            {
                resultado = false;
            }

            // Assert: Verificar se o resultado foi o esperado
            Assert.Equal(resultado, resultadoEsperado);
        }

        [Fact]
        public void CancelarReserva_DeveRemoverReservaDaLista()
        {
            // Arrange
            var hotel = new Hotel(capacidadeMaxima: 10);
            DateTime checkIn = DateTime.Parse("2024-08-01");
            DateTime checkOut = DateTime.Parse("2024-08-05");
            hotel.CriarReserva(checkIn, checkOut, 2);

            // Act
            hotel.CancelarReserva(checkIn, checkOut);

            // Assert
            Assert.Empty(hotel.ObterReservas());
        }

        [Fact]
        public void CalcularValorTotalReserva_DeveRetornarValorCorreto()
        {
            var hotel = new Hotel(capacidadeMaxima: 10);
            DateTime checkIn = DateTime.Parse("2024-08-01");
            DateTime checkOut = DateTime.Parse("2024-08-05");
            hotel.CriarReserva(checkIn, checkOut, 2);

            // act
            decimal valorTotal = hotel.CalcularValorTotalReserva(
                    checkIn, checkOut, 2, 100m
                );

            // Assert
            Assert.Equal(800m, valorTotal);
        }
    }
}