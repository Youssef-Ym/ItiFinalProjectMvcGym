using ItiFinalProjectMvcGym.Filters;
using ItiFinalProjectMvcGym.Models;
using ItiFinalProjectMvcGym.Repositories.Interfaces;
using Microsoft.AspNetCore.Mvc;

namespace ItiFinalProjectMvcGym.Controllers
{
    [AdminAuthorize]
    public class TrainerController : Controller
    {
        private readonly ITrainerRepository _trainerRepo;

        public TrainerController(ITrainerRepository trainerRepo)
        {
            _trainerRepo = trainerRepo;
        }

        public IActionResult Index() => View(_trainerRepo.GetAll());

        public IActionResult Details(int id)
        {
            var trainer = _trainerRepo.GetById(id);
            if (trainer == null) return NotFound();
            return View(trainer);
        }

        public IActionResult Create() => View();

        [HttpPost]
        public IActionResult Create(Trainer trainer)
        {
            if (ModelState.IsValid)
            {
                _trainerRepo.Add(trainer);
                _trainerRepo.Save();
                return RedirectToAction(nameof(Index));
            }
            return View(trainer);
        }

        public IActionResult Edit(int id)
        {
            var trainer = _trainerRepo.GetById(id);
            if (trainer == null) return NotFound();
            return View(trainer);
        }

        [HttpPost]
        public IActionResult Edit(Trainer trainer)
        {
            if (ModelState.IsValid)
            {
                _trainerRepo.Update(trainer);
                _trainerRepo.Save();
                return RedirectToAction(nameof(Index));
            }
            return View(trainer);
        }

        public IActionResult Delete(int id)
        {
            _trainerRepo.Delete(id);
            _trainerRepo.Save();
            return RedirectToAction(nameof(Index));
        }
    }
}