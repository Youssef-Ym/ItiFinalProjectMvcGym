using System.ComponentModel.DataAnnotations;

namespace ItiFinalProjectMvcGym.Models
{
    public class Trainer
    {
        public int Id { get; set; }

        [Required(ErrorMessage = "اسم المدرب مطلوب")]
        public string Name { get; set; } = string.Empty;

        [Required(ErrorMessage = "التخصص مطلوب")]
        public string Specialization { get; set; } = string.Empty;

     
        public ICollection<GymClass> GymClasses { get; set; } = new List<GymClass>();
    }
}