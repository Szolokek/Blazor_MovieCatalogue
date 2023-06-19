using MovieCatalogue.Data.Person;
using MovieCatalogue.Data.Search;
using MovieCatalogue.Data.Movie;
using MovieCatalogue.Data.Tv;

namespace MovieCatalogue.Services.MovieService
{
    public interface IMovieService
    {
        //Search Calls
        Task<ResultPage> MultiSearch(string search_string);

        //Movie Calls
        Task<MovieDetails> GetMovieDetails(int id);
        Task<MovieCredits> GetMovieCredits(int id);

        //Person Calls
        Task<PersonDetails> GetPersonDetails(int id);
        Task<PersonCombinedCredits> GetPersonCombinedCredits(int id);
     

        //Tv Series Calls
        Task<TvDetails> GetTvDetails(int id);
        Task<TvCredits> GetTvCredits(int id);

        //Trending
        Task<ResultPage> GetTrendingWeekAsync();
        
    }
}
