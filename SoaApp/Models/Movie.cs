using Newtonsoft.Json;

namespace SoaApp.Core.Models
{
    public class Movie
    {
        [JsonProperty]
        private string Title { get; set; } = string.Empty;

        private IList<MovieScreening> _movieScreenings { get; set; } = new List<MovieScreening>();

        public Movie(string title)
        {
            Title = title;
        }

        public void AddScreening(MovieScreening screening)
        {
            _movieScreenings.Add(screening);
        }

        public override string ToString()
        {
            return Title;
        }
    }
}
