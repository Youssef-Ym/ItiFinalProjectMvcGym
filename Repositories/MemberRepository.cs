using ItiFinalProjectMvcGym.Data;
using ItiFinalProjectMvcGym.Models;
using ItiFinalProjectMvcGym.Repositories.Interfaces;

namespace ItiFinalProjectMvcGym.Repositories.Implementations
{
    public class MemberRepository : IMemberRepository
    {
        private readonly ApplicationDbContext _context;

        public MemberRepository(ApplicationDbContext context)
        {
            _context = context;
        }

        public IEnumerable<Member> GetAll() => _context.Members.ToList();

        public Member? GetById(int id) => _context.Members.Find(id);

        public void Add(Member member) => _context.Members.Add(member);

        public void Update(Member member) => _context.Members.Update(member);

        public void Delete(int id)
        {
            var member = GetById(id);
            if (member != null) _context.Members.Remove(member);
        }

        public void Save() => _context.SaveChanges();
    }
}