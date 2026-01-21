using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using GameBackend.Models;
using GameBackend.Services;

namespace GameBackend.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class MatchController : ControllerBase
    {

        private readonly MatchMakingService _matchmaking;

        public MatchController(MatchMakingService matchmaking)
        {
            _matchmaking = matchmaking;
        }

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

        [HttpPost("request")]
        public ActionResult<MatchResponse> RequestMatch([FromBody] MatchRequest request)
        {    
            if (string.IsNullOrEmpty(request.EosId))
            {               
                return BadRequest("EosId is required");
            }

            var result = _matchmaking.Enqueue(request.EosId);
            return Ok(result);
                
        }
    }
    
    }
