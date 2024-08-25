using Microsoft.AspNetCore.Mvc;
using ProvaMVC.Data.Repositories.Interfaces;
using ProvaMVC.Models;

namespace ProvaMVC.Controllers
{
    public class ProfessorController : Controller
    {
        private readonly IProfessorRepository _professorRepository;

        public ProfessorController(IProfessorRepository professorRepository)
        {
            _professorRepository = professorRepository;
        }

        public async Task<IActionResult> Index()
        {
            var professores = await _professorRepository.GetAllAsync();
            return View(professores);
        }

        public async Task<IActionResult> Details(Guid id)
        {
            var professor = await _professorRepository.GetByIdAsync(id);
            if (professor == null)
                return NotFound();
            
            return View(professor);
        }

        public IActionResult Create()
        {
            return View();
        }

        [HttpPost]
        public async Task<IActionResult> Create(Professor professor)
        {
            if (ModelState.IsValid)
            {
                await _professorRepository.AddAsync(professor);
                return RedirectToAction(nameof(Index));
            }
            return View(professor);
        }

        public async Task<IActionResult> Edit(Guid id)
        {
            var professor = await _professorRepository.GetByIdAsync(id);
            if (professor == null)
                return NotFound();
            
            return View(professor);
        }

        [HttpPost]
        public async Task<IActionResult> Edit(Guid id, Professor professor)
        {
            if (id != professor.Id)
                return NotFound();

            if (ModelState.IsValid)
            {
                await _professorRepository.UpdateAsync(professor);
                return RedirectToAction(nameof(Index));
            }
            return View(professor);
        }

        public async Task<IActionResult> Delete(Guid id)
        {
            var professor = await _professorRepository.GetByIdAsync(id);
            if (professor == null)
                return NotFound();
            
            return View(professor);
        }

        [HttpPost, ActionName("Delete")]
        public async Task<IActionResult> DeleteConfirmed(Guid id)
        {
            await _professorRepository.DeleteAsync(id);
            return RedirectToAction(nameof(Index));
        }
    }
}
