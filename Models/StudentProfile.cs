namespace TutorialMatematica.Models
{
    public class ModuleProgress
    {
        public int Id { get; set; }
        public string Title { get; set; } = string.Empty;
        public string Description { get; set; } = string.Empty;
        public string FormulaPreview { get; set; } = string.Empty;
        public int Percentage { get; set; }
        public bool IsCurrent { get; set; }
        public string EstimatedTime { get; set; } = string.Empty;
        public string Icon { get; set; } = string.Empty;
    }

    public class StudentProfile
    {
        public string Name { get; set; } = "Carlos Eduardo";
        public string Level { get; set; } = "Intermediário";
        public int TotalXp { get; set; } = 1240;
        public int OverallProgress { get; set; } = 75;
        public string ActiveGoal { get; set; } = "Desafio 10/10: Acerte 100% no simulado final para obter a certificação de módulo. Foco contínuo em geometria euclidiana plana e conversão de grandezas.";
        public List<ModuleProgress> Modules { get; set; } = new();
        public List<ExamResult> RecentAttempts { get; set; } = new();
    }
}
