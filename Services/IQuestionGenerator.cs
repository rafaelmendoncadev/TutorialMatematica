using System.Collections.Generic;
using TutorialMatematica.Models;

namespace TutorialMatematica.Services
{
    public interface IQuestionGenerator
    {
        List<Question> GenerateExamQuestions();
    }
}
