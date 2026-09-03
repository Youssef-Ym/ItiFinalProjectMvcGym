using ItiFinalProjectMvcGym.Models;

namespace ItiFinalProjectMvcGym.Repositories.Interfaces
{
    public interface ITrainerRepository
    {
        IEnumerable<Trainer> GetAll();
        Trainer? GetById(int id);
        void Add(Trainer trainer);
        void Update(Trainer trainer);
        void Delete(int id);
        void Save();
    }
}