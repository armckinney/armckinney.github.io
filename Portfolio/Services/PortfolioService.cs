using System.Net.Http.Json;
using Portfolio.Models;

namespace Portfolio.Services;

public class PortfolioService
{
    private readonly HttpClient _http;

    public PortfolioService(HttpClient http)
    {
        _http = http;
    }

    public async Task<List<ProjectModel>> GetProjectsAsync()
    {
        var data = await _http.GetFromJsonAsync<ProjectsData>("data/projects.json");
        return data?.Projects ?? new List<ProjectModel>();
    }

    public async Task<List<SkillModel>> GetSkillsAsync()
    {
        var data = await _http.GetFromJsonAsync<SkillsData>("data/skills.json");
        return data?.Skills ?? new List<SkillModel>();
    }
    
    public async Task<List<AchievementModel>> GetAchievementsAsync()
    {
        try 
        {
            var data = await _http.GetFromJsonAsync<AchievementsData>("data/achievements.json");
            return data?.Achievements ?? new List<AchievementModel>();
        }
        catch(HttpRequestException) 
        {
            return new List<AchievementModel>();
        }
    }

    private class ProjectsData { public List<ProjectModel> Projects { get; set; } = new(); }
    private class SkillsData { public List<SkillModel> Skills { get; set; } = new(); }
    private class AchievementsData { public List<AchievementModel> Achievements { get; set; } = new(); }

    private ConfigModel? _config;

    public async Task<ConfigModel> GetConfigAsync()
    {
        if (_config != null) return _config;
        
        try 
        {
            _config = await _http.GetFromJsonAsync<ConfigModel>("data/config.json");
        }
        catch(HttpRequestException) 
        {
            _config = new ConfigModel();
        }

        return _config ?? new ConfigModel();
    }
}
