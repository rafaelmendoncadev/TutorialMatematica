using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Logging;
using TutorialMatematica.Models;
using TutorialMatematica.Services;

namespace TutorialMatematica.Controllers
{
    public class HomeController : Controller
    {
        private readonly IExamService _examService;
        private readonly IGeminiTutorService _geminiTutorService;
        private readonly ILogger<HomeController> _logger;

        public HomeController(
            IExamService examService,
            IGeminiTutorService geminiTutorService,
            ILogger<HomeController> logger)
        {
            _examService = examService;
            _geminiTutorService = geminiTutorService;
            _logger = logger;
        }

        // 1. DASHBOARD PRINCIPAL
        public IActionResult Index()
        {
            var profile = _examService.GetStudentProfile();
            return View(profile);
        }

        // 2. AULAS & CONTEÚDO TEÓRICO
        public IActionResult Aulas()
        {
            var profile = _examService.GetStudentProfile();
            return View(profile);
        }

        // 3. SIMULADO DE 10 QUESTÕES
        public IActionResult Simulado()
        {
            var exam = _examService.GetCurrentExam();
            return View(exam);
        }

        // 4. SUBMISSÃO DO SIMULADO
        [HttpPost]
        public IActionResult ConcluirSimulado(int tempoSegundos)
        {
            var submittedAnswers = new Dictionary<int, string>();

            // Suporta leitura direta tanto de form collection ("respostas[1]" ou "q1", etc) quanto de model binding
            foreach (var key in Request.Form.Keys)
            {
                if (key.StartsWith("respostas[") && key.EndsWith("]"))
                {
                    var numStr = key.Substring(10, key.Length - 11);
                    if (int.TryParse(numStr, out int qNum))
                    {
                        submittedAnswers[qNum] = Request.Form[key].ToString();
                    }
                }
                else if (key.StartsWith("q", StringComparison.OrdinalIgnoreCase))
                {
                    var numStr = key.Substring(1);
                    if (int.TryParse(numStr, out int qNum))
                    {
                        submittedAnswers[qNum] = Request.Form[key].ToString();
                    }
                }
            }

            _logger.LogInformation("Simulado submetido com {Count} respostas e {Tempo}s", submittedAnswers.Count, tempoSegundos);
            _examService.EvaluateExam(submittedAnswers, tempoSegundos);

            return RedirectToAction(nameof(Gabarito));
        }

        // 5. GABARITO & ANÁLISE DE DESEMPENHO
        public IActionResult Gabarito()
        {
            var result = _examService.GetLastResult();
            if (result == null)
            {
                return RedirectToAction(nameof(Simulado));
            }
            return View(result);
        }

        // 6. GERAR NOVA PROVA PROCEDURAL
        [HttpPost]
        public IActionResult NovaProva()
        {
            _examService.CreateNewExam();
            return RedirectToAction(nameof(Simulado));
        }

        // 7. TUTOR IA - CHAT INTERATIVO COM GEMINI
        [HttpPost]
        public async Task<IActionResult> PerguntarTutor([FromBody] TutorChatRequest req)
        {
            if (req == null || string.IsNullOrWhiteSpace(req.QuestionId))
            {
                return BadRequest(new { success = false, errorMessage = "ID da questão não informado." });
            }

            var response = await _geminiTutorService.AskTutorAsync(req);
            return Json(response);
        }

        public IActionResult Privacy()
        {
            return View();
        }

        [ResponseCache(Duration = 0, Location = ResponseCacheLocation.None, NoStore = true)]
        public IActionResult Error()
        {
            return View(new ErrorViewModel { RequestId = Activity.Current?.Id ?? HttpContext.TraceIdentifier });
        }
    }
}
