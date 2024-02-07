using Newtonsoft.Json;

namespace SoaApp.Core.Models
{
    public class MovieScreening
    {
        [JsonProperty]
        private DateTime _dateAndTime;
        [JsonProperty]
        private decimal _pricePerSeat;
        [JsonProperty]
        private Movie _movie;

        public MovieScreening(Movie movie, DateTime dateAndTime, decimal pricePerSeat)
        {
            _dateAndTime = dateAndTime;
            _pricePerSeat = pricePerSeat;
            _movie = movie;
        }

        public decimal GetPricePerSeat()
        {
            return _pricePerSeat;
        }

        public DateTime GetDateTime()
        {
            return _dateAndTime;
        }

        public override string ToString()
        {
            return $"{_movie} (plays at {_dateAndTime} and costs {_pricePerSeat} per seat)";
        }
    }
}
