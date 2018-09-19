
using System.Collections.Generic;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;

namespace spikes {
    
    [Produces("application/json")]
    [Route("api/[controller]")]
    public class HighScoreController : ControllerBase {

        private readonly IHighScoreService HighScoreService;

        public HighScoreController(IHighScoreService highScoreService) {
            HighScoreService = highScoreService;
        }

        [HttpGet]
        public async Task<ActionResult<int>> GetHighScore() {
            return await Task.Run(() => HighScoreService.GetHighScore());
        }

        [HttpPost]
        public async Task<ActionResult<int>> SetScore([FromBody] int score) {
            return await Task.Run(() => HighScoreService.SetScore(score));
        }

    }
}