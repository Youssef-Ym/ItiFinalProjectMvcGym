using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace ItiFinalProjectMvcGym.Models
{
    public class Enrollment
    {
        public int Id { get; set; }

        public int MemberId { get; set; }
        [ForeignKey("MemberId")]
        public Member? Member { get; set; }

        public int GymClassId { get; set; }
        [ForeignKey("GymClassId")]
        public GymClass? GymClass { get; set; }

        public DateTime EnrollmentDate { get; set; } = DateTime.Now;
    }
}