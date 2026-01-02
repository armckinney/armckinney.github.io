namespace Portfolio.Models;

public class StoryModel
{
    public string Title { get; set; } = "";
    public string Situation { get; set; } = "";
    public string Task { get; set; } = "";
    public string Action { get; set; } = "";
    public string Result { get; set; } = "";
    public List<string> Tags { get; set; } = new List<string>();
}
