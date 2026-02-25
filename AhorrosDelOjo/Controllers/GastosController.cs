using AutoMapper;
using FinanzasWeb.Dtos;
using FinanzasWeb.Models;
using FinanzasWeb.Repositories;
using Microsoft.AspNetCore.Mvc;

namespace FinanzasWeb.Controllers
{
    public class GastosController : Controller
    {
        private readonly IGastoRepository _repository;
        private readonly IMapper _mapper;
        
        public GastosController(IGastoRepository repository, IMapper mapper)
        {
            _repository = repository;
            _mapper = mapper;
        }

        // GET: Gastos
        public async Task<IActionResult> Index()
        {
            var gastos = await _repository.GetAllAsync();
            var gastosDto = _mapper.Map<IEnumerable<GastoDto>>(gastos);
            //LINQ para un contador total de ahorros
            ViewBag.TotalAhorrado = gastosDto.Sum(g => g.Monto);
            return View(gastosDto);
        }

        // GET: Gastos/Create
        public IActionResult Create()
        {
            return View();
        }

        // POST: Gastos/Create
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Create(GastoDto gastoDto)
        {
            if (ModelState.IsValid)
            {
                var gasto = _mapper.Map<Gasto>(gastoDto);
                await _repository.AddAsync(gasto);
                return RedirectToAction(nameof(Index));
            }
            return View(gastoDto);
        }

        // GET: Gastos/Edit/5
        public async Task<IActionResult> Edit(int id)
        {
            var gasto = await _repository.GetByIdAsync(id);
            if (gasto == null) return NotFound();

            var gastoDto = _mapper.Map<GastoDto>(gasto);
            return View(gastoDto);
        }

        // POST: Gastos/Edit/5
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Edit(int id, GastoDto gastoDto)
        {
            if (id != gastoDto.Id) return NotFound();

            if (ModelState.IsValid)
            {
                var gasto = _mapper.Map<Gasto>(gastoDto);
                await _repository.UpdateAsync(gasto);
                return RedirectToAction(nameof(Index));
            }
            return View(gastoDto);
        }

        // GET: Gastos/Delete/5
        public async Task<IActionResult> Delete(int id)
        {
            var gasto = await _repository.GetByIdAsync(id);
            if (gasto == null) return NotFound();
            
            var gastoDto = _mapper.Map<GastoDto>(gasto);
            return View(gastoDto);
        }

        // POST: Gastos/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> DeleteConfirmed(int id)
        {
            await _repository.DeleteAsync(id);
            return RedirectToAction(nameof(Index));

            
        }
    }
    
}