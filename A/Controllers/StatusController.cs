using A.UnitTree;
using Microsoft.AspNetCore.Mvc;

namespace A.Controllers
{
    [ApiController]
    [Route("Status")]
    public class StatusController : Controller
    {
        public async Task<List<UnitStatus>> GetAllAsync()
        {
            return UnitTreeSync.Tree.ToList();
        }
    }
}
