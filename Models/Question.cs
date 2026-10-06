namespace TutorialMatematica.Models
{
    public class QuestionOption
    {
        public string Key { get; set; } = string.Empty; // "A", "B", "C", "D", "E"
        public string Text { get; set; } = string.Empty;
    }

    public class Question
    {
        public int Number { get; set; }
        public string Id { get; set; } = Guid.NewGuid().ToString("N");
        public string Topic { get; set; } = string.Empty;
        public string SubTopic { get; set; } = string.Empty;
        public string Statement { get; set; } = string.Empty;
        public string TechnicalBadge { get; set; } = string.Empty;
        public string TechnicalTitle { get; set; } = string.Empty;
        public string TechnicalDescription { get; set; } = string.Empty;
        public string ParameterSummary { get; set; } = string.Empty;
        public string DiagramSvg { get; set; } = string.Empty;
        public string TutorHint { get; set; } = string.Empty;
        public List<QuestionOption> Options { get; set; } = new();
        public string CorrectOptionKey { get; set; } = "C";
        public string ExplanationStep1 { get; set; } = string.Empty;
        public string ExplanationStep2 { get; set; } = string.Empty;
        public string ConceptualTrap { get; set; } = string.Empty;
    }
}
