using System;
using System.Collections.Generic;
using System.Linq;
using TutorialMatematica.Models;

namespace TutorialMatematica.Services
{
    public class ExamService : IExamService
    {
        private readonly IQuestionGenerator _questionGenerator;
        private readonly object _lock = new();

        private Exam _currentExam;
        private ExamResult? _lastResult;
        private StudentProfile _studentProfile;

        public ExamService(IQuestionGenerator questionGenerator)
        {
            _questionGenerator = questionGenerator;
            _currentExam = new Exam
            {
                Id = "SIM-2026-01",
                Title = "Simulado Oficial - Geometria Espacial & Plana",
                Questions = _questionGenerator.GenerateExamQuestions()
            };

            _studentProfile = new StudentProfile
            {
                Name = "Carlos Eduardo",
                Level = "Nível 4 • Intermediário Avançado",
                TotalXp = 1240,
                OverallProgress = 75,
                ActiveGoal = "Desafio 10/10: Obtenha 100% de precisão para desbloquear a Certificação Oficial em Geometria Euclidiana.",
                Modules = new List<ModuleProgress>
                {
                    new ModuleProgress
                    {
                        Id = 1,
                        Title = "1. Medidas & Conversões",
                        Description = "Unidades fundamentais de comprimento, área superficial e volume tridimensional no SI.",
                        FormulaPreview = "1 km = 1.000 m  |  1 m² = 10.000 cm²  |  1 m³ = 1.000 L",
                        Percentage = 100,
                        IsCurrent = false,
                        EstimatedTime = "12/12 lições completas",
                        Icon = "square_foot"
                    },
                    new ModuleProgress
                    {
                        Id = 2,
                        Title = "2. Área e Perímetro do Quadrado e Retângulo",
                        Description = "Propriedades analíticas dos quadriláteros notáveis, ortogonalidade e relações de escala.",
                        FormulaPreview = "P = 2·(b + h)  |  A = b · h  |  A_quad = L²",
                        Percentage = 100,
                        IsCurrent = false,
                        EstimatedTime = "8/8 lições completas",
                        Icon = "crop_square"
                    },
                    new ModuleProgress
                    {
                        Id = 3,
                        Title = "3. Círculo e Circunferência",
                        Description = "Geometria euclidiana circular, determinação analítica de raio, diâmetro, comprimento e coroa.",
                        FormulaPreview = "C = 2·π·r  |  A = π·r²  |  A_coroa = π·(R² - r²)",
                        Percentage = 75,
                        IsCurrent = true,
                        EstimatedTime = "6/8 lições (Próxima: O Raio e o Diâmetro)",
                        Icon = "radio_button_unchecked"
                    },
                    new ModuleProgress
                    {
                        Id = 4,
                        Title = "4. Triângulos e Pitágoras",
                        Description = "Relações métricas no triângulo retângulo, cálculo de hipotenusa e áreas triangulares gerais.",
                        FormulaPreview = "a² + b² = c²  |  A = (b · h) / 2",
                        Percentage = 0,
                        IsCurrent = false,
                        EstimatedTime = "0/6 lições (Bloqueado)",
                        Icon = "change_history"
                    },
                    new ModuleProgress
                    {
                        Id = 5,
                        Title = "5. Figuras Compostas & Decomposição",
                        Description = "Particionamento e integração de polígonos irregulares e superfícies arquitetônicas.",
                        FormulaPreview = "A_total = ∑ A_i  |  Decomposição ortogonal",
                        Percentage = 0,
                        IsCurrent = false,
                        EstimatedTime = "0/5 lições (Bloqueado)",
                        Icon = "dashboard_customize"
                    }
                }
            };

            // Gera um resultado padrão realista para que Gabarito tenha dados imediatos se acessado
            InitDefaultResult();
        }

