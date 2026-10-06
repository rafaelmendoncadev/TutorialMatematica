using System.Collections.Generic;
using TutorialMatematica.Models;

namespace TutorialMatematica.Services
{
    public interface IExamService
    {
        StudentProfile GetStudentProfile();
        Exam GetCurrentExam();
        Exam CreateNewExam();
        ExamResult EvaluateExam(Dictionary<int, string> submittedAnswers, int elapsedSeconds);
        ExamResult? GetLastResult();
        Question? GetQuestion(string questionId);
    }
}
