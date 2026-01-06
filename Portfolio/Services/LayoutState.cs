using System;

namespace Portfolio.Services
{
    public class LayoutState
    {
        public string Audience { get; private set; } = "engineer";
        public string Theme { get; private set; } = "dark"; // Default for engineer

        public event Action? OnChange;

        public void SetAudience(string audience)
        {
            if (Audience != audience)
            {
                Audience = audience;
                // Engineer -> Dark Mode, Recruiter -> Light Mode
                Theme = Audience == "engineer" ? "dark" : "light";
                NotifyStateChanged();
            }
        }

        public void SetTheme(string theme)
        {
             if (Theme != theme)
            {
                Theme = theme;
                NotifyStateChanged();
            }
        }

        public Portfolio.Models.AchievementModel? SelectedAchievement { get; private set; }
        public Portfolio.Models.ProjectModel? SelectedProject { get; private set; }

        public void SelectAchievement(Portfolio.Models.AchievementModel? achievement)
        {
            SelectedAchievement = achievement;
            NotifyStateChanged();
        }

        public void SelectProject(Portfolio.Models.ProjectModel? project)
        {
            SelectedProject = project;
            NotifyStateChanged();
        }

        private void NotifyStateChanged() => OnChange?.Invoke();
    }
}
