using ItiFinalProjectMvcGym.Filters;
using ItiFinalProjectMvcGym.Models;
using ItiFinalProjectMvcGym.Repositories.Interfaces;
using Microsoft.AspNetCore.Mvc;

namespace ItiFinalProjectMvcGym.Controllers
{
    [AdminAuthorize]
    public class MemberController : Controller
    {
        private readonly IMemberRepository _memberRepo;

        public MemberController(IMemberRepository memberRepo)
        {
            _memberRepo = memberRepo;
        }

        public IActionResult Index() => View(_memberRepo.GetAll());

        public IActionResult Details(int id)
        {
            var member = _memberRepo.GetById(id);
            if (member == null) return NotFound();
            return View(member);
        }

        public IActionResult Create() => View();

        [HttpPost]
        public IActionResult Create(Member member)
        {
            if (ModelState.IsValid)
            {
                _memberRepo.Add(member);
                _memberRepo.Save();
                return RedirectToAction(nameof(Index));
            }
            return View(member);
        }

        public IActionResult Edit(int id)
        {
            var member = _memberRepo.GetById(id);
            if (member == null) return NotFound();
            return View(member);
        }

        [HttpPost]
        public IActionResult Edit(Member member)
        {
            if (ModelState.IsValid)
            {
                _memberRepo.Update(member);
                _memberRepo.Save();
                return RedirectToAction(nameof(Index));
            }
            return View(member);
        }

        public IActionResult Delete(int id)
        {
            _memberRepo.Delete(id);
            _memberRepo.Save();
            return RedirectToAction(nameof(Index));
        }
    }
}