using System;
using System.Linq;
using System.Net.Http;
using System.Text;
using System.Text.Json;
using System.Threading.Tasks;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.Logging;
using TutorialMatematica.Models;

namespace TutorialMatematica.Services
{
    public class GeminiTutorService : IGeminiTutorService
    {
        private readonly IHttpClientFactory _httpClientFactory;
        private readonly IConfiguration _configuration;
        private readonly IExamService _examService;
        private readonly ILogger<GeminiTutorService> _logger;

        public GeminiTutorService(
            IHttpClientFactory httpClientFactory,
            IConfiguration configuration,
            IExamService examService,
            ILogger<GeminiTutorService> logger)
        {
            _httpClientFactory = httpClientFactory;
            _configuration = configuration;
            _examService = examService;
            _logger = logger;
        }

        public async Task<TutorChatResponse> AskTutorAsync(TutorChatRequest request)
        {
            var question = _examService.GetQuestion(request.QuestionId);
            if (question == null)
            {
                return new TutorChatResponse
                {
                    Success = false,
                    ErrorMessage = "Questão não encontrada no contexto do exame atual."
                };
            }

            var apiKey = Environment.GetEnvironmentVariable("GEMINI_API_KEY") ?? _configuration["Gemini:ApiKey"];
            var model = _configuration["Gemini:Model"] ?? "gemini-2.5-flash";

            var optionsText = string.Join("\n", question.Options.Select(o => $"[{o.Key}] {o.Text}"));
            var studentOption = !string.IsNullOrWhiteSpace(request.SelectedOptionKey)
                ? question.Options.FirstOrDefault(o => o.Key.Equals(request.SelectedOptionKey, StringComparison.OrdinalIgnoreCase))
                : null;

            var studentChoiceInfo = studentOption != null
                ? $"O aluno escolheu a alternativa: [{studentOption.Key}] {studentOption.Text} (Gabarito correto: [{question.CorrectOptionKey}])."
                : "O aluno ainda não marcou nenhuma alternativa ou solicitou ajuda prévia.";

            var promptBuilder = new StringBuilder();
            promptBuilder.AppendLine("Você é o Tutor de IA da plataforma de Geometria e Matemática Interativa.");
            promptBuilder.AppendLine("Seu papel é responder didaticamente, em português claro, acolhedor e com rigor matemático, tirando dúvidas do aluno.");
            promptBuilder.AppendLine("Evite dar apenas a resposta final sem reflexão; mostre o raciocínio geométrico por trás dos cálculos.");
            promptBuilder.AppendLine();
            promptBuilder.AppendLine("--- CONTEXTO DA QUESTÃO ---");
            promptBuilder.AppendLine($"Tópico: {question.Topic} - {question.SubTopic}");
            promptBuilder.AppendLine($"Enunciado: {question.Statement}");
            promptBuilder.AppendLine($"Fórmula / Resumo: {question.ParameterSummary}");
            promptBuilder.AppendLine("Alternativas disponíveis:");
            promptBuilder.AppendLine(optionsText);
            promptBuilder.AppendLine($"Gabarito Oficial: {question.CorrectOptionKey}");
            promptBuilder.AppendLine($"Passo 1 oficial: {question.ExplanationStep1}");
            promptBuilder.AppendLine($"Passo 2 oficial: {question.ExplanationStep2}");
            promptBuilder.AppendLine($"Armadilha conceitual: {question.ConceptualTrap}");
            promptBuilder.AppendLine(studentChoiceInfo);
            promptBuilder.AppendLine();
            promptBuilder.AppendLine("--- DÚVIDA / MENSAGEM DO ALUNO ---");
            promptBuilder.AppendLine(string.IsNullOrWhiteSpace(request.Message) ? "Por favor, explique passo a passo como resolver esta questão e qual é o erro mais comum." : request.Message);
            promptBuilder.AppendLine();
            promptBuilder.AppendLine("Instrução de resposta: Seja conciso (2 a 3 parágrafos curtos ou tópicos organizados), use formatação limpa e dê destaque às fórmulas matemáticas com clareza.");

            if (!string.IsNullOrWhiteSpace(apiKey))
            {
                try
                {
                    var client = _httpClientFactory.CreateClient();
                    client.Timeout = TimeSpan.FromSeconds(15);

                    var requestUri = $"https://generativelanguage.googleapis.com/v1beta/models/{model}:generateContent?key={apiKey}";

                    var requestPayload = new
                    {
                        contents = new[]
                        {
                            new
                            {
                                parts = new[]
                                {
                                    new { text = promptBuilder.ToString() }
                                }
                            }
                        },
                        generationConfig = new
                        {
                            temperature = 0.4,
                            maxOutputTokens = 1000
                        }
                    };

                    var jsonContent = new StringContent(
                        JsonSerializer.Serialize(requestPayload),
                        Encoding.UTF8,
                        "application/json");

                    var response = await client.PostAsync(requestUri, jsonContent);
                    var responseBody = await response.Content.ReadAsStringAsync();

                    if (response.IsSuccessStatusCode)
                    {
                        using var doc = JsonDocument.Parse(responseBody);
                        var candidates = doc.RootElement.GetProperty("candidates");
                        if (candidates.GetArrayLength() > 0)
                        {
                            var firstCandidate = candidates[0];
                            var parts = firstCandidate.GetProperty("content").GetProperty("parts");
                            if (parts.GetArrayLength() > 0)
                            {
                                var answerText = parts[0].GetProperty("text").GetString();
                                if (!string.IsNullOrWhiteSpace(answerText))
                                {
                                    return new TutorChatResponse
                                    {
                                        Success = true,
                                        Answer = answerText.Trim()
                                    };
                                }
                            }
                        }
                    }
                    else
                    {
                        _logger.LogWarning("Gemini API call failed with status {StatusCode}: {ResponseBody}", response.StatusCode, responseBody);
                    }
                }
                catch (Exception ex)
                {
                    _logger.LogError(ex, "Exception calling Gemini API. Falling back to local didactic explanation.");
                }
            }

            // Fallback didático robusto e pedagógico baseado nas propriedades da questão
            var fallbackAnswer = new StringBuilder();
            fallbackAnswer.AppendLine($"Olá! Sou seu Tutor de Matemática para **{question.Topic}**.");
            fallbackAnswer.AppendLine();
            fallbackAnswer.AppendLine($"📌 **Raciocínio Geométrico:** {question.TutorHint}");
            fallbackAnswer.AppendLine();
            fallbackAnswer.AppendLine($"📐 **Resolução Passo a Passo:**");
            fallbackAnswer.AppendLine($"• {question.ExplanationStep1}");
            fallbackAnswer.AppendLine($"• {question.ExplanationStep2}");
            fallbackAnswer.AppendLine();
            fallbackAnswer.AppendLine($"⚠️ **Atenção à Pegadinha:** {question.ConceptualTrap}");
            fallbackAnswer.AppendLine();
            fallbackAnswer.AppendLine($"A alternativa correta é a **{question.CorrectOptionKey}**.");

            return new TutorChatResponse
            {
                Success = true,
                Answer = fallbackAnswer.ToString()
            };
        }
    }
}
