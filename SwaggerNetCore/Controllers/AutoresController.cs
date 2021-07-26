using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using System.Web.Http.Description;
using test2307.Entities;

namespace test2307.Controllers
{
    [ApiController]
    [Route("api/[controller]")]
    public class AutoresController : ControllerBase
    {
        private readonly ApplicationDbContext context;

        public AutoresController(ApplicationDbContext context)
        {
            this.context = context;
        }

        /// <summary>
        /// Este método trae todos los autores
        /// </summary>
        /// <returns>Puros autores</returns>
        /// <remarks>Este es un remark para información ampliada de autores de libros comunes y conocidos.</remarks>
        /// <response code="200">Todo bien eh</response>
        /// <response code="400">La liaste ah</response>        
        [HttpGet]        
        public async Task<ActionResult<List<Autor>>> Get()
        {
            return await context.Autor.Include(x=>x.Libros).ToListAsync();
        }

        /// <summary>
        /// Este método inserta autores
        /// </summary>
        /// <param name="autor">Inserte autor</param>
        /// <returns></returns>
        [HttpPost]
        public async Task<ActionResult> Post(Autor autor)
        {            
            context.Autor.Add(autor);
            await context.SaveChangesAsync();
            return Ok();
        }

        [HttpPut("{id:int}")]
        public async Task<ActionResult> Put(Autor autor, int id=8)
        {
            var existe = await context.Autor.AnyAsync(x => x.Id == id);
            if (!existe)
                return NotFound("El autor indicado no existe");

            if (id != autor.Id)
                return BadRequest("El autor que se quiere modificar no coincide con el enviado en la URL");

            context.Autor.Update(autor);
            await context.SaveChangesAsync();
            return Ok();
        }

        [HttpDelete("{id:int}")]
        public async Task<ActionResult> Delete(int id)
        {
            var existe = await context.Autor.AnyAsync(x => x.Id == id);
            if (!existe)
                return NotFound("El autor indicado no existe");

            context.Autor.Remove(new Autor { Id = id });
            await context.SaveChangesAsync();
            return Ok();
        }
    }
}
