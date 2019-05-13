using IrmandadeNsg.Domain.Commands;
using IrmandadeNsg.Domain.Core.Bus;
using IrmandadeNsg.Domain.Core.DomainNotifications;
using IrmandadeNsg.Domain.Events;
using IrmandadeNsg.Domain.Interfaces;
using IrmandadeNsg.Domain.Models;
using MediatR;
using System;
using System.Threading;
using System.Threading.Tasks;

namespace IrmandadeNsg.Domain.CommandHandlers
{
    public class PostCommandHandler : CommandHandler, IRequestHandler<RegisterNewPostCommand, bool>, IRequestHandler<UpdatePostCommand, bool>, IRequestHandler<RemovePostCommand, bool>
    {
        private readonly IPostRepository _postRepository;
        private readonly IMediatorHandler Bus;

        public PostCommandHandler(IPostRepository postRepository,
                                      IUnitOfWork uow,
                                      IMediatorHandler bus,
                                      INotificationHandler<DomainNotification> notifications) : base(uow, bus, notifications)
        {
            _postRepository = postRepository;
            Bus = bus;
        }

        public Task<bool> Handle(RegisterNewPostCommand message, CancellationToken cancellationToken)
        {
            if (!message.IsValid())
            {
                NotifyValidationErrors(message);
                return Task.FromResult(false);
            }

            var post = new Post(Guid.NewGuid(), message.Title, message.Body, message.Image, message.Description, message.Tags, message.Category, message.Created, message.MainComments);

            _postRepository.Add(post);

            if (Commit())
            {
                Bus.RaiseEvent(new PostRegisteredEvent(post.Id, post.Title, post.Body, post.Image, post.Description, post.Tags, post.Category, post.Created, post.MainComments));
            }

            return Task.FromResult(true);
        }

        public Task<bool> Handle(UpdatePostCommand message, CancellationToken cancellationToken)
        {
            if (!message.IsValid())
            {
                NotifyValidationErrors(message);
                return Task.FromResult(false);
            }

            var post = new Post(message.Id, message.Title, message.Body, message.Image, message.Description, message.Tags, message.Category, message.Created, message.MainComments);

            _postRepository.Update(post);

            if (Commit())
            {
                Bus.RaiseEvent(new PostUpdatedEvent(post.Id, post.Title, post.Body, post.Image, post.Description, post.Tags, post.Category, post.Created, post.MainComments));
            }

            return Task.FromResult(true);
        }

        public Task<bool> Handle(RemovePostCommand message, CancellationToken cancellationToken)
        {
            if (!message.IsValid())
            {
                NotifyValidationErrors(message);
                return Task.FromResult(false);
            }

            _postRepository.Remove(message.Id);

            if (Commit())
            {
                Bus.RaiseEvent(new PostRemovedEvent(message.Id));
            }

            return Task.FromResult(true);
        }

        public void Dispose()
        {
            _postRepository.Dispose();
        }
    }
}
