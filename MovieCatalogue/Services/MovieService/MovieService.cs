using MovieCatalogue.Data.Movie;
using MovieCatalogue.Data.Person;
using MovieCatalogue.Data.Search;
using MovieCatalogue.Data.Tv;
using MovieCatalogue.Pages;
using System.Diagnostics;
using static System.Net.WebRequestMethods;

namespace MovieCatalogue.Services.MovieService
{
    public class MovieService : IMovieService
    {
        private readonly HttpClient http;
        private readonly string api_key = "cb81f7c9f32c4d72cb9d2fcf8e25349c";
        private readonly string site = "https://api.themoviedb.org/3";
        public MovieService(HttpClient http)
        {
            this.http = http;
        }

        public async Task<ResultPage> MultiSearch(string search_string)
        {
            string uri = Uri.EscapeDataString(search_string);
            var result = await http.GetFromJsonAsync<ResultPage>(site+"/search/multi?api_key="+api_key+"&language=en-US&query="+uri+"&page=1&include_adult=false");
            return result;
        }

        public async Task<MovieDetails> GetMovieDetails(int id)
        {
            var result = await http.GetFromJsonAsync<MovieDetails>(site+"/movie/"+id+"?api_key="+api_key+"&language=en-US");
            return result;
        }

        public async Task<MovieCredits> GetMovieCredits(int id)
        {
            var result = await http.GetFromJsonAsync<MovieCredits>(site+"/movie/"+id+"/credits?api_key="+api_key+"&language=en-US");
            return result;
        }

        public async Task<PersonDetails> GetPersonDetails(int id)
        {
            var result = await http.GetFromJsonAsync<PersonDetails>(site+"/person/"+id+ "?api_key="+api_key+"&language=en-US");
            return result;
        }

        public async Task<PersonCombinedCredits> GetPersonCombinedCredits(int id)
        {
            var result = await http.GetFromJsonAsync<PersonCombinedCredits>(site+"/person/"+id+"/combined_credits?api_key="+api_key+"&language=en-US");
            return result;
        }

        public async Task<TvDetails> GetTvDetails(int id)
        {
            var result = await http.GetFromJsonAsync<TvDetails>(site+"/tv/"+id+"?api_key=" + api_key + "&language=en-US");
            return result;
        }

        public async Task<TvCredits> GetTvCredits(int id)
        {
            var result = await http.GetFromJsonAsync<TvCredits>(site+"/tv/"+id+ "/credits?api_key=" + api_key + "&language=en-US");
            return result;
        }

        public async Task<ResultPage> GetTrendingWeekAsync()
        {
            var result = await http.GetFromJsonAsync<ResultPage>(site + "/trending/all/week?api_key=" + api_key + "&language=en-US");
            return result;
        }
    }
}
