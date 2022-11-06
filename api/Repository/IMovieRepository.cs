using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using api.Model;

namespace api.Repository
{
    public interface IMovieRepository
    {
        Task<IEnumerable<Movie>> GetAllMovies();
        Task<Movie> GetMovieId(Guid Id);
        Task<Movie> CreateNewMovie(Movie movie);
        void UpdateMovie(Movie movie);
        Task<Movie> DeleteMovie(Guid Id);
    }
}