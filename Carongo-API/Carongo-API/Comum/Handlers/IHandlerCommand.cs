using Comum.Commands;

namespace Comum.Handlers
{
    public interface IHandlerCommand<T> where T : ICommand
    {
        ICommandResult Handle(T command);
    }
}