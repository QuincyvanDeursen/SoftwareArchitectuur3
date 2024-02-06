namespace SoaApp.Core.Models
{
    public class MovieScreening
    {
        private DateTime _dateAndTime;
        private decimal _pricePerSeat;
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
