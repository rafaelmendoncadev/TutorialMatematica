using System.Threading.Tasks;
using TutorialMatematica.Models;

namespace TutorialMatematica.Services
{
    public interface IGeminiTutorService
    {
        Task<TutorChatResponse> AskTutorAsync(TutorChatRequest request);
    }
}
