using Code9.Domain.Interfaces;
using Code9.Domain.Models;
using Microsoft.EntityFrameworkCore;
using System.Reflection.Emit;

namespace Code9.Infrastructure.Repositories
{
    public class CinemaRepository : ICinemaRepository
    {
        private readonly CinemaDbContext _dbContext;

        public CinemaRepository(CinemaDbContext dbContext)
        {
            _dbContext = dbContext;
        }

        public async Task<List<Cinema>> GetAllCinemas()
        {
            return await _dbContext.Cinemas.ToListAsync();
        }

        public async Task<Cinema> addCinema(Cinema newCinema)
        {
            _dbContext.Cinemas.Add(newCinema);
            return newCinema;
        }

        public async Task<Cinema> updateCinema(Cinema newCinema)
        {
            _dbContext.Cinemas.Update(newCinema);
            return newCinema;
        }
    }
}