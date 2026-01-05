namespace Portfolio.Models;

public class SkillModel
{
    public string Name { get; set; } = "";
    public string Category { get; set; } = "";
    public string Url { get; set; } = "";
    public List<string> RelatedStories { get; set; } = new();
    public List<string> RelatedProjects { get; set; } = new();
}
