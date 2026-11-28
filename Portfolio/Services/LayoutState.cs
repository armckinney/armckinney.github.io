using System;

namespace Portfolio.Services
{
    public class LayoutState
    {
        public const string OneDarkProTheme = "one-dark-pro";
        public const string DraculaTheme = "dracula";

        public string Theme { get; private set; } = OneDarkProTheme;

        public event Action? OnChange;

        public void SetTheme(string theme)
        {
            var normalized = theme == DraculaTheme ? DraculaTheme : OneDarkProTheme;
            if (Theme != normalized)
            {
                Theme = normalized;
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
