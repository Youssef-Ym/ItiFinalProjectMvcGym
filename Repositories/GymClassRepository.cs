using ItiFinalProjectMvcGym.Data;
using ItiFinalProjectMvcGym.Models;
using ItiFinalProjectMvcGym.Repositories.Interfaces;
using Microsoft.EntityFrameworkCore;

namespace ItiFinalProjectMvcGym.Repositories.Implementations
{
    public class GymClassRepository : IGymClassRepository
    {
        private readonly ApplicationDbContext _context;

        public GymClassRepository(ApplicationDbContext context)
        {
            _context = context;
        }

        public IEnumerable<GymClass> GetAllWithTrainers()
        {
            return _context.GymClasses.Include(c => c.Trainer).ToList();
        }

        public IEnumerable<GymClass> GetByTrainerId(int trainerId)
        {
            return _context.GymClasses
                .Include(c => c.Trainer)
                .Where(c => c.TrainerId == trainerId)
                .ToList();
        }

        public GymClass? GetByIdWithDetails(int id)
        {
            return _context.GymClasses
                .Include(c => c.Trainer)
                .Include(c => c.Enrollments)
                    .ThenInclude(e => e.Member)
                .FirstOrDefault(c => c.Id == id);
        }

        public GymClass? GetById(int id) => _context.GymClasses.Find(id);

        public void Add(GymClass gymClass) => _context.GymClasses.Add(gymClass);

        public void Update(GymClass gymClass) => _context.GymClasses.Update(gymClass);

        public void Delete(int id)
        {
            var gymClass = GetById(id);
            if (gymClass != null) _context.GymClasses.Remove(gymClass);
        }

        public void Save() => _context.SaveChanges();
    }
}