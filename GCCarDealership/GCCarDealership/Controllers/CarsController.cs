using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using GCCarDealership.Data;
using GCCarDealership.Model;
using GCCarDealership.Models;

namespace GCCarDealership.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class CarsController : ControllerBase
    {
        private readonly CarsContext _context;

        public CarsController(CarsContext context)
        {
            _context = context;
        }

        // GET: api/Cars
        [HttpGet]
        public async Task<ActionResult<IEnumerable<Cars>>> GetCar()
        {
            return await _context.Cars.ToListAsync();
        }

        // GET: Cars by Make, Model, or Color
        // api/Cars/search?q=
        [HttpGet("search")]
        public async Task<ActionResult<Cars>> GetCar([FromQuery]DealerModel viewModel)
        {
            var car = await _context.Cars.FirstOrDefaultAsync(x => x.Make == viewModel.Make 
            || x.Model == viewModel.Model || x.Color == viewModel.Color);

            if (car == null)
            {
                return NotFound();
            }

            return car;
        }

        // GET: Cars by Year
        //api/Cars/search/year?q=
        [HttpGet("search/year")]
        public async Task<ActionResult<IEnumerable<Cars>>> GetCarByYear(DealerModel viewModel)
        {
            var car = await _context.Cars.Where(x => x.Year == viewModel.Year).ToListAsync();
            if (car == null)
            {
                return NotFound();
            }

            return car;
        }

        

        

        // GET: api/Cars/5
        [HttpGet("{id}")]
        public async Task<ActionResult<Cars>> GetCar(int id)
        {
            var car = await _context.Cars.FindAsync(id);

            if (car == null)
            {
                return NotFound();
            }

            return car;
        }

        // PUT: api/Cars/5
        // To protect from overposting attacks, enable the specific properties you want to bind to, for
        // more details, see https://go.microsoft.com/fwlink/?linkid=2123754.
        [HttpPut("{id}")]
        public async Task<IActionResult> PutCar(int id, Cars car)
        {
            if (id != car.Id)
            {
                return BadRequest();
            }

            _context.Entry(car).State = EntityState.Modified;

            try
            {
                await _context.SaveChangesAsync();
            }
            catch (DbUpdateConcurrencyException)
            {
                if (!CarExists(id))
                {
                    return NotFound();
                }
                else
                {
                    throw;
                }
            }

            return NoContent();
        }

        // POST: api/Cars
        // To protect from overposting attacks, enable the specific properties you want to bind to, for
        // more details, see https://go.microsoft.com/fwlink/?linkid=2123754.
        [HttpPost]
        public async Task<ActionResult<Cars>> PostCar(Cars car)
        {
            _context.Cars.Add(car);
            await _context.SaveChangesAsync();

            return CreatedAtAction("GetCar", new { id = car.Id }, car);
        }

        // DELETE: api/Cars/5
        [HttpDelete("{id}")]
        public async Task<ActionResult<Cars>> DeleteCar(int id)
        {
            var car = await _context.Cars.FindAsync(id);
            if (car == null)
            {
                return NotFound();
            }

            _context.Cars.Remove(car);
            await _context.SaveChangesAsync();

            return car;
        }

        private bool CarExists(int id)
        {
            return _context.Cars.Any(e => e.Id == id);
        }
    }
}
