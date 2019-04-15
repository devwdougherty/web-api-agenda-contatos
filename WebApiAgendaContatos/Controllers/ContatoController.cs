using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using WebApiAgendaContatos.Models;
using WebApiAgendaContatos.Services;
using System.Reflection;

namespace WebApiAgendaContatos.Controllers
{
    [Route("api/contatos")]
    [ApiController]
    public class ContatoController : ControllerBase
    {
        /// <summary>
        /// DI to database context (in memory)
        /// </summary>
        private readonly AgendaContext _context;

        /// <summary>
        /// Constructor of the class
        /// </summary>
        /// <param name="context"></param>
        public ContatoController(AgendaContext context)
        {
            _context = context;

            DatabaseSeeder databaseSeeder = new DatabaseSeeder(_context);

            databaseSeeder.SeedDatabase();
        }

        /// <summary>
        /// GET METHOD to get all the Contatos from database.
        /// </summary>
        /// <returns>All the Contatos</returns>
        [HttpGet]
        public async Task<ActionResult<IEnumerable<Contato>>> GetAllContatos()
        {

            Console.WriteLine("ENTROU NO GETALLCONTAOTS");
            /*if (logger.IsDebugEnabled)
            {
                logger.Warn("GET: All contatos...");
            }*/
            return await _context.Contatos.ToListAsync();
        }

        /// <summary>
        /// GET BY ID METHOD to get a specific record.
        /// </summary>
        /// <param name="id">Id of object that will be get</param>
        /// <returns>Contato object</returns>
        [HttpGet("{id}")]
        public async Task<ActionResult<Contato>> GetContatoById(long id)
        {
            //logger.Debug("GET: Contato by id: " + id.ToString());

            var TempContato = await _context.Contatos.FindAsync(id);

            if (TempContato == null)
            {
                return NotFound();
            }

            return TempContato;
        }

        /// <summary>
        /// POST METHOD to insert a new Contato at database.
        /// </summary>
        /// <param name="contato">Object to be created</param>
        /// <returns>Object created + Location Header</returns>
        [HttpPost]
        public async Task<ActionResult<Contato>> PostContato(Contato contato)
        {
            //logger.Debug("POST: Contato...");

            _context.Contatos.Add(contato);
            await _context.SaveChangesAsync();

            // A post method returns 200 or 201 (created) at its response. Inside CreatedAtAction, we add a Header 'Location' giving to the user,
            // the URI to access the resource that we have created.
            return CreatedAtAction(nameof(GetContatoById), new { id = contato.Id }, contato);
        }

        /// <summary>
        /// PUT METHOD to update a existent record.
        /// </summary>
        /// <param name="id">Id of object to be updated</param>
        /// <param name="contato">Object that will be updated</param>
        /// <returns>Object updated</returns>
        [HttpPut("{id}")]
        public async Task<ActionResult<Contato>> PutContato(long id, Contato contato)
        {
            //logger.Debug("PUT: Contato id: " + id.ToString());

            if (id != contato.Id)
            {
                return BadRequest();
            }

            _context.Entry(contato).State = EntityState.Modified;
            await _context.SaveChangesAsync();

            return contato;
        }

        /// <summary>
        /// DELETE METHOD to delete a record
        /// </summary>
        /// <param name="id">Id of record that will be deleted</param>
        /// <returns>No content</returns>
        [HttpDelete("{id}")]
        public async Task<IActionResult> DeleteContato(long id)
        {
            //logger.Debug("DELETE: Contato by id: " + id.ToString());

            var contato = await _context.Contatos.FindAsync(id);

            if (contato == null)
            {
                return NotFound();
            }

            _context.Contatos.Remove(contato);
            await _context.SaveChangesAsync();

            return NoContent();
        }
    }
}