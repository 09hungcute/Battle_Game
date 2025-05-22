using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using BattleGameAPI.Data;
using BattleGameAPI.Models;
using BattleGameAPI.DTOs;

namespace BattleGameAPI.Controllers
{
    [ApiController]
    [Route("api/[controller]")]
    public class PlayerController : ControllerBase
    {
        private readonly BattleGameContext _context;
        public PlayerController(BattleGameContext context)
        {
            _context = context;
        }

        // POST: api/player/registerplayer
        [HttpPost("registerplayer")]
        public async Task<IActionResult> RegisterPlayer(RegisterPlayerDto dto)
        {
            var player = new Player
            {
                PlayerName = dto.PlayerName,
                FullName = dto.FullName,
                Age = dto.Age,
                CurrentLevel = dto.CurrentLevel
            };

            _context.Players.Add(player);
            await _context.SaveChangesAsync();

            return Ok(player);
        }

        // GET: api/player/getassetsbyplayer
        [HttpGet("getassetsbyplayer")]
        public async Task<ActionResult<IEnumerable<AssetByPlayerDto>>> GetAssetsByPlayer()
        {
            var query = await _context.PlayerAssets
                .Include(pa => pa.Player)
                .Include(pa => pa.Asset)
                .Select(pa => new AssetByPlayerDto
                {
                    PlayerName = pa.Player.PlayerName,
                    Level = pa.Player.CurrentLevel,
                    Age = pa.Player.Age,
                    AssetName = pa.Asset.AssetName
                })
                .ToListAsync();

            return Ok(query);
        }
        [HttpGet("all")]
        public async Task<IActionResult> GetAllPlayers()
        {
            var players = await _context.Players.ToListAsync();
            return Ok(players);
        }

    }
}
