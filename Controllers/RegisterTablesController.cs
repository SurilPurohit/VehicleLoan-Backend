using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using VehicleLoan.LTIModel;

namespace VehicleLoan.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class RegisterTablesController : ControllerBase
    {
        Vehicle_LoanContext vlc = new Vehicle_LoanContext();
        private readonly Vehicle_LoanContext _context;

        public RegisterTablesController(Vehicle_LoanContext context)
        {
            _context = context;
        }

        // GET: api/RegisterTables
        [HttpGet]
        public async Task<ActionResult<IEnumerable<RegisterTable>>> GetRegisterTables()
        {
            return await _context.RegisterTables.ToListAsync();
        }

        // GET: api/RegisterTables/5
        [HttpGet("{id}")]
        public RegisterTable GetRegisterTable(string id)
        {
            var registerTable = _context.RegisterTables.Where(i=>i.Rname == id).Select(i=>i).First();

            if (registerTable == null)
            {
                return null;
            }

            return registerTable;
        }

        // PUT: api/RegisterTables/5
        // To protect from overposting attacks, see https://go.microsoft.com/fwlink/?linkid=2123754
        [HttpPut("{id}")]
        public async Task<IActionResult> PutRegisterTable(int id, RegisterTable registerTable)
        {
            if (id != registerTable.RuserId)
            {
                return BadRequest();
            }

            _context.Entry(registerTable).State = EntityState.Modified;

            try
            {
                await _context.SaveChangesAsync();
            }
            catch (DbUpdateConcurrencyException)
            {
                if (!RegisterTableExists(id))
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

        // POST: api/RegisterTables
        // To protect from overposting attacks, see https://go.microsoft.com/fwlink/?linkid=2123754
        [HttpPost]
        [Route("RegisterUser")]
        public async Task<ActionResult<RegisterTable>> PostRegisterTable(RegisterTable registerTable)
        {
            _context.RegisterTables.Add(registerTable);
            LoginTable lt = new LoginTable();
            lt.Uname = registerTable.Rname;
            lt.Upassword = registerTable.Rpassword;
            lt.Uadmin = "user";
            _context.LoginTables.Add(lt);
            await _context.SaveChangesAsync();
            return CreatedAtAction("GetRegisterTable", new { id = registerTable.RuserId }, registerTable);
        }

        // DELETE: api/RegisterTables/5
        [HttpDelete("{id}")]
        public async Task<IActionResult> DeleteRegisterTable(int id)
        {
            var registerTable = await _context.RegisterTables.FindAsync(id);
            if (registerTable == null)
            {
                return NotFound();
            }

            _context.RegisterTables.Remove(registerTable);
            await _context.SaveChangesAsync();

            return NoContent();
        }

        private bool RegisterTableExists(int id)
        {
            return _context.RegisterTables.Any(e => e.RuserId == id);
        }
    }
}
