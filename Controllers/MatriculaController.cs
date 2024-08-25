using Microsoft.AspNetCore.Mvc;
using ProvaMVC.Data.Repositories.Interfaces;
using ProvaMVC.Models;

namespace ProvaMVC.Controllers
{
    public class MatriculaController : Controller
    {
        private readonly IMatriculaRepository _matriculaRepository;

        public MatriculaController(IMatriculaRepository matriculaRepository)
        {
            _matriculaRepository = matriculaRepository;
        }

        public async Task<IActionResult> Index()
        {
            var matriculas = await _matriculaRepository.GetAllAsync();
            return View(matriculas);
        }

        public async Task<IActionResult> Details(Guid id)
        {
            var matricula = await _matriculaRepository.GetByIdAsync(id);
            if (matricula == null)
                return NotFound();
            
            return View(matricula);
        }

        public IActionResult Create()
        {
            return View();
        }

        [HttpPost]
        public async Task<IActionResult> Create(Matricula matricula)
        {
            if (ModelState.IsValid)
            {
                await _matriculaRepository.AddAsync(matricula);
                return RedirectToAction(nameof(Index));
            }
            return View(matricula);
        }

        public async Task<IActionResult> Edit(Guid id)
        {
            var matricula = await _matriculaRepository.GetByIdAsync(id);
            if (matricula == null)
                return NotFound();
            
            return View(matricula);
        }

        [HttpPost]
        public async Task<IActionResult> Edit(Guid id, Matricula matricula)
        {
            if (id != matricula.Id)
                return NotFound();

            if (ModelState.IsValid)
            {
                await _matriculaRepository.UpdateAsync(matricula);
                return RedirectToAction(nameof(Index));
            }
            
            return View(matricula);
        }

        public async Task<IActionResult> Delete(Guid id)
        {
            var matricula = await _matriculaRepository.GetByIdAsync(id);
            if (matricula == null)
                return NotFound();
            
            return View(matricula);
        }

        [HttpPost, ActionName("Delete")]
        public async Task<IActionResult> DeleteConfirmed(Guid id)
        {
            await _matriculaRepository.DeleteAsync(id);
            return RedirectToAction(nameof(Index));
        }
    }
}
