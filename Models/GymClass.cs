using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace ItiFinalProjectMvcGym.Models
{
    public class GymClass
    {
        public int Id { get; set; }

        [Required(ErrorMessage = "اسم الكلاس مطلوب")]
        public string Name { get; set; } = string.Empty;

        public string Description { get; set; } = string.Empty;

        [Required(ErrorMessage = "المواعيد مطلوبة")]
        public string Schedule { get; set; } = string.Empty;

        // Foreign Key
        public int TrainerId { get; set; }

        // Navigation Properties
        [ForeignKey("TrainerId")]
        public Trainer? Trainer { get; set; }

        public ICollection<Enrollment> Enrollments { get; set; } = new List<Enrollment>();
    }
}