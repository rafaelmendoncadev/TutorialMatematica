namespace TutorialMatematica.Models
{
    public class TutorChatRequest
    {
        public string QuestionId { get; set; } = string.Empty;
        public string Message { get; set; } = string.Empty;
        public string? SelectedOptionKey { get; set; }
    }

    public class TutorChatResponse
    {
        public bool Success { get; set; } = true;
        public string Answer { get; set; } = string.Empty;
        public string? ErrorMessage { get; set; }
    }
}
