namespace TutorialMatematica.Models
{
    public class QuestionEvaluation
    {
        public Question Question { get; set; } = new();
        public string SelectedOptionKey { get; set; } = string.Empty;
        public string SelectedOptionText { get; set; } = string.Empty;
        public string CorrectOptionText { get; set; } = string.Empty;
        public bool IsCorrect { get; set; }
    }

    public class ExamResult
    {
        public string ExamId { get; set; } = string.Empty;
        public DateTime CompletedAt { get; set; } = DateTime.UtcNow;
        public int ElapsedSeconds { get; set; } = 760; // default 12m 40s
        public string ElapsedFormatted => $"{ElapsedSeconds / 60}m {ElapsedSeconds % 60:D2}s";
        public int TotalQuestions => Evaluations.Count;
        public int CorrectCount => Evaluations.Count(e => e.IsCorrect);
        public int IncorrectCount => Evaluations.Count(e => !e.IsCorrect);
        public int ScorePercentage => TotalQuestions > 0 ? (int)Math.Round((double)CorrectCount / TotalQuestions * 100) : 0;
        public bool IsApproved => ScorePercentage == 100; // Requires 10/10 for certification
        public int GainedXp => CorrectCount * 50;
        public List<QuestionEvaluation> Evaluations { get; set; } = new();
    }
}
