using System;
using System.Collections.Generic;
using TutorialMatematica.Models;

namespace TutorialMatematica.Services
{
    public class QuestionGenerator : IQuestionGenerator
    {
        public List<Question> GenerateExamQuestions()
        {
            var questions = new List<Question>();

            // QUESTÃO 1: CONVERSÃO DE MEDIDAS LINEARES
            questions.Add(new Question
            {
                Number = 1,
                Id = "Q01",
                Topic = "CONVERSÃO DE MEDIDAS",
                SubTopic = "Unidades de Comprimento e Deslocamento",
                TechnicalBadge = "SISTEMA MÉTRICO DECIMAL",
                TechnicalTitle = "Conversão Linear Quilômetro - Metro",
                TechnicalDescription = "Análise dimensional de grandezas escalares lineares em provas de atletismo.",
                ParameterSummary = "Distância total: 4,25 km | Percorrido: 2.750 m | Fator de conversão: 1 km = 1.000 m",
                Statement = "Um atleta está participando de um treino de longa distância cujo percurso total é de exatamente 4,25 quilômetros (km). Ao consultar seu relógio esportivo com GPS, ele nota que já percorreu 2.750 metros (m). Quantos metros ainda faltam para que ele conclua todo o percurso planejado?",
                TutorHint = "Para operar grandezas físicas diferentes, lembre-se de converter tudo para a mesma unidade: 1 km possui 1.000 metros. Multiplique 4,25 por 1.000 e subtraia os 2.750 m já percorridos.",
                DiagramSvg = @"<svg viewBox='0 0 400 160' class='w-full h-full' xmlns='http://www.w3.org/2000/svg'>
  <defs>
    <linearGradient id='trackGrad' x1='0%' y1='0%' x2='100%' y2='0%'>
      <stop offset='0%' stop-color='#00288E' />
      <stop offset='65%' stop-color='#4E45D5' />
      <stop offset='100%' stop-color='#CBD5E1' />
    </linearGradient>
  </defs>
  <rect width='400' height='160' fill='#FAF8FF' rx='8' />
  <line x1='40' y1='80' x2='360' y2='80' stroke='#E2E8F0' stroke-width='10' stroke-linecap='round' />
  <line x1='40' y1='80' x2='250' y2='80' stroke='url(#trackGrad)' stroke-width='10' stroke-linecap='round' />
  <!-- Início -->
  <circle cx='40' cy='80' r='8' fill='#00288E' />
  <text x='40' y='110' text-anchor='middle' font-size='11' font-weight='bold' fill='#00288E' font-family='Plus Jakarta Sans, sans-serif'>0 m (Partida)</text>
  <!-- Ponto atual -->
  <circle cx='250' cy='80' r='8' fill='#4E45D5' stroke='#FFFFFF' stroke-width='2' />
  <text x='250' y='55' text-anchor='middle' font-size='11' font-weight='bold' fill='#4E45D5' font-family='Plus Jakarta Sans, sans-serif'>2.750 m percorridos</text>
  <!-- Restante -->
  <path d='M 255 75 Q 305 60 355 75' fill='none' stroke='#DC2626' stroke-width='2' stroke-dasharray='4 3' />
  <text x='305' y='50' text-anchor='middle' font-size='11' font-weight='bold' fill='#DC2626' font-family='Plus Jakarta Sans, sans-serif'>Restante = ?</text>
  <!-- Fim -->
  <circle cx='360' cy='80' r='8' fill='#64748B' />
  <text x='360' y='110' text-anchor='middle' font-size='11' font-weight='bold' fill='#475569' font-family='Plus Jakarta Sans, sans-serif'>4,25 km (Chegada)</text>
</svg>",
                Options = new List<QuestionOption>
                {
                    new QuestionOption { Key = "A", Text = "Faltam 1.250 metros" },
                    new QuestionOption { Key = "B", Text = "Faltam 1.500 metros" },
                    new QuestionOption { Key = "C", Text = "Faltam 1.750 metros" },
                    new QuestionOption { Key = "D", Text = "Faltam 2.500 metros" }
                },
                CorrectOptionKey = "B",
                ExplanationStep1 = "1. Conversão de unidades: 1 km equivale a 1.000 metros. Logo, 4,25 km = 4,25 × 1.000 m = 4.250 metros de percurso total.",
                ExplanationStep2 = "2. Subtração do percurso restante: 4.250 m (total) - 2.750 m (percorridos) = 1.500 metros faltantes.",
                ConceptualTrap = "Pegadinha comum: Tentar subtrair 4,25 de 2.750 diretamente sem harmonizar as unidades métricas, ou errar a conversão multiplicando por 100 em vez de 1.000."
            });

            // QUESTÃO 2: PERÍMETRO DE TERRENO RETANGULAR E MULTIPLICAÇÃO
            questions.Add(new Question
            {
                Number = 2,
                Id = "Q02",
                Topic = "GEOMETRIA PLANA",
                SubTopic = "Perímetro de Retângulos e Aplicações Práticas",
                TechnicalBadge = "TOPOGRAFIA & CONSTRUÇÃO",
                TechnicalTitle = "Perímetro Poligonal e Repetição Linear",
                TechnicalDescription = "Cálculo de fechamento perimétrico composto por múltiplas voltas de contenção.",
                ParameterSummary = "Comprimento: 32 m | Largura: 18 m | Voltas de arame: 4 | Fórmulas: 2·(b + h)",
                Statement = "Um agricultor necessita cercar integralmente um terreno retangular que possui 32 metros de comprimento por 18 metros de largura. A cerca deve ser estruturada com exatamente 4 voltas completas de arame farpado em torno de toda a extensão do terreno. Quantos metros lineares de arame serão necessários no mínimo?",
                TutorHint = "Calcule primeiro o perímetro de uma única volta somando todos os 4 lados do retângulo: P = 2 × (comprimento + largura). Depois, multiplique o resultado pela quantidade de voltas (4).",
                DiagramSvg = @"<svg viewBox='0 0 400 160' class='w-full h-full' xmlns='http://www.w3.org/2000/svg'>
  <rect width='400' height='160' fill='#FAF8FF' rx='8' />
  <rect x='60' y='30' width='280' height='90' fill='#EEF2FF' stroke='#00288E' stroke-width='3' rx='4' stroke-dasharray='6 3' />
  <!-- Cotas -->
  <text x='200' y='22' text-anchor='middle' font-size='12' font-weight='bold' fill='#00288E' font-family='Plus Jakarta Sans, sans-serif'>Comprimento = 32 m</text>
  <text x='200' y='138' text-anchor='middle' font-size='12' font-weight='bold' fill='#00288E' font-family='Plus Jakarta Sans, sans-serif'>Comprimento = 32 m</text>
  <text x='40' y='80' text-anchor='middle' font-size='12' font-weight='bold' fill='#4E45D5' font-family='Plus Jakarta Sans, sans-serif' transform='rotate(-90 40 80)'>18 m</text>
  <text x='360' y='80' text-anchor='middle' font-size='12' font-weight='bold' fill='#4E45D5' font-family='Plus Jakarta Sans, sans-serif' transform='rotate(90 360 80)'>18 m</text>
  <rect x='130' y='60' width='140' height='30' fill='#00288E' rx='6' />
  <text x='200' y='80' text-anchor='middle' font-size='11' font-weight='bold' fill='#FFFFFF' font-family='Inter, sans-serif'>4 voltas de cerca</text>
</svg>",
                Options = new List<QuestionOption>
                {
                    new QuestionOption { Key = "A", Text = "100 metros" },
                    new QuestionOption { Key = "B", Text = "200 metros" },
                    new QuestionOption { Key = "C", Text = "400 metros" },
                    new QuestionOption { Key = "D", Text = "576 metros" }
                },
                CorrectOptionKey = "C",
                ExplanationStep1 = "1. Cálculo do perímetro de uma volta: P = 2 × (32 m + 18 m) = 2 × 50 m = 100 metros de contorno.",
                ExplanationStep2 = "2. Multiplicação pelas 4 voltas de arame: Comprimento total = 100 m × 4 voltas = 400 metros.",
                ConceptualTrap = "Pegadinha comum: Calcular a área (32 × 18 = 576 m²) ao invés do perímetro, ou esquecer de multiplicar as 4 voltas do arame (marcando 100 m)."
            });

            // QUESTÃO 3: ÁREA DE QUADRADO E VARIAÇÃO QUADRÁTICA
            questions.Add(new Question
            {
                Number = 3,
                Id = "Q03",
                Topic = "GEOMETRIA PLANA",
                SubTopic = "Variação de Área Quadrática e Escala",
                TechnicalBadge = "PROPRIEDADES DIMENSIONAIS",
                TechnicalTitle = "Escala Bidimensional e Área de Quadrados",
                TechnicalDescription = "Relação quadrática entre a variação linear do lado e a variação superficial da área.",
                ParameterSummary = "Lado original: 25 m | Fator de aumento do lado: 2x | Área original: 625 m²",
                Statement = "Uma praça comunitária tem formato quadrado com 25 metros de lado. Como parte do plano de revitalização urbana, o setor de engenharia decidiu duplicar a medida de cada um dos lados da praça (isto é, multiplicar o lado por 2). Qual será a nova área da praça e qual foi o fator de aumento superficial em relação à área inicial?",
                TutorHint = "Se o lado do quadrado dobra de L para 2L, a nova área é (2L)² = 4L². Portanto, a área é quadruplicada (multiplicada por 4, aumento de 300%).",
                DiagramSvg = @"<svg viewBox='0 0 400 160' class='w-full h-full' xmlns='http://www.w3.org/2000/svg'>
  <rect width='400' height='160' fill='#FAF8FF' rx='8' />
  <!-- Quadrado Inicial -->
  <rect x='50' y='50' width='60' height='60' fill='#C7D2FE' stroke='#00288E' stroke-width='2' />
  <text x='80' y='42' text-anchor='middle' font-size='10' font-weight='bold' fill='#00288E'>L = 25m</text>
  <text x='80' y='85' text-anchor='middle' font-size='10' font-weight='bold' fill='#00288E'>625 m²</text>
  <!-- Seta -->
  <path d='M 130 80 L 170 80 M 160 72 L 170 80 L 160 88' stroke='#4E45D5' stroke-width='3' fill='none' stroke-linecap='round' />
  <text x='150' y='105' text-anchor='middle' font-size='11' font-weight='bold' fill='#4E45D5'>×2 no lado</text>
  <!-- Quadrado Duplicado (4 quadrantes) -->
  <g transform='translate(200, 20)'>
    <rect x='0' y='0' width='60' height='60' fill='#818CF8' stroke='#00288E' stroke-width='1.5' />
    <rect x='60' y='0' width='60' height='60' fill='#A5B4FC' stroke='#00288E' stroke-width='1.5' />
    <rect x='0' y='60' width='60' height='60' fill='#A5B4FC' stroke='#00288E' stroke-width='1.5' />
    <rect x='60' y='60' width='60' height='60' fill='#C7D2FE' stroke='#00288E' stroke-width='1.5' />
    <text x='60' y='135' text-anchor='middle' font-size='11' font-weight='bold' fill='#00288E'>Novo Lado = 50 m (Área = 2.500 m² = 4x)</text>
  </g>
</svg>",
                Options = new List<QuestionOption>
                {
                    new QuestionOption { Key = "A", Text = "Nova área: 1.250 m² (a área duplicou)" },
                    new QuestionOption { Key = "B", Text = "Nova área: 2.500 m² (a área quadruplicou)" },
                    new QuestionOption { Key = "C", Text = "Nova área: 3.125 m² (a área quintuplicou)" },
                    new QuestionOption { Key = "D", Text = "Nova área: 5.000 m² (a área octuplicou)" }
                },
                CorrectOptionKey = "B",
                ExplanationStep1 = "1. Área inicial: A1 = 25 m × 25 m = 625 m².",
                ExplanationStep2 = "2. Novo lado duplicado: L2 = 25 m × 2 = 50 m. Nova área: A2 = 50 m × 50 m = 2.500 m². Como 2.500 / 625 = 4, a área quadruplicou.",
                ConceptualTrap = "Pegadinha clássica: Achar que se as dimensões lineares dobram, a área também dobra (2 × 625 = 1.250). A área varia com o quadrado da escala (2² = 4)."
            });

            // QUESTÃO 4: CANTEIRO CIRCULAR - EXATO DO DESIGN STITCH!
            questions.Add(new Question
            {
                Number = 4,
                Id = "Q04",
                Topic = "GEOMETRIA PLANA",
                SubTopic = "Círculo e Circunferência",
                TechnicalBadge = "ENGENHARIA & ARQUITETURA",
                TechnicalTitle = "Geometria Euclidiana Plana",
                TechnicalDescription = "Considere um canteiro perfeitamente circular de raio r = 5,00 m sobre superfície plana. Adote a aproximação padrão π ≈ 3,14 para os cálculos analíticos de comprimento e área.",
                ParameterSummary = "Raio (r): 5,00 m | Constante π: 3,14 | Tolerância: ±0,01 m",
                Statement = "Um arquiteto está projetando um canteiro circular com raio de 5 metros. Ele precisa instalar uma grade de proteção em toda a volta e cobrir o interior com grama sintética. Considerando π = 3,14, determine o comprimento da grade e a área total da grama.",
                TutorHint = "Lembre-se: o comprimento do círculo representa o perímetro (uma dimensão linear, 2·π·r) e a área representa a superfície bidimensional (π·r²).",
                DiagramSvg = @"<svg viewBox='0 0 400 240' class='w-full h-full' xmlns='http://www.w3.org/2000/svg'>
  <defs>
    <radialGradient id='gardenGrad' cx='50%' cy='50%' r='50%'>
      <stop offset='0%' stop-color='#34D399' stop-opacity='0.25' />
      <stop offset='85%' stop-color='#059669' stop-opacity='0.2' />
      <stop offset='100%' stop-color='#047857' stop-opacity='0.4' />
    </radialGradient>
  </defs>
  <!-- Fundo com grid sutil -->
  <rect width='400' height='240' fill='#FAF8FF' rx='8' />
  <pattern id='gridSim' width='20' height='20' patternUnits='userSpaceOnUse'>
    <path d='M 20 0 L 0 0 0 20' fill='none' stroke='#E2E8F0' stroke-width='0.5' />
  </pattern>
  <rect width='400' height='240' fill='url(#gridSim)' rx='8' />

  <!-- Eixos coordenados -->
  <line x1='30' y1='120' x2='370' y2='120' stroke='#CBD5E1' stroke-width='1' stroke-dasharray='3 3' />
  <line x1='200' y1='20' x2='200' y2='220' stroke='#CBD5E1' stroke-width='1' stroke-dasharray='3 3' />

  <!-- Canteiro Circular -->
  <circle cx='200' cy='120' r='75' fill='url(#gardenGrad)' stroke='#00288E' stroke-width='3' />
  
  <!-- Cota do Raio (r = 5m) -->
  <line x1='200' y1='120' x2='275' y2='120' stroke='#00288E' stroke-width='2.5' marker-end='url(#arrow)' />
  <circle cx='200' cy='120' r='4' fill='#00288E' />
  <circle cx='275' cy='120' r='4' fill='#00288E' />

  <!-- Labels didáticos no SVG -->
  <rect x='215' y='96' width='55' height='20' fill='#FFFFFF' rx='4' stroke='#00288E' stroke-width='1' />
  <text x='242' y='110' text-anchor='middle' font-size='11' font-weight='bold' fill='#00288E' font-family='JetBrains Mono, monospace'>r = 5 m</text>

  <rect x='130' y='145' width='140' height='26' fill='#059669' rx='6' />
  <text x='200' y='162' text-anchor='middle' font-size='11' font-weight='bold' fill='#FFFFFF' font-family='Plus Jakarta Sans, sans-serif'>Grama: Área (A = πr²)</text>

  <text x='200' y='32' text-anchor='middle' font-size='12' font-weight='bold' fill='#00288E' font-family='Plus Jakarta Sans, sans-serif'>Grade de Proteção: Perímetro (C = 2πr)</text>
</svg>",
                Options = new List<QuestionOption>
                {
                    new QuestionOption { Key = "A", Text = "Comprimento: 15,7 m | Área: 78,5 m²" },
                    new QuestionOption { Key = "B", Text = "Comprimento: 31,4 m | Área: 78,5 m²" },
                    new QuestionOption { Key = "C", Text = "Comprimento: 31,4 m | Área: 314,0 m²" },
                    new QuestionOption { Key = "D", Text = "Comprimento: 62,8 m | Área: 157,0 m²" }
                },
                CorrectOptionKey = "B",
                ExplanationStep1 = "1. Comprimento da Circunferência (Grade): O perímetro é dado por C = 2 · π · r. Substituindo os valores: C = 2 · 3,14 · 5 = 31,4 metros.",
                ExplanationStep2 = "2. Área do Círculo (Grama): A área é dada por A = π · r². Calculando: A = 3,14 · (5)² = 3,14 · 25 = 78,5 m².",
                ConceptualTrap = "Pegadinha comum: Confundir o cálculo de perímetro C = 2πr com a área A = πr², ou esquecer de elevar o raio ao quadrado na fórmula da área (fazendo 2·π·r em vez de π·r²)."
            });

            // QUESTÃO 5: TEOREMA DE PITÁGORAS EM RAMPA
            questions.Add(new Question
            {
                Number = 5,
                Id = "Q05",
                Topic = "TRIGONOMETRIA & PITÁGORAS",
                SubTopic = "Teorema de Pitágoras no Triângulo Retângulo",
                TechnicalBadge = "ACESSIBILIDADE NORMA NBR 9050",
                TechnicalTitle = "Relações Métricas no Triângulo Retângulo",
                TechnicalDescription = "Dimensionamento estrutural do comprimento de viga inclinada a partir dos catetos ortogonais.",
                ParameterSummary = "Cateto vertical (altura): 0,80 m | Cateto horizontal (base): 1,50 m | a² + b² = c²",
                Statement = "Uma rampa de acessibilidade deve ser construída para vencer um desnível vertical de 0,80 metros entre a calçada e a porta de um edifício público. A projeção horizontal da rampa no solo é de 1,50 metros. Qual deve ser o comprimento exato da superfície inclinada por onde os pedestres irão subir?",
                TutorHint = "O desnível vertical e o solo formam um ângulo reto (90°). Use o Teorema de Pitágoras: Hipotenusa² = Cateto1² + Cateto2². Ou seja: c² = (0,80)² + (1,50)².",
                DiagramSvg = @"<svg viewBox='0 0 400 180' class='w-full h-full' xmlns='http://www.w3.org/2000/svg'>
  <rect width='400' height='180' fill='#FAF8FF' rx='8' />
  <!-- Triângulo -->
  <polygon points='60,140 320,140 320,40' fill='#EEF2FF' stroke='#00288E' stroke-width='2' />
  <!-- Ângulo Reto -->
  <rect x='305' y='125' width='15' height='15' fill='none' stroke='#00288E' stroke-width='1.5' />
  <circle cx='312' cy='132' r='2' fill='#00288E' />
  <!-- Hipotenusa Destaque -->
  <line x1='60' y1='140' x2='320' y2='40' stroke='#4E45D5' stroke-width='4' />
  <text x='180' y='75' text-anchor='middle' font-size='12' font-weight='bold' fill='#4E45D5' font-family='Plus Jakarta Sans, sans-serif'>Comprimento da Rampa (c) = ?</text>
  <!-- Catetos -->
  <text x='190' y='160' text-anchor='middle' font-size='11' font-weight='bold' fill='#00288E'>Base horizontal = 1,50 m</text>
  <text x='355' y='95' text-anchor='middle' font-size='11' font-weight='bold' fill='#00288E'>h = 0,80 m</text>
</svg>",
                Options = new List<QuestionOption>
                {
                    new QuestionOption { Key = "A", Text = "1,60 metro" },
                    new QuestionOption { Key = "B", Text = "1,70 metro" },
                    new QuestionOption { Key = "C", Text = "1,90 metro" },
                    new QuestionOption { Key = "D", Text = "2,30 metros" }
                },
                CorrectOptionKey = "B",
                ExplanationStep1 = "1. Aplicação do Teorema de Pitágoras: c² = a² + b² → c² = (0,80)² + (1,50)² = 0,64 + 2,25 = 2,89.",
                ExplanationStep2 = "2. Extração da raiz quadrada: c = √2,89 = 1,70 metro de extensão da rampa.",
                ConceptualTrap = "Pegadinha comum: Somar simplesmente os dois catetos (0,80 + 1,50 = 2,30 m), esquecendo que o menor trajeto em linha reta é a hipotenusa."
            });

            // QUESTÃO 6: CONVERSÃO DE MEDIDAS DE ÁREA (m² para cm²)
            questions.Add(new Question
            {
                Number = 6,
                Id = "Q06",
                Topic = "CONVERSÃO DE MEDIDAS",
                SubTopic = "Unidades Superficiais e Áreas Bidimensionais",
                TechnicalBadge = "METROLOGIA INDUSTRIAL",
                TechnicalTitle = "Conversão de Unidades Superficiais (m² para cm²)",
                TechnicalDescription = "Fator multiplicador exponencial na passagem entre grandezas de área no Sistema Internacional.",
                ParameterSummary = "Área: 3,5 m² | Relação linear: 1 m = 100 cm | Relação de área: 1 m² = (100 cm)² = 10.000 cm²",
                Statement = "Uma chapa de aço inoxidável possui área superficial de 3,5 metros quadrados (m²). Para a programação de uma máquina de corte a laser que opera exclusivamente em centímetros quadrados, qual deve ser o valor exato registrado no sistema de controle?",
                TutorHint = "Cuidado com o expoente! Como 1 metro tem 100 centímetros, 1 m² é igual a 100 × 100 = 10.000 cm². Multiplique 3,5 por 10.000.",
                DiagramSvg = @"<svg viewBox='0 0 400 160' class='w-full h-full' xmlns='http://www.w3.org/2000/svg'>
  <rect width='400' height='160' fill='#FAF8FF' rx='8' />
  <rect x='60' y='30' width='100' height='100' fill='#EEF2FF' stroke='#00288E' stroke-width='2' />
  <text x='110' y='22' text-anchor='middle' font-size='10' font-weight='bold' fill='#00288E'>1 m (= 100 cm)</text>
  <text x='45' y='85' text-anchor='middle' font-size='10' font-weight='bold' fill='#00288E' transform='rotate(-90 45 85)'>1 m (= 100 cm)</text>
  <text x='110' y='75' text-anchor='middle' font-size='11' font-weight='bold' fill='#00288E'>1 m²</text>
  <text x='110' y='95' text-anchor='middle' font-size='10' fill='#4E45D5'>10.000 cm²</text>

  <path d='M 180 80 L 230 80 M 220 72 L 230 80 L 220 88' stroke='#4E45D5' stroke-width='3' fill='none' stroke-linecap='round' />
  <text x='205' y='65' text-anchor='middle' font-size='11' font-weight='bold' fill='#4E45D5'>× 10.000</text>

  <rect x='250' y='45' width='120' height='70' fill='#00288E' rx='6' />
  <text x='310' y='75' text-anchor='middle' font-size='12' font-weight='bold' fill='#FFFFFF'>3,5 m² = ?</text>
  <text x='310' y='95' text-anchor='middle' font-size='11' fill='#A5B4FC'>35.000 cm²</text>
</svg>",
                Options = new List<QuestionOption>
                {
                    new QuestionOption { Key = "A", Text = "350 cm²" },
                    new QuestionOption { Key = "B", Text = "3.500 cm²" },
                    new QuestionOption { Key = "C", Text = "35.000 cm²" },
                    new QuestionOption { Key = "D", Text = "350.000 cm²" }
                },
                CorrectOptionKey = "C",
                ExplanationStep1 = "1. Relação fundamental de áreas: 1 metro linear = 100 centímetros. Elevando ao quadrado para obter a área: (1 m)² = (100 cm)² → 1 m² = 10.000 cm².",
                ExplanationStep2 = "2. Conversão da chapa: 3,5 m² × 10.000 cm²/m² = 35.000 cm².",
                ConceptualTrap = "Pegadinha comum: Multiplicar por 100 (como se fosse comprimento linear) obtendo 350 cm², ou por 1.000 obtendo 3.500 cm²."
            });

            // QUESTÃO 7: ÁREA DE TRAPÉZIO (LOTEAMENTO URBANO)
            questions.Add(new Question
            {
                Number = 7,
                Id = "Q07",
                Topic = "GEOMETRIA PLANA",
                SubTopic = "Área de Quadriláteros Notáveis (Trapézio)",
                TechnicalBadge = "CADASTRO TÉCNICO IMOBILIÁRIO",
                TechnicalTitle = "Área de Trapézio Retângulo",
                TechnicalDescription = "Determinação da área útil de lote urbano delimitado por bases paralelas e testada perpendicular.",
                ParameterSummary = "Base maior (B): 28 m | Base menor (b): 16 m | Altura (h): 10 m | Fórmula: [(B+b)·h]/2",
                Statement = "Um lote urbano tem o formato exato de um trapézio retângulo. A frente do lote (base maior) mede 28 metros, o fundo (base menor paralela) mede 16 metros, e a lateral perpendicular que conecta ambas as bases mede 10 metros de profundidade. Qual é a área total desse lote em metros quadrados?",
                TutorHint = "A área do trapézio é a média das bases multiplicada pela altura: A = [(Base Maior + Base Menor) × Altura] / 2.",
                DiagramSvg = @"<svg viewBox='0 0 400 170' class='w-full h-full' xmlns='http://www.w3.org/2000/svg'>
  <rect width='400' height='170' fill='#FAF8FF' rx='8' />
  <polygon points='60,130 320,130 220,40 60,40' fill='#EEF2FF' stroke='#00288E' stroke-width='2.5' />
  <line x1='60' y1='40' x2='60' y2='130' stroke='#DC2626' stroke-width='2' stroke-dasharray='4 3' />
  <!-- Textos de cotas -->
  <text x='140' y='32' text-anchor='middle' font-size='11' font-weight='bold' fill='#00288E'>Base menor (b) = 16 m</text>
  <text x='190' y='150' text-anchor='middle' font-size='11' font-weight='bold' fill='#00288E'>Base maior (B) = 28 m</text>
  <text x='40' y='90' text-anchor='middle' font-size='11' font-weight='bold' fill='#DC2626' transform='rotate(-90 40 90)'>h = 10 m</text>
  <rect x='130' y='75' width='120' height='26' fill='#00288E' rx='4' />
  <text x='190' y='92' text-anchor='middle' font-size='11' font-weight='bold' fill='#FFFFFF'>Área = [(B+b)·h]/2</text>
</svg>",
                Options = new List<QuestionOption>
                {
                    new QuestionOption { Key = "A", Text = "180 m²" },
                    new QuestionOption { Key = "B", Text = "220 m²" },
                    new QuestionOption { Key = "C", Text = "260 m²" },
                    new QuestionOption { Key = "D", Text = "440 m²" }
                },
                CorrectOptionKey = "B",
                ExplanationStep1 = "1. Soma das bases: Base Maior (28 m) + Base Menor (16 m) = 44 metros.",
                ExplanationStep2 = "2. Aplicação da fórmula: A = (44 m × 10 m) / 2 = 440 / 2 = 220 m².",
                ConceptualTrap = "Pegadinha comum: Esquecer de dividir por 2 no final, resultando em 440 m² (que seria a área de um retângulo de dimensões 44 × 10)."
            });

            // QUESTÃO 8: VOLUME E CAPACIDADE EM LITROS
            questions.Add(new Question
            {
                Number = 8,
                Id = "Q08",
                Topic = "GEOMETRIA ESPACIAL",
                SubTopic = "Volume de Sólidos e Capacidade em Litros",
                TechnicalBadge = "HIDRÁULICA & SANEAMENTO",
                TechnicalTitle = "Capacidade Volumétrica do Paralelepípedo",
                TechnicalDescription = "Cálculo de volume tridimensional e equivalência entre metros cúbicos e litros de água.",
                ParameterSummary = "Comprimento: 2,5 m | Largura: 1,2 m | Profundidade: 1,0 m | 1 m³ = 1.000 litros",
                Statement = "Uma cisterna para armazenamento de água da chuva foi construída no formato de um paralelepípedo reto-retângulo com as seguintes dimensões internas: 2,5 metros de comprimento, 1,2 metros de largura e 1,0 metro de profundidade. Sabendo que 1 m³ equivale rigorosamente a 1.000 litros, qual é a capacidade volumétrica máxima dessa cisterna?",
                TutorHint = "O volume do paralelepípedo é o produto das 3 dimensões: V = Comprimento × Largura × Altura. Em seguida, multiplique o volume em m³ por 1.000 para obter os litros.",
                DiagramSvg = @"<svg viewBox='0 0 400 170' class='w-full h-full' xmlns='http://www.w3.org/2000/svg'>
  <rect width='400' height='170' fill='#FAF8FF' rx='8' />
  <!-- Isometria Caixa d'água -->
  <g transform='translate(80, 25)'>
    <!-- Face frontal -->
    <rect x='30' y='40' width='150' height='70' fill='#BAE6FD' fill-opacity='0.6' stroke='#00288E' stroke-width='2' />
    <!-- Face superior -->
    <polygon points='30,40 180,40 230,10 80,10' fill='#E0F2FE' stroke='#00288E' stroke-width='2' />
    <!-- Face lateral direita -->
    <polygon points='180,40 230,10 230,80 180,110' fill='#7DD3FC' fill-opacity='0.6' stroke='#00288E' stroke-width='2' />
    <!-- Cotas -->
    <text x='105' y='125' text-anchor='middle' font-size='10' font-weight='bold' fill='#00288E'>Comprimento: 2,5 m</text>
    <text x='225' y='55' text-anchor='middle' font-size='10' font-weight='bold' fill='#00288E'>Largura: 1,2 m</text>
    <text x='15' y='80' text-anchor='middle' font-size='10' font-weight='bold' fill='#00288E'>1,0 m</text>
  </g>
</svg>",
                Options = new List<QuestionOption>
                {
                    new QuestionOption { Key = "A", Text = "2.500 litros" },
                    new QuestionOption { Key = "B", Text = "3.000 litros" },
                    new QuestionOption { Key = "C", Text = "3.500 litros" },
                    new QuestionOption { Key = "D", Text = "4.200 litros" }
                },
                CorrectOptionKey = "B",
                ExplanationStep1 = "1. Cálculo do volume em m³: V = 2,5 m × 1,2 m × 1,0 m = 3,0 m³.",
                ExplanationStep2 = "2. Conversão para litros: Como 1 m³ = 1.000 L, Capacidade = 3,0 × 1.000 = 3.000 litros.",
                ConceptualTrap = "Pegadinha comum: Errar a multiplicação decimal (ex: calcular 2,5 × 1,2 = 3,5) ou esquecer que 1 m³ = 1.000 L (e não 100 L)."
            });

            // QUESTÃO 9: COROA CIRCULAR (PISTA DE CAMINHADA)
            questions.Add(new Question
            {
                Number = 9,
                Id = "Q09",
                Topic = "GEOMETRIA PLANA",
                SubTopic = "Coroa Circular e Círculos Concêntricos",
                TechnicalBadge = "PAISAGISMO & URBANISMO",
                TechnicalTitle = "Área da Região Anular (Coroa Circular)",
                TechnicalDescription = "Diferença entre as superfícies de dois círculos coplanares de mesmo centro geométrico.",
                ParameterSummary = "Raio interno (r): 10 m | Raio externo (R): 12 m | π ≈ 3,14 | Fórmula: A = π·(R² - r²)",
                Statement = "Uma pista de cooper circular foi instalada contornando uma praça também circular. O raio da praça interna é de 10 metros, e a pista possui largura uniforme de 2 metros (portanto, o raio externo totaliza 12 metros). Adotando π = 3,14, qual é a área asfaltada correspondente exclusivamente à pista de cooper?",
                TutorHint = "A área da coroa circular é a área do círculo maior menos a área do círculo menor: A = π × (R² - r²). Calcule (12² - 10²) e multiplique por 3,14.",
                DiagramSvg = @"<svg viewBox='0 0 400 180' class='w-full h-full' xmlns='http://www.w3.org/2000/svg'>
  <rect width='400' height='180' fill='#FAF8FF' rx='8' />
  <!-- Coroa -->
  <circle cx='200' cy='90' r='75' fill='#CBD5E1' stroke='#00288E' stroke-width='2' />
  <circle cx='200' cy='90' r='55' fill='#FAF8FF' stroke='#00288E' stroke-width='2' />
  <line x1='200' y1='90' x2='255' y2='90' stroke='#00288E' stroke-width='2' />
  <circle cx='200' cy='90' r='3' fill='#00288E' />
  <text x='227' y='82' text-anchor='middle' font-size='10' font-weight='bold' fill='#00288E'>r = 10m</text>
  <line x1='200' y1='90' x2='200' y2='15' stroke='#DC2626' stroke-width='2' />
  <text x='215' y='50' text-anchor='start' font-size='10' font-weight='bold' fill='#DC2626'>R = 12m</text>
  <rect x='280' y='75' width='100' height='30' fill='#00288E' rx='4' />
  <text x='330' y='94' text-anchor='middle' font-size='10' font-weight='bold' fill='#FFFFFF'>Pista = π(R²-r²)</text>
</svg>",
                Options = new List<QuestionOption>
                {
                    new QuestionOption { Key = "A", Text = "87,92 m²" },
                    new QuestionOption { Key = "B", Text = "125,60 m²" },
                    new QuestionOption { Key = "C", Text = "138,16 m²" },
                    new QuestionOption { Key = "D", Text = "150,72 m²" }
                },
                CorrectOptionKey = "C",
                ExplanationStep1 = "1. Diferença dos quadrados dos raios: R² - r² = 12² - 10² = 144 - 100 = 44 m².",
                ExplanationStep2 = "2. Multiplicação pela constante π: Área = 3,14 × 44 = 138,16 m² de área de pista.",
                ConceptualTrap = "Pegadinha comum: Calcular a área de um círculo com raio igual à largura da pista (r = 2 m -> π × 4 = 12,56 m²), o que desconsidera completamente a distância da pista ao centro."
            });

            // QUESTÃO 10: FIGURA COMPOSTA (RETÂNGULO + TRIÂNGULO)
            questions.Add(new Question
            {
                Number = 10,
                Id = "Q10",
                Topic = "FIGURAS COMPOSTAS",
                SubTopic = "Decomposição Geométrica de Polígonos Planos",
                TechnicalBadge = "ARQUITETURA CIVIL",
                TechnicalTitle = "Área de Fachada Composta",
                TechnicalDescription = "Particionamento de polígono irregular em formas canônicas ortogonais e triangulares.",
                ParameterSummary = "Base comum: 8,0 m | Altura parede: 4,0 m | Altura frontão: 3,0 m | Área = A_ret + A_tri",
                Statement = "A fachada frontal de um galpão industrial foi projetada na forma de uma figura composta: uma parede retangular de 8,0 metros de largura por 4,0 metros de altura, encimada por um telhado com frontão triangular de mesma base (8,0 m) e altura de 3,0 metros. Qual é a área total dessa fachada para efeito de orçamento de pintura?",
                TutorHint = "Divida o problema em duas partes: 1) Área do retângulo (base × altura); 2) Área do triângulo [(base × altura) / 2]. Depois, some os dois resultados.",
                DiagramSvg = @"<svg viewBox='0 0 400 180' class='w-full h-full' xmlns='http://www.w3.org/2000/svg'>
  <rect width='400' height='180' fill='#FAF8FF' rx='8' />
  <!-- Parede Retangular -->
  <rect x='120' y='90' width='160' height='70' fill='#EEF2FF' stroke='#00288E' stroke-width='2' />
  <!-- Telhado Triangular -->
  <polygon points='120,90 280,90 200,30' fill='#C7D2FE' stroke='#00288E' stroke-width='2' />
  <!-- Linha divisória tracejada -->
  <line x1='120' y1='90' x2='280' y2='90' stroke='#4E45D5' stroke-width='1.5' stroke-dasharray='4 3' />
  <!-- Cotas -->
  <text x='200' y='173' text-anchor='middle' font-size='10' font-weight='bold' fill='#00288E'>Largura = 8,0 m</text>
  <text x='95' y='125' text-anchor='middle' font-size='10' font-weight='bold' fill='#00288E'>4,0 m</text>
  <line x1='200' y1='30' x2='200' y2='90' stroke='#DC2626' stroke-width='1.5' stroke-dasharray='3 3' />
  <text x='215' y='65' text-anchor='start' font-size='10' font-weight='bold' fill='#DC2626'>h = 3,0 m</text>
  <text x='200' y='128' text-anchor='middle' font-size='10' fill='#4E45D5'>A_ret = 32 m²</text>
  <text x='200' y='80' text-anchor='middle' font-size='10' fill='#4E45D5'>A_tri = 12 m²</text>
</svg>",
                Options = new List<QuestionOption>
                {
                    new QuestionOption { Key = "A", Text = "38,0 m²" },
                    new QuestionOption { Key = "B", Text = "44,0 m²" },
                    new QuestionOption { Key = "C", Text = "48,0 m²" },
                    new QuestionOption { Key = "D", Text = "56,0 m²" }
                },
                CorrectOptionKey = "B",
                ExplanationStep1 = "1. Área do retângulo inferior: A_ret = base × altura = 8,0 m × 4,0 m = 32,0 m².",
                ExplanationStep2 = "2. Área do triângulo superior: A_tri = (base × altura) / 2 = (8,0 m × 3,0 m) / 2 = 24,0 / 2 = 12,0 m². Somando: 32,0 + 12,0 = 44,0 m².",
                ConceptualTrap = "Pegadinha comum: Calcular a área do triângulo sem dividir por 2 (8 × 3 = 24), obtendo 32 + 24 = 56 m²."
            });

            return questions;
        }
    }
}
