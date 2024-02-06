using SoaApp.Core.Models;

namespace SoaApp.Core.Tests
{
    public class OrderTests
    {
        [Theory]
        [InlineData(true, true, 12)]
        [InlineData(true, false, 10)]
        [InlineData(false, true, 13)]
        [InlineData(false, false, 10)]
        public void Calculate_Ticket_Price_for_one_person(bool studentOrder, bool premium, decimal result)
        {
            Movie movie = new("shrek");

            // weekday 
            MovieScreening movieScreening = new(movie, new DateTime(2024, 2, 6), 10);
            movie.AddScreening(movieScreening);

            MovieTicket ticket1 = new MovieTicket(movieScreening, 1, 10, premium);
            Order order = new(1, studentOrder);
            order.AddSeatReservation(ticket1);

            var price = order.CalculatePrice();

            Assert.Equal(result, price);

        }

        [Theory]
        [InlineData(false, true, false, 6, 30)]
        [InlineData(false, false, false, 6, 30)]
        [InlineData(false, true, false, 3, 20)]
        [InlineData(true, false, false, 6, 54)]
        [InlineData(true, true, false, 6, 30)]
        [InlineData(true, false, false, 4, 40)]

        public void Calculate_Ticket_Price_for_group(bool weekend, bool studentOrder, bool premium, int ticketAmount, decimal result)
        {
            Movie movie = new("shrek");
           
            MovieScreening movieScreening;

            if (weekend) movieScreening = new(movie, new DateTime(2024, 2, 10), 10);
            else movieScreening = new(movie, new DateTime(2024, 2, 6), 10);
            // weekday 

            movie.AddScreening(movieScreening);

            Order order = new(1, studentOrder);

            for (int i = 0; i < ticketAmount; i++) {
                MovieTicket ticket1 = new MovieTicket(movieScreening, 1, 10, premium);
                order.AddSeatReservation(ticket1);
            }

            var price = order.CalculatePrice();

            Assert.Equal(result, price);

        }
    }
}