// controlador recursos api de alumno no autenticado
// Date: 2020/02/15

using System;

using Microsoft.AspNetCore.Mvc;

using ApiAlumnos.Models;
using IDGS902.Data;

namespace ApiAlumnos.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class AlumnoController : ControllerBase
    {
        private readonly AppDbContext _context;

        public AlumnoController(AppDbContext context)
        {
            _context = context;
        }

        [HttpGet]
        public IActionResult Get()
        {
            return Ok(_context.Alumnos);
        }

        [HttpGet("{id}")]
        public IActionResult Get(int id)
        {
            var alumno = _context.Alumnos.Find(id);
            if (alumno == null)
            {
                return NotFound();
            }
            return Ok(alumno);
        }

        [HttpPost]
        public async Task<IActionResult> Post([FromBody] Alumno alumno)
        {
            await _context.Alumnos.AddAsync(alumno);
            await _context.SaveChangesAsync();
            return Ok();
            
        }

        [HttpPut("{id}")]
        public IActionResult Put(int id, [FromBody] Alumno alumno)
        {
            if (ModelState.IsValid)
            {
                if (id == alumno.Id)
                {
                    _context.Update(alumno);
                    _context.SaveChanges();
                    return Ok();
                }
                else
                {
                    return BadRequest();
                }
            }
            return BadRequest(ModelState);
        }

        [HttpDelete("{id}")]
        public IActionResult Delete(int id)
        {
            var alumno = _context.Alumnos.Find(id);
            if (alumno == null)
            {
                return NotFound();
            }
            _context.Alumnos.Remove(alumno);
            _context.SaveChanges();
            return Ok();
        }
    }
}