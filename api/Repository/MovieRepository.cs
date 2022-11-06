using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using api.Data;
using api.Model;
using Microsoft.EntityFrameworkCore;

namespace api.Repository
{
    public class MovieRepository : IMovieRepository
    {
        private readonly DataContext _context;

        public MovieRepository(DataContext context)
        {
            _context = context;
        }

        public async Task<IEnumerable<Movie>> GetAllMovies()
        {
            return await _context.Movies.ToListAsync();
        }
        public async Task<Movie> GetMovieId(Guid Id)
        {
            return await _context.Movies.FindAsync(Id);
        }
        public async Task<Movie> CreateNewMovie(Movie movie)
        {
            var result = await _context.Movies.AddAsync(movie);
            await _context.SaveChangesAsync();
            return result.Entity;
        }
        public void UpdateMovie(Movie movie)
        {
            _context.Entry(movie).State = EntityState.Modified;
            _context.SaveChanges();
        }
        public async Task<Movie> DeleteMovie(Guid Id)
        {
            var result = await _context.Movies.FirstOrDefaultAsync(x => x.Id == Id);
            if(result != null)
            {
                _context.Movies.Remove(result);
                await _context.SaveChangesAsync();
                return result;
            }
            return null;
        }
    }
}