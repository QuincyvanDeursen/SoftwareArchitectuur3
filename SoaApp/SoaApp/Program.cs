using SoaApp.Core.Models;

Movie movie = new("shrek");

//weekend
MovieScreening movieScreening = new(movie, new DateTime(2024, 3, 10), 10);

// weekday 
// MovieScreening movieScreening = new(movie, new DateTime(2024, 2, 6), 10);
movie.AddScreening(movieScreening);



// Creating multiple instances of MovieTicket with dummy data
MovieTicket ticket1 = new MovieTicket(movieScreening, 1, 10, true);
MovieTicket ticket2 = new MovieTicket(movieScreening, 2, 9, true);
MovieTicket ticket3 = new MovieTicket(movieScreening, 3, 8, false);
MovieTicket ticket4 = new MovieTicket(movieScreening, 4, 7, false);
MovieTicket ticket5 = new MovieTicket(movieScreening, 5, 6, false);
MovieTicket ticket6 = new MovieTicket(movieScreening, 6, 5, false);
MovieTicket ticket7 = new MovieTicket(movieScreening, 7, 4, false);

Order order = new(1, true);
order.AddSeatReservation(ticket1);
order.AddSeatReservation(ticket2);
order.AddSeatReservation(ticket3);
order.AddSeatReservation(ticket4);
order.AddSeatReservation(ticket5);
order.AddSeatReservation(ticket6);
order.AddSeatReservation(ticket7);

var price = order.CalculatePrice();
Console.WriteLine(price);
order.Export(TicketExportFormat.JSON);


