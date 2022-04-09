using TestService.DataAccess;
using TestService.DataAccess.Entity;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using System.Linq;
using System.Threading.Tasks;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System;

namespace B.Controllers
{
    [ApiController]
    [Route("sync")]
    public class SyncController : Controller
    {
        private readonly UnitContext _unitContext;
        public SyncController(UnitContext unitContext)
        {
            _unitContext = unitContext;
        }
    public async Task<ActionResult> ChangeMainId([Required, FromQuery(Name = "id")] int id,
    [FromQuery(Name = "mainid")] int? mainId)
        {
            Unit? unitInDatabase = await _unitContext.Units
                 .FirstOrDefaultAsync(u => u.Id == id);
            if (unitInDatabase != null)
            {
                unitInDatabase.MainId = mainId;
                _unitContext.Update(unitInDatabase);
            }
            else
            {
                return Conflict($"Unit with id '{id}' isn't exist");
            }
            await _unitContext.SaveChangesAsync();
            return Ok();
        }
    }
}
