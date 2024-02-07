using Newtonsoft.Json;
using SoaApp.Core.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Text.Json;
using System.Text.Json.Nodes;
using System.Threading.Tasks;

namespace SoaApp.Core.Tests
{
    public class ExportTests
    {
        [Theory]
        [InlineData(true, true)]
        public void Export_To_TXT_Creates_File_With_TXT_Contents(bool studentOrder, bool premium)
        {
            Movie movie = new("shrek");

            // weekday 
            MovieScreening movieScreening = new(movie, new DateTime(2024, 2, 6), 10);
            movie.AddScreening(movieScreening);

            MovieTicket ticket1 = new MovieTicket(movieScreening, 1, 10, premium);
            Order order = new(1, studentOrder);
            order.AddSeatReservation(ticket1);
            order.Export(TicketExportFormat.PLAINTEXT);

            var file = File.ReadAllLines("C:/Users/Gebruiker/Downloads/Order.Txt");
            var ticketToCheck = file[0];

            Assert.Equal("ticket: 1 " + ticket1.ToString(), ticketToCheck);
        }

        [Theory]
        [InlineData(true, true)]
        public void Export_To_JSON_Creates_File_With_JSON_Contents(bool studentOrder, bool premium)
        {
            Movie movie = new("shrek");

            // weekday 
            MovieScreening movieScreening = new(movie, new DateTime(2024, 2, 6), 10);
            movie.AddScreening(movieScreening);

            MovieTicket ticket1 = new MovieTicket(movieScreening, 1, 10, premium);
            Order order = new(1, studentOrder);
            order.AddSeatReservation(ticket1);
            order.Export(TicketExportFormat.JSON);
            var file = File.ReadAllLines("C:/Users/Gebruiker/Downloads/Order.Json");

            Assert.Equal(JsonConvert.SerializeObject(order), file[0]);
        }
    }
}
