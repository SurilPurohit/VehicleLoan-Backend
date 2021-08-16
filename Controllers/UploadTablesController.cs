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
    public class UploadTablesController : ControllerBase
    {
        private readonly Vehicle_LoanContext _context;

        public UploadTablesController(Vehicle_LoanContext context)
        {
            _context = context;
        }

        // GET: api/UploadTables
        [HttpGet]
        public async Task<ActionResult<IEnumerable<UploadTable>>> GetUploadTables()
        {
            return await _context.UploadTables.ToListAsync();
        }

        // GET: api/UploadTables/5
        [HttpGet("{id}")]
        public async Task<ActionResult<UploadTable>> GetUploadTable(string id)
        {
            var uploadTable = await _context.UploadTables.FindAsync(id);

            if (uploadTable == null)
            {
                return NotFound();
            }

            return uploadTable;
        }

        // PUT: api/UploadTables/5
        // To protect from overposting attacks, see https://go.microsoft.com/fwlink/?linkid=2123754
        [HttpPut("{id}")]
        public async Task<IActionResult> PutUploadTable(string id, UploadTable uploadTable)
        {
            if (id != uploadTable.Adhar)
            {
                return BadRequest();
            }

            _context.Entry(uploadTable).State = EntityState.Modified;

            try
            {
                await _context.SaveChangesAsync();
            }
            catch (DbUpdateConcurrencyException)
            {
                if (!UploadTableExists(id))
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

        // POST: api/UploadTables
        // To protect from overposting attacks, see https://go.microsoft.com/fwlink/?linkid=2123754
        [HttpPost]
        [Route("Upload")]
        public async Task<ActionResult<UploadTable>> PostUploadTable(UploadTable uploadTable)
        {
            _context.UploadTables.Add(uploadTable);
            try
            {
                await _context.SaveChangesAsync();
            }
            catch (DbUpdateException)
            {
                if (UploadTableExists(uploadTable.Adhar))
                {
                    return Conflict();
                }
                else
                {
                    throw;
                }
            }

            return CreatedAtAction("GetUploadTable", new { id = uploadTable.Adhar }, uploadTable);
        }

        // DELETE: api/UploadTables/5
        [HttpDelete("{id}")]
        public async Task<IActionResult> DeleteUploadTable(string id)
        {
            var uploadTable = await _context.UploadTables.FindAsync(id);
            if (uploadTable == null)
            {
                return NotFound();
            }

            _context.UploadTables.Remove(uploadTable);
            await _context.SaveChangesAsync();

            return NoContent();
        }

        private bool UploadTableExists(string id)
        {
            return _context.UploadTables.Any(e => e.Adhar == id);
        }
    }
}
