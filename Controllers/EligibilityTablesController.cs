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
    public class EligibilityTablesController : ControllerBase
    {
        private readonly Vehicle_LoanContext _context;

        public EligibilityTablesController(Vehicle_LoanContext context)
        {
            _context = context;
        }

        // GET: api/EligibilityTables
        [HttpGet]
        public async Task<ActionResult<IEnumerable<EligibilityTable>>> GetEligibilityTables()
        {
            return await _context.EligibilityTables.ToListAsync();
        }

        // GET: api/EligibilityTables/5
        [HttpGet("{id}")]
        public async Task<ActionResult<EligibilityTable>> GetEligibilityTable(int id)
        {
            var eligibilityTable = await _context.EligibilityTables.FindAsync(id);

            if (eligibilityTable == null)
            {
                return NotFound();
            }

            return eligibilityTable;
        }

        // PUT: api/EligibilityTables/5
        // To protect from overposting attacks, see https://go.microsoft.com/fwlink/?linkid=2123754
        [HttpPut("{id}")]
        public async Task<IActionResult> PutEligibilityTable(int id, EligibilityTable eligibilityTable)
        {
            if (id != eligibilityTable.EligId)
            {
                return BadRequest();
            }

            _context.Entry(eligibilityTable).State = EntityState.Modified;

            try
            {
                await _context.SaveChangesAsync();
            }
            catch (DbUpdateConcurrencyException)
            {
                if (!EligibilityTableExists(id))
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

        // POST: api/EligibilityTables
        // To protect from overposting attacks, see https://go.microsoft.com/fwlink/?linkid=2123754
        [HttpPost]
        [Route("EligibilityCheck")]
        public async Task<ActionResult<EligibilityTable>> PostEligibilityTable(EligibilityTable eligibilityTable)
        {
            _context.EligibilityTables.Add(eligibilityTable);
            await _context.SaveChangesAsync();

            return CreatedAtAction("GetEligibilityTable", new { id = eligibilityTable.EligId }, eligibilityTable);
        }

        // DELETE: api/EligibilityTables/5
        [HttpDelete("{id}")]
        public async Task<IActionResult> DeleteEligibilityTable(int id)
        {
            var eligibilityTable = await _context.EligibilityTables.FindAsync(id);
            if (eligibilityTable == null)
            {
                return NotFound();
            }

            _context.EligibilityTables.Remove(eligibilityTable);
            await _context.SaveChangesAsync();

            return NoContent();
        }

        private bool EligibilityTableExists(int id)
        {
            return _context.EligibilityTables.Any(e => e.EligId == id);
        }
    }
}
