namespace Portfolio.Models;

public class ConfigModel
{
    public SocialsModel Socials { get; set; } = new();
    public string Resume { get; set; } = "";
}

public class SocialsModel
{
    public string Github { get; set; } = "";
    public string Linkedin { get; set; } = "";
    public string Email { get; set; } = "";
    public string Docker { get; set; } = "";
}
