using Newtonsoft.Json;

namespace SoaApp.Core.Models
{
    public class MovieTicket
    {
        [JsonProperty]
        private int _rowNr;
        [JsonProperty]
        private int _seatNr;
        [JsonProperty]
        private bool _isPremium;
        [JsonProperty]
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
            return $"row: {_rowNr} seat: {_seatNr} movie: {MovieScreening.ToString()}";
        }

    }
}
