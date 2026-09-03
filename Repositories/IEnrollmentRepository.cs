using ItiFinalProjectMvcGym.Models;

namespace ItiFinalProjectMvcGym.Repositories.Interfaces
{
    public interface IEnrollmentRepository
    {
        void Add(Enrollment enrollment);
        bool IsAlreadyEnrolled(int memberId, int classId);
        void Save();
    }
}