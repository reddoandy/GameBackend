using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace GameBackend.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class MatchController : ControllerBase
    {

        [HttpPost("join")]
        public IActionResult JoinMatch([FromBody] MatchRequest request)
        {
            Console.WriteLine($"收到UE傳來的EOS ID:{request.EosId}");

            return Ok(new
            {
                status = "QUEUED"
            });
        }

        [HttpPost("ping")]
        public IActionResult Ping([FromBody] object data)
        {
            Console.WriteLine("Ping received");
            return Ok(new { ok = true });
        }
    }

        public class MatchRequest
        {
            public string EosId {  get; set; }
        }

        
    
}
