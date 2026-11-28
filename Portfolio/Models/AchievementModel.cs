namespace Portfolio.Models;

public class AchievementModel
{
    public string Id { get; set; } = "";
    public string Title { get; set; } = "";
    public string Company { get; set; } = "";
    public string Role { get; set; } = "";
    public string Timeframe { get; set; } = "";
    public List<string> Domains { get; set; } = new();
    public List<string> Principles { get; set; } = new();
    public List<string> Technologies { get; set; } = new();
    public string Challenge { get; set; } = "";
    public string Action { get; set; } = "";
    public string Result { get; set; } = "";
    public bool Pin { get; set; } = false;
}
