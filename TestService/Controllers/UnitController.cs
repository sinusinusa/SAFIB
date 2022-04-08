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

        public async Task<List<Unit>> GetAllAsync()
        {
            return await _unitContext.Units.ToListAsync();
        }

    }
}
