using TestService.DataAccess;
using TestService.DataAccess.Entity;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using System.Linq;
using System.Threading.Tasks;
using System.Collections.Generic;

namespace TestService.Controllers
{
    [ApiController]
    [Route("unit")]
    public class UnitController : Controller
    {
        private readonly UnitContext _unitContext;
        public UnitController(UnitContext unitContext)
        {
            _unitContext = unitContext;
        }
        [HttpPut]
        public async Task<ActionResult> ChangeMainId(int id, int mainId)
        {
            Unit? unitInDatabase = await _unitContext.Units
                 .FirstOrDefaultAsync(u => u.Id == id);
            if(unitInDatabase != null)
            {
                unitInDatabase.MainId = mainId;
                _unitContext.Update(unitInDatabase);
            }
            else
            {
                Conflict($"Unit with id '{id}' isn't exist");
            }
            await _unitContext.SaveChangesAsync();
            return Ok();
        }
        [HttpPost]
        public async Task<ActionResult<Unit>> CreateUnit(Unit unit)
        {
            Unit? unitInDatabase = await _unitContext.Units
                .FirstOrDefaultAsync(u => u.Id == unit.Id);
            if (unitInDatabase != null) { 
                Conflict($"Unit with id '{unit.Id}' is already exist"); 
            }
            _unitContext.Add(unit);
            await _unitContext.SaveChangesAsync();
            return Ok();
        }
        public async Task<List<Unit>> GetAllAsync()
        {
            return await _unitContext.Units.Include(x => x.MainUnit).ToListAsync();
        }

    }
}
