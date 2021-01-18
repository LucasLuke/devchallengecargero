using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using DevChallengeCarguero.Models;
using DevChallengeCarguero.Services;

namespace DevChallengeCarguero.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class AddressesController : ControllerBase
    {
        private readonly UsersDbContext _context;

        public AddressesController(UsersDbContext context)
        {
            _context = context;
        }

        // GET: api/Addresses
        [HttpGet]
        public async Task<ActionResult<IEnumerable<Address>>> GetAddress()
        {
            return await _context.Address.ToListAsync();
        }

        // GET: api/Addresses/5
        [HttpGet("{user}")]
        public async Task<ActionResult<IEnumerable<Address>>> GetAddress(string user)
        {
            //var address = await _context.Address.FindAsync(id);
            var address =  _context.Address.
                            Where(a => a.UserName.Contains(user))
                            .ToListAsync();


            if (address == null)
            {
                return NotFound();
            }

            return await address;
        }

        // PUT: api/Addresses/5
        [HttpPut("{id}")]
        public async Task<IActionResult> PutAddress(long id, string user, int number, string complement)
        {
            try
            {
                var address = await _context.Address.FindAsync(id);

                if (id != address.Id)
                {
                    return BadRequest();
                }

                if (user != address.UserName)
                {
                    return BadRequest();
                }

                address.Number = number;
                address.Complement = complement;

                _context.Entry(address).State = EntityState.Modified;
                await _context.SaveChangesAsync();
            }
            catch (DbUpdateConcurrencyException)
            {
                return NotFound();
            }

            return NoContent();
        }

        // POST: api/Addresses
        [HttpPost]
        public async Task<ActionResult<Address>> PostAddress(Address address)
        {
            AddressService service = new AddressService();

            try
            {
                var users = _context.UserItems.
                            Where(u => u.Name.Contains(address.UserName))
                            .ToList();
                
                if (users.Count == 0)
                {
                    return BadRequest("Usuario não encontrado!");
                }

                //consultando se endereço existe no mapa
                if (service.consultarEndereco(address.Street))
                {

                    _context.Address.Add(address);
                    await _context.SaveChangesAsync();
                    return CreatedAtAction("GetAddress", new { id = address.Id }, address);
                }
                else
                {
                    return BadRequest("Endereço não localizado!");
                }
            }
            catch (Exception e)
            {
                return BadRequest(e.Message); ;
            }
        }

        // DELETE: api/Addresses/5
        [HttpDelete("{id}")]
        public async Task<IActionResult> DeleteAddress(long id, string user)
        {
            try
            {
                var address = await _context.Address.FindAsync(id);
                if (address == null)
                {
                    return NotFound();
                }

                if (address.UserName != user)
                {
                    NotFound();
                }

                _context.Address.Remove(address);
                await _context.SaveChangesAsync();
            }catch(Exception e)
            {
                return BadRequest(e.Message);
            }

            return NoContent();
        }

        private bool AddressExists(long id)
        {
            return _context.Address.Any(e => e.Id == id);
        }
    }
}
