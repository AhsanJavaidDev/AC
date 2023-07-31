using AcmeCorp.Application.Interfaces;
using AcmeCorp.Application.Services;
using AcmeCorp.Domain.CommandHandlers;
using AcmeCorp.Domain.CommandHandlers.Order;
using AcmeCorp.Domain.Commands;
using AcmeCorp.Domain.Commands.Order;
using AcmeCorp.Domain.Core.Bus;
using AcmeCorp.Domain.Core.Notifications;
using AcmeCorp.Domain.EventHandlers;
using AcmeCorp.Domain.Events;
using AcmeCorp.Domain.Events.Order;
using AcmeCorp.Domain.Interfaces;
using AcmeCorp.Domain.Services.Http;
using AcmeCorp.Domain.Services.Mail;
using AcmeCorp.Infra.CrossCutting.Bus;
using AcmeCorp.Infra.CrossCutting.Identity.Authorization;
using AcmeCorp.Infra.CrossCutting.Identity.Models;
using AcmeCorp.Infra.CrossCutting.Identity.Services;
using AcmeCorp.Infra.Data.Repository;
using AcmeCorp.Infra.Data.UoW;
using MediatR;
using Microsoft.AspNetCore.Authorization;
using Microsoft.Extensions.DependencyInjection;

namespace AcmeCorp.Infra.CrossCutting.IoC
{
    public class NativeInjectorBootStrapper
    {
        public static void RegisterServices(IServiceCollection services)
        {
            // ASP.NET HttpContext dependency
            services.AddHttpContextAccessor();
            // services.AddSingleton<IHttpContextAccessor, HttpContextAccessor>();

            // Domain Bus (Mediator)
            services.AddScoped<IMediatorHandler, InMemoryBus>();

            // ASP.NET Authorization Polices
            services.AddSingleton<IAuthorizationHandler, ClaimsRequirementHandler>();

            // Application
            services.AddScoped<ICustomerAppService, CustomerAppService>();
            services.AddScoped<IOrderAppService, OrderAppService>();

            // Domain - Events
            services.AddScoped<INotificationHandler<DomainNotification>, DomainNotificationHandler>();
            services.AddScoped<INotificationHandler<CustomerRegisteredEvent>, CustomerEventHandler>();
            services.AddScoped<INotificationHandler<CustomerUpdatedEvent>, CustomerEventHandler>();
            services.AddScoped<INotificationHandler<CustomerRemovedEvent>, CustomerEventHandler>();

            services.AddScoped<INotificationHandler<OrderCreateEvent>, OrderEventHandler>();
            services.AddScoped<INotificationHandler<OrderUpdatedEvent>, OrderEventHandler>();

            // Domain - Commands
            services.AddScoped<IRequestHandler<RegisterNewCustomerCommand, bool>, CustomerCommandHandler>();
            services.AddScoped<IRequestHandler<UpdateCustomerCommand, bool>, CustomerCommandHandler>();
            services.AddScoped<IRequestHandler<RemoveCustomerCommand, bool>, CustomerCommandHandler>();

            services.AddScoped<IRequestHandler<RegisterNewOrderCommand, bool>, OrderCommandHandler>();
            services.AddScoped<IRequestHandler<UpdateOrderCommand, bool>, OrderCommandHandler>();

            // Domain - 3rd parties
            services.AddScoped<IHttpService, HttpService>();
            services.AddScoped<IMailService, MailService>();

            // Infra - Data
            services.AddScoped<ICustomerRepository, CustomerRepository>();
            services.AddScoped<IOrderRepository, OrderRepository>();
            services.AddScoped<IUnitOfWork, UnitOfWork>();

            // Infra - Data EventSourcing
            //services.AddScoped<IEventStoreRepository, EventStoreSqlRepository>();
            //services.AddScoped<IEventStore, SqlEventStore>();

            // Infra - Identity Services
            services.AddTransient<IEmailSender, AuthEmailMessageSender>();
            services.AddTransient<ISmsSender, AuthSMSMessageSender>();

            // Infra - Identity
            services.AddScoped<IUser, AspNetUser>();
            services.AddSingleton<IJwtFactory, JwtFactory>();
        }
    }
}
