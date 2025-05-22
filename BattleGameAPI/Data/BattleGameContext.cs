using Microsoft.EntityFrameworkCore;
using BattleGameAPI.Models;

namespace BattleGameAPI.Data
{
    public class BattleGameContext : DbContext
    {
        public BattleGameContext(DbContextOptions<BattleGameContext> options) : base(options) {}

        public DbSet<Player> Players { get; set; }
        public DbSet<Asset> Assets { get; set; }
        public DbSet<PlayerAsset> PlayerAssets { get; set; }
    }
}
