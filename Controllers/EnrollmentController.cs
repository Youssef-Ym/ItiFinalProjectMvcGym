using ItiFinalProjectMvcGym.Filters;
using ItiFinalProjectMvcGym.Models;
using ItiFinalProjectMvcGym.Repositories.Interfaces;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;

namespace ItiFinalProjectMvcGym.Controllers
{
    [AdminAuthorize]
    public class EnrollmentController : Controller
    {
        private readonly IEnrollmentRepository _enrollmentRepo;
        private readonly IMemberRepository _memberRepo;
        private readonly IGymClassRepository _gymClassRepo;

        public EnrollmentController(IEnrollmentRepository enrollmentRepo, IMemberRepository memberRepo, IGymClassRepository gymClassRepo)
        {
            _enrollmentRepo = enrollmentRepo;
            _memberRepo = memberRepo;
            _gymClassRepo = gymClassRepo;
        }

        [HttpGet]
        public IActionResult Create()
        {
            ViewBag.MemberId = new SelectList(_memberRepo.GetAll(), "Id", "Name");
            ViewBag.GymClassId = new SelectList(_gymClassRepo.GetAllWithTrainers(), "Id", "Name");
            return View(new Enrollment { EnrollmentDate = DateTime.Now });
        }

        [HttpPost]
        public IActionResult Create(Enrollment enrollment)
        {
            if (_enrollmentRepo.IsAlreadyEnrolled(enrollment.MemberId, enrollment.GymClassId))
            {
                ModelState.AddModelError("", "This member is already enrolled in the selected gym class.");
            }

            if (ModelState.IsValid)
            {
                _enrollmentRepo.Add(enrollment);
                _enrollmentRepo.Save();
                return RedirectToAction("Index", "GymClass");
            }

            ViewBag.MemberId = new SelectList(_memberRepo.GetAll(), "Id", "Name", enrollment.MemberId);
            ViewBag.GymClassId = new SelectList(_gymClassRepo.GetAllWithTrainers(), "Id", "Name", enrollment.GymClassId);
            return View(enrollment);
        }
    }
}