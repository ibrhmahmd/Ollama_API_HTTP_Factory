using DataBaseLayer.Entities;
using DataBaseLayer.Repositories;
using Ollama_Console_HttpClient.chatDTos;

namespace My_Ollama_API.Services
{
    public class SessionService
    {
        private readonly ISessionRepository _repository;

        public SessionService(ISessionRepository repository)
        {
            _repository = repository;
        }

        // Create a new chat session
        public async Task<Session> CreateSessionAsync(Session session)
        {
            var Session = new Session
            {
                Id = Guid.NewGuid().ToString(),
                SystemMessage = session.SystemMessage,
                AIModelId = session.AIModelId,
                Status = session.Status,
                IsDeleted = session.IsDeleted,

            };
            await _repository.CreateSessionAsync(session);

            return session ;
        }

        // Add a message to a session
        public async Task AddPromptAsync(string sessionId, ChatRequest chatRequest)
        {
            var prompt = new Prompt
            {
                Id = Guid.NewGuid().ToString(),
                SessionId = sessionId,
                Content = chatRequest.Message.


            };
            await _repository.AddMessageAsync(sessionId, message);
        }

        // Retrieve session details
        public async Task<ChatSession> GetSessionAsync(int sessionId)
        {
            return await _repository.GetSessionAsync(sessionId);
        }
    }
}