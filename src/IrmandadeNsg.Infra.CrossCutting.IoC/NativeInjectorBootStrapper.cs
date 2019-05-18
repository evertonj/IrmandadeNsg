using IrmandadeNsg.Application.Interfaces;
using IrmandadeNsg.Application.Services;
using IrmandadeNsg.Domain.CommandHandlers;
using IrmandadeNsg.Domain.Commands;
using IrmandadeNsg.Domain.Core.Bus;
using IrmandadeNsg.Domain.Core.DomainNotifications;
using IrmandadeNsg.Domain.Core.Events;
using IrmandadeNsg.Domain.EventHandlers;
using IrmandadeNsg.Domain.Events;
using IrmandadeNsg.Domain.Interfaces;
using IrmandadeNsg.Infra.CrossCutting.Bus;
using IrmandadeNsg.Infra.CrossCutting.Identity.Authorization;
using IrmandadeNsg.Infra.CrossCutting.Identity.Data;
using IrmandadeNsg.Infra.CrossCutting.Identity.Models;
using IrmandadeNsg.Infra.CrossCutting.Identity.Services;
using IrmandadeNsg.Infra.Data.Context;
using IrmandadeNsg.Infra.Data.EventSourcing;
using IrmandadeNsg.Infra.Data.Repositories;
using IrmandadeNsg.Infra.Data.Repository.EventSourcing;
using IrmandadeNsg.Infra.Data.UoW;
using MediatR;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Http;
using Microsoft.Extensions.DependencyInjection;

namespace IrmandadeNsg.Infra.CrossCutting.IoC
{
    public static class NativeInjectorBootStrapper
    {
        public static void RegisterServices(IServiceCollection services)
        {
            // ASP.NET HttpContext dependency
            services.AddSingleton<IHttpContextAccessor, HttpContextAccessor>();

            // Domain Bus (Mediator)
            services.AddScoped<IMediatorHandler, InMemoryBus>();

            // ASP.NET Authorization Polices
            services.AddSingleton<IAuthorizationHandler, ClaimsRequirementHandler>();

            // Application
            services.AddScoped<IPostAppService, PostAppService>();

            // Domain - Events
            services.AddScoped<INotificationHandler<DomainNotification>, DomainNotificationHandler>();
            services.AddScoped<INotificationHandler<PostRegisteredEvent>, PostEventHandler>();
            services.AddScoped<INotificationHandler<PostUpdatedEvent>, PostEventHandler>();
            services.AddScoped<INotificationHandler<PostRemovedEvent>, PostEventHandler>();

            // Domain - Commands
            services.AddScoped<IRequestHandler<RegisterNewPostCommand, bool>, PostCommandHandler>();
            services.AddScoped<IRequestHandler<UpdatePostCommand, bool>, PostCommandHandler>();
            services.AddScoped<IRequestHandler<RemovePostCommand, bool>, PostCommandHandler>();

            // Infra - Data
            services.AddScoped<IPostRepository, PostRepository>();
            services.AddScoped<IUnitOfWork, UnitOfWork>();
            services.AddDbContext<IrmandadeContext>();

            // Infra - Data EventSourcing
            services.AddScoped<IEventStoreRepository, EventStoreSqlRepository>();
            services.AddScoped<IEventStore, SqlEventStore>();
            services.AddDbContext<EventStoreSqlContext>();

            // Infra - Identity Services
            services.AddTransient<IEmailSender, AuthEmailMessageSender>();
            services.AddTransient<ISmsSender, AuthSmsMessageSender>();
            services.AddDbContext<ApplicationDbContext>();

            // Infra - Identity
            services.AddScoped<IUser, AspNetUser>();
        }
    }
}
