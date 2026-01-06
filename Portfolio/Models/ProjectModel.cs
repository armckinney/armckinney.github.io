namespace Portfolio.Models;

public class ProjectModel
{
    public string Id { get; set; } = "";
    public string Title { get; set; } = "";
    public string Description { get; set; } = "";
    public string Domain { get; set; } = "";
    public List<string> Technologies { get; set; } = new();
    public string? CodeUrl { get; set; }
    public string? DemoUrl { get; set; }
    public List<string> Highlights { get; set; } = new();
    public string? Image { get; set; }
}
