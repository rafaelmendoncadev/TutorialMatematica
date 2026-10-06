namespace TutorialMatematica.Models
{
    public class Exam
    {
        public string Id { get; set; } = Guid.NewGuid().ToString("N");
        public string Title { get; set; } = "Simulado Oficial - Geometria Espacial & Plana";
        public DateTime CreatedAt { get; set; } = DateTime.UtcNow;
        public List<Question> Questions { get; set; } = new();
    }
}
