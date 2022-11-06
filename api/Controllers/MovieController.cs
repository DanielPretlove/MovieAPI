using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Threading.Tasks;
using api.Model;
using api.Repository;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Logging;

namespace api.Controllers
{
    [Route("[controller]")]
    public class MovieController : Controller
    {   
        private readonly IMovieRepository _repository;
        public MovieController(IMovieRepository repository)
        {
            _repository = repository;
        }

        [HttpGet]
        public async Task<ActionResult<Movie>> GetAllMovie()
        {
            var result = await _repository.GetAllMovies();
            return Ok(result);
        }

        [HttpGet("{id:Guid}")]
        public async Task<ActionResult<Movie>> GetMovieById(Guid Id) 
        {
            var result = await _repository.GetMovieId(Id);
            if(result == null)
            {
                return NotFound();
            }
            return result;
        }

        [HttpPost]
        public async Task<ActionResult<Movie>> CreateNewMovie(Movie movie)
        {
            return await _repository.CreateNewMovie(movie);
        }

        [HttpPut("{id}")]
        public IActionResult UpdateMovie(Movie movie)
        {
            _repository.UpdateMovie(movie);
            return Ok();
        }

        [HttpDelete("{id:Guid}")]
        public async Task<ActionResult<Movie>> CreateNewMovie(Guid Id)
        {
            try
            {
                var result = await _repository.GetMovieId(Id);

                if(result == null)
                {
                    return NotFound($"Movie with Id = {Id} not found");
                }

                return await _repository.DeleteMovie(Id);
            }
            catch (Exception ex)
            {
                return StatusCode(StatusCodes.Status500InternalServerError, ex.Message);
            }
        }
    }
}