namespace MovieCatalogue.Data.Search
{
    public class ResultPage
    {
        public int page { get; set; }
        public List<Movie>? results { get; set; }
        public int total_pages { get; set; }
        public int total_results { get; set; }
    }
}
