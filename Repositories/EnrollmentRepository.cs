using ItiFinalProjectMvcGym.Data;
using ItiFinalProjectMvcGym.Models;
using ItiFinalProjectMvcGym.Repositories.Interfaces;

namespace ItiFinalProjectMvcGym.Repositories.Implementations
{
    public class EnrollmentRepository : IEnrollmentRepository
    {
        private readonly ApplicationDbContext _context;

        public EnrollmentRepository(ApplicationDbContext context)
        {
            _context = context;
        }

        public void Add(Enrollment enrollment) => _context.Enrollments.Add(enrollment);

        public bool IsAlreadyEnrolled(int memberId, int classId)
        {
            return _context.Enrollments.Any(e => e.MemberId == memberId && e.GymClassId == classId);
        }

        public void Save() => _context.SaveChanges();
    }
}