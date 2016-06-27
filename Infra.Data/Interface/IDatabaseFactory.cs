using Infra.Data.Context;

namespace Infra.Data.Interface
{
    /// <summary>
    /// Defines the methods that are required for a DatabaseFactory instance.
    /// </summary>
    public interface IDatabaseFactory
    {
        /// <summary>
        /// Returns a concrete instance of the OpendeskDb data context
        /// </summary>
        /// <returns>DbContext (OpendeskDb)</returns>
        Contexto Get();
    }
}
