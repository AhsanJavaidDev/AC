using AcmeCorp.Application.Interfaces;
using AcmeCorp.Application.ViewModels;
using AcmeCorp.Domain.Core.Bus;
using AcmeCorp.Domain.Core.Notifications;
using AcmeCorp.Infra.CrossCutting.Identity.Authorization;
using MediatR;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using Polly;

namespace AcmeCorp.Services.Api.Controllers.v1
{
    [Authorize]
    [ApiVersion("1.0")]
    public class OrderController : ApiController
    {
        private readonly IOrderAppService _orderAppService;

        public OrderController(
            IOrderAppService orderAppService,
            INotificationHandler<DomainNotification> notifications,
            IMediatorHandler mediator) : base(notifications, mediator)
        {
            _orderAppService = orderAppService;
        }

        [HttpGet]
        [AllowAnonymous]
        [Route("order-management")]
        public IActionResult Get()
        {
            return Response(_orderAppService.GetAll());
        }

        [HttpGet]
        [AllowAnonymous]
        [Route("order-management/{id:guid}")]
        public IActionResult Get(Guid id)
        {
            var orderViewModel = _orderAppService.GetById(id);

            return Response(orderViewModel);
        }

        [HttpPost]
        [Authorize(Policy = "CanWriteOrderData", Roles = Roles.Admin)]
        [Route("order-management")]
        public IActionResult Post([FromBody] OrderViewModel orderViewModel)
        {
            if (!ModelState.IsValid)
            {
                NotifyModelStateErrors();
                return Response(orderViewModel);
            }

            _orderAppService.CreateOrder(orderViewModel);

            return Response(orderViewModel);
        }

        [HttpPut]
        [Authorize(Policy = "CanWriteOrderData", Roles = Roles.Admin)]
        [Route("order-management")]
        public IActionResult Put([FromBody] OrderViewModel orderViewModel)
        {
            if (!ModelState.IsValid)
            {
                NotifyModelStateErrors();
                return Response(orderViewModel);
            }

            _orderAppService.Update(orderViewModel);

            return Response(orderViewModel);
        }

        [HttpGet]
        [AllowAnonymous]
        [Route("order-management/pagination")]
        public IActionResult Pagination(int skip, int take)
        {
            return Response(_orderAppService.GetAll(skip, take));
        }
    }
}
