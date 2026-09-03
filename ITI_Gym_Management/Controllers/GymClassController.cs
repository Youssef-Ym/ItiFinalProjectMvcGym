using ItiFinalProjectMvcGym.Filters;
using ItiFinalProjectMvcGym.Models;
using ItiFinalProjectMvcGym.Repositories.Interfaces;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;

namespace ItiFinalProjectMvcGym.Controllers
{
    public class GymClassController : Controller
    {
        private readonly IGymClassRepository _gymClassRepo;
        private readonly ITrainerRepository _trainerRepo;

        public GymClassController(IGymClassRepository gymClassRepo, ITrainerRepository trainerRepo)
        {
            _gymClassRepo = gymClassRepo;
            _trainerRepo = trainerRepo;
        }

        // 1. Trainer/Public Page: Classes list with Trainer dropdown filter
        public IActionResult Index()
        {
            ViewBag.Trainers = new SelectList(_trainerRepo.GetAll(), "Id", "Name");
            var classes = _gymClassRepo.GetAllWithTrainers();
            return View(classes);
        }

        // AJAX Action to filter classes by trainer
        public IActionResult GetClassesByTrainer(int? trainerId)
        {
            IEnumerable<GymClass> classes;

            if (trainerId.HasValue && trainerId > 0)
            {
                classes = _gymClassRepo.GetByTrainerId(trainerId.Value);
            }
            else
            {
                classes = _gymClassRepo.GetAllWithTrainers();
            }

            return PartialView("_ClassesTablePartial", classes);
        }

        // Class Details Page
        public IActionResult Details(int id)
        {
            var gymClass = _gymClassRepo.GetByIdWithDetails(id);
            if (gymClass == null) return NotFound();

            return View(gymClass);
        }

        // --- Admin CRUD Actions ---

        [AdminAuthorize]
        public IActionResult Manage()
        {
            var classes = _gymClassRepo.GetAllWithTrainers();
            return View(classes);
        }

        [AdminAuthorize]
        [HttpGet]
        public IActionResult Create()
        {
            ViewBag.TrainerId = new SelectList(_trainerRepo.GetAll(), "Id", "Name");
            return View();
        }

        [AdminAuthorize]
        [HttpPost]
        public IActionResult Create(GymClass gymClass)
        {
            if (ModelState.IsValid)
            {
                _gymClassRepo.Add(gymClass);
                _gymClassRepo.Save();
                return RedirectToAction(nameof(Manage));
            }
            ViewBag.TrainerId = new SelectList(_trainerRepo.GetAll(), "Id", "Name", gymClass.TrainerId);
            return View(gymClass);
        }

        [AdminAuthorize]
        [HttpGet]
        public IActionResult Edit(int id)
        {
            var gymClass = _gymClassRepo.GetById(id);
            if (gymClass == null) return NotFound();

            ViewBag.TrainerId = new SelectList(_trainerRepo.GetAll(), "Id", "Name", gymClass.TrainerId);
            return View(gymClass);
        }

        [AdminAuthorize]
        [HttpPost]
        public IActionResult Edit(GymClass gymClass)
        {
            if (ModelState.IsValid)
            {
                _gymClassRepo.Update(gymClass);
                _gymClassRepo.Save();
                return RedirectToAction(nameof(Manage));
            }
            ViewBag.TrainerId = new SelectList(_trainerRepo.GetAll(), "Id", "Name", gymClass.TrainerId);
            return View(gymClass);
        }

        [AdminAuthorize]
        public IActionResult Delete(int id)
        {
            _gymClassRepo.Delete(id);
            _gymClassRepo.Save();
            return RedirectToAction(nameof(Manage));
        }
    }
}