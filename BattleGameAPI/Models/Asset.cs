namespace BattleGameAPI.Models
{
    public class Asset
    {
        public int Id { get; set; }
        public string AssetName { get; set; } = string.Empty;

        public ICollection<PlayerAsset> PlayerAssets { get; set; } = new List<PlayerAsset>();
    }
}
