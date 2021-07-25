using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using test2307.Entities;

namespace test2307.Controllers
{
    [ApiController]
    [Route("api/[controller]")]
    public class LibrosController:ControllerBase
    {
        private readonly ApplicationDbContext context;

        public LibrosController(ApplicationDbContext context)
        {
            this.context = context;
        }

        [HttpGet("{id:int}")]
        public async Task<ActionResult<Libro>> Get(int id)
        {
            var existe = await context.Libro.AnyAsync(x => x.Id == id);
            if (!existe)
                return NotFound($"El libro con id: {id} no existe.");

            return await context.Libro.Include(x => x.Autor).FirstOrDefaultAsync(x => x.Id == id);
        }

        [HttpPost]
        public async Task<ActionResult> Post(Libro libro)
        {
            var existe = await context.Autor.AnyAsync(x => x.Id == libro.AutorId);

            if (!existe)
                return BadRequest($"No existe el autor con Id: {libro.AutorId}.");

            context.Add(libro);
            await context.SaveChangesAsync();
            return Ok();
        }
    }
}
