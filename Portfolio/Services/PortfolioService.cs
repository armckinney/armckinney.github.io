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
    
    public async Task<List<StoryModel>> GetStoriesAsync()
    {
        try 
        {
            return await _http.GetFromJsonAsync<List<StoryModel>>("data/stories.json") ?? new List<StoryModel>();
        }
        catch(HttpRequestException) 
        {
            // If the file doesn't exist or is empty, just return empty list
            return new List<StoryModel>();
        }
    }
}
