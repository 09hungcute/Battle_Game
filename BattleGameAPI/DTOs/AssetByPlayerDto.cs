namespace BattleGameAPI.DTOs
{
    public class AssetByPlayerDto
    {
        public string PlayerName { get; set; } = string.Empty;
        public int Level { get; set; }
        public int Age { get; set; }
        public string AssetName { get; set; } = string.Empty;
    }
}
