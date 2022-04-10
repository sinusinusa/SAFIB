using A.UnitTree;
using Microsoft.AspNetCore.Mvc;

namespace A.Controllers
{
    [ApiController]
    [Route("Synchronize")]
    public class SyncController : Controller
    {
        public async Task<ActionResult> Synchronize()
        {
            UnitTreeSync.Instance = ListFileUnitCreate.Create();
            return Ok();
        }
    }
}
