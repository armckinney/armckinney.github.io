namespace Portfolio.Models;

public class AchievementModel
{
    public string Id { get; set; } = "";
    public string Title { get; set; } = "";
    public List<string> Domains { get; set; } = new();
    public List<string> Principles { get; set; } = new();
    public List<string> Technologies { get; set; } = new();
    public string Situation { get; set; } = "";
    public string Task { get; set; } = "";
    public string Action { get; set; } = "";
    public string Result { get; set; } = "";
    public DeepDive? DeepDive { get; set; }
    public bool Pin { get; set; } = false;
}

public class DeepDive
{
    public string Architecture { get; set; } = "";
    public string Challenges { get; set; } = "";
    public string Retrospective { get; set; } = "";
    public Diagram? Diagram { get; set; }
}

public class Diagram
{
    public string Description { get; set; } = "";
    public string Url { get; set; } = "";
}
