using Microsoft.AspNetCore.Mvc;
using BattleGameAPI.Data;
using BattleGameAPI.Models;
using BattleGameAPI.DTOs;
using Microsoft.EntityFrameworkCore;

namespace BattleGameAPI.Controllers
{
    [ApiController]
    [Route("api/[controller]")]
    public class AssetController : ControllerBase
    {
        private readonly BattleGameContext _context;
        public AssetController(BattleGameContext context)
        {
            _context = context;
        }
        [HttpGet("all")]
        public async Task<IActionResult> GetAllAssets()
        {
            var assets = await _context.Assets.ToListAsync();
            return Ok(assets);
        }

        // POST: api/asset/createasset
        [HttpPost("createasset")]
        public async Task<IActionResult> CreateAsset(CreateAssetDto dto)
        {
            var asset = new Asset
            {
                AssetName = dto.AssetName
            };

            _context.Assets.Add(asset);
            await _context.SaveChangesAsync();

            return Ok(asset);
        }
    }
}
