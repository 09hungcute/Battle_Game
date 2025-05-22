namespace BattleGameAPI.DTOs
{
    public class RegisterPlayerDto
{
    public string PlayerName { get; set; } = string.Empty;
    public string FullName { get; set; } = string.Empty;
    public int Age { get; set; }
    public int CurrentLevel { get; set; }
}

}
