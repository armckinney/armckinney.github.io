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
        return await _http.GetFromJsonAsync<List<ProjectModel>>("data/projects.json") ?? new List<ProjectModel>();
    }

    public async Task<List<SkillModel>> GetSkillsAsync()
    {
        return await _http.GetFromJsonAsync<List<SkillModel>>("data/skills.json") ?? new List<SkillModel>();
    }
    
    public async Task<List<AchievementModel>> GetAchievementsAsync()
    {
        try 
        {
            return await _http.GetFromJsonAsync<List<AchievementModel>>("data/achievements.json") ?? new List<AchievementModel>();
        }
        catch(HttpRequestException) 
        {
            // If the file doesn't exist or is empty, just return empty list
            return new List<AchievementModel>();
        }
    }

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
