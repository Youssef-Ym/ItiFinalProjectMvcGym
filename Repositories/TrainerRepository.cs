using ItiFinalProjectMvcGym.Data;
using ItiFinalProjectMvcGym.Models;
using ItiFinalProjectMvcGym.Repositories.Interfaces;

namespace ItiFinalProjectMvcGym.Repositories.Implementations
{
    public class TrainerRepository : ITrainerRepository
    {
        private readonly ApplicationDbContext _context;

        public TrainerRepository(ApplicationDbContext context)
        {
            _context = context;
        }

        public IEnumerable<Trainer> GetAll() => _context.Trainers.ToList();

        public Trainer? GetById(int id) => _context.Trainers.Find(id);

        public void Add(Trainer trainer) => _context.Trainers.Add(trainer);

        public void Update(Trainer trainer) => _context.Trainers.Update(trainer);

        public void Delete(int id)
        {
            var trainer = GetById(id);
            if (trainer != null) _context.Trainers.Remove(trainer);
        }

        public void Save() => _context.SaveChanges();
    }
}