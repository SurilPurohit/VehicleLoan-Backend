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
    public class LoanTablesController : ControllerBase
    {
        private readonly Vehicle_LoanContext _context;

        public LoanTablesController(Vehicle_LoanContext context)
        {
            _context = context;
        }

        // GET: api/LoanTables
        [HttpGet]
        public async Task<ActionResult<IEnumerable<LoanTable>>> GetLoanTables()
        {
            return await _context.LoanTables.ToListAsync();
        }

        // GET: api/LoanTables/5
        [HttpGet("{id}")]
        public async Task<ActionResult<LoanTable>> GetLoanTable(int id)
        {
            var loanTable = await _context.LoanTables.FindAsync(id);

            if (loanTable == null)
            {
                return NotFound();
            }

            return loanTable;
        }

        // PUT: api/LoanTables/5
        // To protect from overposting attacks, see https://go.microsoft.com/fwlink/?linkid=2123754
        [HttpPut()]
        public async Task<IActionResult> PutLoanTable(LoanTable loanTable)
        {
            //if (id != loanTable.LoanId)
            //{
            //    return BadRequest();
            //}

            _context.Entry(loanTable).State = EntityState.Modified;

            try
            {
                await _context.SaveChangesAsync();
            }
            catch (DbUpdateConcurrencyException)
            {
                throw;
                
            }

            return NoContent();
        }

        // POST: api/LoanTables
        // To protect from overposting attacks, see https://go.microsoft.com/fwlink/?linkid=2123754
        [HttpPost]
        [Route("LoanUser")]
        public async Task<ActionResult<LoanTable>> PostLoanTable(LoanTable loanTable)
        {
            _context.LoanTables.Add(loanTable);
            await _context.SaveChangesAsync();

            return CreatedAtAction("GetLoanTable", new { id = loanTable.LoanId }, loanTable);
        }

        // DELETE: api/LoanTables/5
        [HttpDelete("{id}")]
        public async Task<IActionResult> DeleteLoanTable(int id)
        {
            var loanTable = await _context.LoanTables.FindAsync(id);
            if (loanTable == null)
            {
                return NotFound();
            }

            _context.LoanTables.Remove(loanTable);
            await _context.SaveChangesAsync();

            return NoContent();
        }

        private bool LoanTableExists(int id)
        {
            return _context.LoanTables.Any(e => e.LoanId == id);
        }
    }
}
