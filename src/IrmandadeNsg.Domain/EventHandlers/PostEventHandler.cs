using IrmandadeNsg.Domain.Events;
using MediatR;
using System.Threading;
using System.Threading.Tasks;

namespace IrmandadeNsg.Domain.EventHandlers
{
    public class PostEventHandler : INotificationHandler<PostRegisteredEvent>, INotificationHandler<PostUpdatedEvent>, INotificationHandler<PostRemovedEvent>
    {
        public Task Handle(PostRegisteredEvent notification, CancellationToken cancellationToken)
        {
            // Send some notification e-mail
            return Task.CompletedTask;
        }

        public Task Handle(PostUpdatedEvent notification, CancellationToken cancellationToken)
        {
            // Send some notification e-mail
            return Task.CompletedTask;
        }

        public Task Handle(PostRemovedEvent notification, CancellationToken cancellationToken)
        {
            // Send some notification e-mail
            return Task.CompletedTask;
        }
    }
}
