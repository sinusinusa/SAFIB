using TestService.DataAccess;
using TestService.DataAccess.Entity;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using System.Linq;
using System.Threading.Tasks;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System;

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
        public async Task<List<Unit>> GetAllAsync()
        {
            return await _unitContext.Units.Include(x => x.MainUnit).ToListAsync();
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


    }
}
