using System.Threading.Tasks;
using AcmeCorp.Domain.Core.Commands;
using AcmeCorp.Domain.Core.Events;

namespace AcmeCorp.Domain.Core.Bus
{
    public interface IMediatorHandler
    {
        Task SendCommand<T>(T command) where T : Command;
        Task RaiseEvent<T>(T @event) where T : Event;
    }
}
