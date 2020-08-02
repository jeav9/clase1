using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using AlumnosWebApplication.Model;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;

namespace AlumnosWebApplication.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class AlumnoController : Controller
    {
        private readonly AlumnoContext _context;
        public AlumnoController(AlumnoContext context)
        {
            _context = context;

            if(_context.Alumno.Count() == 0)
            {
                _context.Alumno.Add(new Alumno { Name = "Jorge" });
                _context.SaveChanges();
            }
        }

        [HttpGet]
        public async Task<ActionResult<IEnumerable<Alumno>>> GetAlumnos()
        {
            return await _context.Alumno.ToListAsync();
        }

        [HttpGet("{id}")]
        public async Task<ActionResult<Alumno>> GetAlumno(long id) 
        {
            var result = await _context.Alumno.FindAsync(id);

            if(result == null) {
                return NotFound();
            }

            return result;
        }

        [HttpPost]
        public async Task<ActionResult<Alumno>> PostAlumno(Alumno alumno)
        {
            _context.Alumno.Add(alumno);
            await _context.SaveChangesAsync();

            return CreatedAtAction(nameof(GetAlumno), new { id = alumno.Id }, alumno);
        }

        [HttpPut("{id}")]
        public async Task<ActionResult<Alumno>> PutAlumno(long id, Alumno alumno)
        {
            if(!id.Equals(alumno.Id))
            {
                return BadRequest();
            }

            _context.Entry(alumno).State = EntityState.Modified;
            await _context.SaveChangesAsync();
            return NoContent();
        }

        [HttpDelete("{id}")]
        public async Task<ActionResult<Alumno>> DeleteAlumno(long id)
        {
            var result = await _context.Alumno.FindAsync(id);

            if(result == null)
            {
                return NotFound();
            }

            _context.Alumno.Remove(result);
            await _context.SaveChangesAsync();

            return NoContent();
        }
    }
}
