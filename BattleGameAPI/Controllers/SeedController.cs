using Microsoft.AspNetCore.Mvc;
using BattleGameAPI.Models;
using BattleGameAPI.Data;
using Microsoft.EntityFrameworkCore;

namespace BattleGameAPI.Controllers
{
    [ApiController]
    [Route("api/[controller]")]
    public class SeedController : ControllerBase
    {
        private readonly BattleGameContext _context;
        public SeedController(BattleGameContext context)
        {
            _context = context;
        }

        // API gán asset cho player
        [HttpPost("assign")]
        public async Task<IActionResult> AssignAssetToPlayer([FromBody] AssignAssetDto dto)
        {
            var player = await _context.Players.FindAsync(dto.PlayerId);
            var asset = await _context.Assets.FindAsync(dto.AssetId);

            if (player == null || asset == null)
                return BadRequest("Player or Asset not found.");

            var pa = new PlayerAsset
            {
                PlayerId = player.Id,
                AssetId = asset.Id
            };

            _context.PlayerAssets.Add(pa);
            await _context.SaveChangesAsync();

            return Ok("Assigned!");
        }
    }

    public class AssignAssetDto
    {
        public int PlayerId { get; set; }
        public int AssetId { get; set; }
    }
}
