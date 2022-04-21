using Microsoft.AspNetCore.Mvc;
using System.Threading;

namespace netcore_3._1_api_performance_tests.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class ThreadInfoController : ControllerBase
    {
        [HttpGet("max", Name = "GetMaxThreadInfo")]
        public ActionResult<int> GetMax()
        {
            int workerThreads;
            int portThreads;

            ThreadPool.GetMaxThreads(out workerThreads, out portThreads);
            return Ok(workerThreads);
        }

        [HttpGet("avaiable", Name = "GetAvaiableThreadInfo")]
        public ActionResult<int> GetAvaiable()
        {
            int workerThreads;
            int portThreads;

            ThreadPool.GetAvailableThreads(out workerThreads, out portThreads);
            return Ok(workerThreads);
        }
    }
}