        private void InitDefaultResult()
        {
            // Simula uma tentativa anterior fiel ao Stitch Design (ex: 7 acertos de 10)
            var sampleAnswers = new Dictionary<int, string>
            {
                { 1, "B" }, // Certo
                { 2, "C" }, // Certo
                { 3, "B" }, // Certo
                { 4, "C" }, // Errou: marcou C (314 m²) em vez de B (78,5 m²)
                { 5, "B" }, // Certo
                { 6, "A" }, // Errou: marcou 350 cm² em vez de 35.000 cm²
                { 7, "B" }, // Certo
                { 8, "B" }, // Certo
                { 9, "A" }, // Errou: marcou 87,92 em vez de 138,16
                { 10, "B" } // Certo
            };
            _lastResult = EvaluateExam(sampleAnswers, 760);
        }

        public StudentProfile GetStudentProfile()
        {
            lock (_lock)
            {
                return _studentProfile;
            }
        }

        public Exam GetCurrentExam()
        {
            lock (_lock)
            {
                return _currentExam;
            }
        }

        public Exam CreateNewExam()
        {
            lock (_lock)
            {
                _currentExam = new Exam
                {
                    Id = $"SIM-{DateTime.UtcNow:yyyyMMdd-HHmmss}",
                    Title = "Simulado Oficial - Geometria Espacial & Plana",
                    CreatedAt = DateTime.UtcNow,
                    Questions = _questionGenerator.GenerateExamQuestions()
                };
                return _currentExam;
            }
        }

        public ExamResult EvaluateExam(Dictionary<int, string> submittedAnswers, int elapsedSeconds)
        {
            lock (_lock)
            {
                var evaluations = new List<QuestionEvaluation>();

                foreach (var q in _currentExam.Questions)
                {
                    var selectedKey = submittedAnswers.ContainsKey(q.Number) ? submittedAnswers[q.Number]?.Trim().ToUpperInvariant() ?? "" : "";
                    var selectedOption = q.Options.FirstOrDefault(o => o.Key == selectedKey);
                    var correctOption = q.Options.FirstOrDefault(o => o.Key == q.CorrectOptionKey);

                    bool isCorrect = selectedKey == q.CorrectOptionKey;

                    evaluations.Add(new QuestionEvaluation
                    {
                        Question = q,
                        SelectedOptionKey = selectedKey,
                        SelectedOptionText = selectedOption != null ? $"{selectedOption.Key}) {selectedOption.Text}" : "Não respondida",
                        CorrectOptionText = correctOption != null ? $"{correctOption.Key}) {correctOption.Text}" : "",
                        IsCorrect = isCorrect
                    });
                }

                var result = new ExamResult
                {
                    ExamId = _currentExam.Id,
                    CompletedAt = DateTime.UtcNow,
                    ElapsedSeconds = elapsedSeconds > 0 ? elapsedSeconds : 760,
                    Evaluations = evaluations
                };

                // Atualiza perfil do aluno
                _studentProfile.TotalXp += result.GainedXp;
                if (result.IsApproved)
                {
                    _studentProfile.TotalXp += 500; // Bônus 10/10
                    _studentProfile.OverallProgress = 100;
                    var cModule = _studentProfile.Modules.FirstOrDefault(m => m.Id == 3);
                    if (cModule != null)
                    {
                        cModule.Percentage = 100;
                        cModule.EstimatedTime = "8/8 lições completas (Certificado liberado)";
                    }
                }

                _studentProfile.RecentAttempts.Insert(0, result);
                if (_studentProfile.RecentAttempts.Count > 10)
                {
                    _studentProfile.RecentAttempts.RemoveAt(_studentProfile.RecentAttempts.Count - 1);
                }

                _lastResult = result;
                return result;
            }
        }

        public ExamResult? GetLastResult()
        {
            lock (_lock)
            {
                return _lastResult;
            }
        }

        public Question? GetQuestion(string questionId)
        {
            lock (_lock)
            {
                return _currentExam.Questions.FirstOrDefault(q => q.Id.Equals(questionId, StringComparison.OrdinalIgnoreCase) || q.Number.ToString() == questionId);
            }
        }
    }
}
