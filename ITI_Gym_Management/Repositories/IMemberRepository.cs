using ItiFinalProjectMvcGym.Models;

namespace ItiFinalProjectMvcGym.Repositories.Interfaces
{
    public interface IMemberRepository
    {
        IEnumerable<Member> GetAll();
        Member? GetById(int id);
        void Add(Member member);
        void Update(Member member);
        void Delete(int id);
        void Save();
    }
}