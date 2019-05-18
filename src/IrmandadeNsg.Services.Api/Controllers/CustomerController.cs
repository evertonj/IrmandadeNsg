using System;
using IrmandadeNsg.Application.Interfaces;
using IrmandadeNsg.Application.ViewModels;
using IrmandadeNsg.Domain.Core.Bus;
using IrmandadeNsg.Domain.Core.DomainNotifications;
using MediatR;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;

namespace IrmandadeNsg.Services.Api.Controllers
{
    [Authorize]
    public class PostController : ApiController
    {
        private readonly IPostAppService _postAppService;

        public PostController(
            IPostAppService postAppService,
            INotificationHandler<DomainNotification> notifications,
            IMediatorHandler mediator) : base(notifications, mediator)
        {
            _postAppService = postAppService;
        }

        [HttpGet]
        [AllowAnonymous]
        [Route("post-management")]
        public IActionResult Get()
        {
            return Response(_postAppService.GetAll());
        }

        [HttpGet]
        [AllowAnonymous]
        [Route("post-management/{id:guid}")]
        public IActionResult Get(Guid id)
        {
            var postViewModel = _postAppService.GetById(id);

            return Response(postViewModel);
        }     

        [HttpPost]
        [Authorize(Policy = "CanWritePostData")]
        [Route("post-management")]
        public IActionResult Post([FromBody]PostViewModel postViewModel)
        {
            if (!ModelState.IsValid)
            {
                NotifyModelStateErrors();
                return Response(postViewModel);
            }

            _postAppService.Register(postViewModel);

            return Response(postViewModel);
        }
        
        [HttpPut]
        [Authorize(Policy = "CanWritePostData")]
        [Route("post-management")]
        public IActionResult Put([FromBody]PostViewModel postViewModel)
        {
            if (!ModelState.IsValid)
            {
                NotifyModelStateErrors();
                return Response(postViewModel);
            }

            _postAppService.Update(postViewModel);

            return Response(postViewModel);
        }

        [HttpDelete]
        [Authorize(Policy = "CanRemovePostData")]
        [Route("post-management")]
        public IActionResult Delete(Guid id)
        {
            _postAppService.Remove(id);
            
            return Response();
        }

        [HttpGet]
        [AllowAnonymous]
        [Route("post-management/history/{id:guid}")]
        public IActionResult History(Guid id)
        {
            var postHistoryData = _postAppService.GetAllHistory(id);
            return Response(postHistoryData);
        }
    }
}
