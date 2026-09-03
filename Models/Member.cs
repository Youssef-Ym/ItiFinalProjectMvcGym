using System.ComponentModel.DataAnnotations;

namespace ItiFinalProjectMvcGym.Models
{
    public class Member
    {
        public int Id { get; set; }

        [Required(ErrorMessage = "اسم العضو مطلوب")]
        public string Name { get; set; } = string.Empty;

        [Required(ErrorMessage = "البريد الإلكتروني مطلوب")]
        [EmailAddress(ErrorMessage = "صيغة البريد الإلكتروني غير صحيحة")]
        public string Email { get; set; } = string.Empty;

        [Phone]
        public string Phone { get; set; } = string.Empty;

        // Navigation Property (M:M عبر Enrollment)
        public ICollection<Enrollment> Enrollments { get; set; } = new List<Enrollment>();
    }
}