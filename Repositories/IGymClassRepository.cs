using ItiFinalProjectMvcGym.Models;

namespace ItiFinalProjectMvcGym.Repositories.Interfaces
{
    public interface IGymClassRepository
    {
        IEnumerable<GymClass> GetAllWithTrainers();
        IEnumerable<GymClass> GetByTrainerId(int trainerId);
        GymClass? GetByIdWithDetails(int id);
        GymClass? GetById(int id);
        void Add(GymClass gymClass);
        void Update(GymClass gymClass);
        void Delete(int id);
        void Save();
    }
}