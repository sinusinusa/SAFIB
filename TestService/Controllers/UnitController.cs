﻿using TestService.DataAccess;
using TestService.DataAccess.Entity;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using System.Linq;
using System.Threading.Tasks;

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
    }
}