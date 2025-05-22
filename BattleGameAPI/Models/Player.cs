namespace BattleGameAPI.Models
{
    public class Player
{
    public int Id { get; set; }
    public string PlayerName { get; set; } = string.Empty;
    public string FullName { get; set; } = string.Empty;
    public int Age { get; set; }
    public int CurrentLevel { get; set; }

    public ICollection<PlayerAsset> PlayerAssets { get; set; } = new List<PlayerAsset>();
}

}
