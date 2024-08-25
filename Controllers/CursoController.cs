using Microsoft.AspNetCore.Mvc;
using ProvaMVC.Data.Repositories.Interfaces;
using ProvaMVC.Models;

namespace ProvaMVC.Controllers
{
    public class CursoController : Controller
    {
        private readonly ICursoRepository _cursoRepository;

        public CursoController(ICursoRepository cursoRepository)
        {
            _cursoRepository = cursoRepository;
        }

        public async Task<IActionResult> Index()
        {
            var cursos = await _cursoRepository.GetAllAsync();
            return View(cursos);
        }

        public async Task<IActionResult> Details(Guid id)
        {
            var curso = await _cursoRepository.GetByIdAsync(id);
            if (curso == null)
                return NotFound();
            
            return View(curso);
        }

        public IActionResult Create()
        {
            return View();
        }

        [HttpPost]
        public async Task<IActionResult> Create(Curso curso)
        {
            if (ModelState.IsValid)
            {
                await _cursoRepository.AddAsync(curso);
                return RedirectToAction(nameof(Index));
            }
            
            return View(curso);
        }

        public async Task<IActionResult> Edit(Guid id)
        {
            var curso = await _cursoRepository.GetByIdAsync(id);
            if (curso == null)
                return NotFound();
            
            return View(curso);
        }

        [HttpPost]
        public async Task<IActionResult> Edit(Guid id, Curso curso)
        {
            if (id != curso.Id)
                return NotFound();

            if (ModelState.IsValid)
            {
                await _cursoRepository.UpdateAsync(curso);
                return RedirectToAction(nameof(Index));
            }

            return View(curso);
        }

        public async Task<IActionResult> Delete(Guid id)
        {
            var curso = await _cursoRepository.GetByIdAsync(id);
            if (curso == null)
                return NotFound();

            return View(curso);
        }

        [HttpPost, ActionName("Delete")]
        public async Task<IActionResult> DeleteConfirmed(Guid id)
        {
            await _cursoRepository.DeleteAsync(id);
            return RedirectToAction(nameof(Index));
        }
    }
}
