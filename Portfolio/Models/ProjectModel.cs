namespace Portfolio.Models;

public class ProjectModel
{
    public string Title { get; set; } = "";
    public string Description { get; set; } = "";
    public string? ImageUrl { get; set; }
    public string? RepoUrl { get; set; }
    public string? DemoUrl { get; set; }
}
