namespace SoaApp.Core.Models
{
    public class MovieTicket
    {
        private int _rowNr;
        private int _seatNr;
        private bool _isPremium;
        private MovieScreening MovieScreening;

        public MovieTicket(MovieScreening movieScreening, int rowNr, int seatNr, bool isPremiumReservation)
        {

            MovieScreening = movieScreening;
            _rowNr = rowNr;
            _seatNr = seatNr;
            _isPremium = isPremiumReservation;

        }

        public DateTime GetMovieScreeningDate()
        {
            return MovieScreening.GetDateTime();
        }

        public bool IsPremiumTicket()
        {
            return _isPremium;
        }

        public decimal GetPrice()
        {
            return MovieScreening.GetPricePerSeat();
        }

        public override string ToString()
        {
            return "ticket: " + MovieScreening.ToString();
        }

    }
}
