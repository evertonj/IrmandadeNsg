using IrmandadeNsg.Domain.Core.Commands;
using IrmandadeNsg.Domain.Core.Events;
using System.Threading.Tasks;

namespace IrmandadeNsg.Domain.Core.Bus
{
    public interface IMediatorHandler
    {
        Task SendCommand<T>(T command) where T : Command;
        Task RaiseEvent<T>(T @event) where T : Event;
    }
}
