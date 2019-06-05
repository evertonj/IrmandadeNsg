using System;
using System.Collections.Generic;
using AutoMapper;
using AutoMapper.QueryableExtensions;
using IrmandadeNsg.Application.EventSourcedNormalizers;
using IrmandadeNsg.Application.Interfaces;
using IrmandadeNsg.Application.ViewModels;
using IrmandadeNsg.Domain.Commands;
using IrmandadeNsg.Domain.Core.Bus;
using IrmandadeNsg.Domain.Interfaces;
using IrmandadeNsg.Infra.Data.Repository.EventSourcing;

namespace IrmandadeNsg.Application.Services
{
    public class PostAppService : IPostAppService
    {
        private readonly IMapper _mapper;
        private readonly IPostRepository _postRepository;
        private readonly IEventStoreRepository _eventStoreRepository;
        private readonly IMediatorHandler Bus;

        public PostAppService(IMapper mapper,
                                  IPostRepository postRepository,
                                  IMediatorHandler bus,
                                  IEventStoreRepository eventStoreRepository)
        {
            _mapper = mapper;
            _postRepository = postRepository;
            Bus = bus;
            _eventStoreRepository = eventStoreRepository;
        }

        public IEnumerable<PostViewModel> GetAll()
        {
            return _postRepository.GetAll().ProjectTo<PostViewModel>(_mapper.ConfigurationProvider);
        }

        public PostViewModel GetById(Guid id)
        {
            return _mapper.Map<PostViewModel>(_postRepository.GetById(id));
        }

        public void Register(PostViewModel postViewModel)
        {
            var registerCommand = _mapper.Map<RegisterNewPostCommand>(postViewModel);
            Bus.SendCommand(registerCommand);
        }

        public void Update(PostViewModel postViewModel)
        {
            var updateCommand = _mapper.Map<UpdatePostCommand>(postViewModel);
            Bus.SendCommand(updateCommand);
        }

        public void Remove(Guid id)
        {
            var removeCommand = new RemovePostCommand(id);
            Bus.SendCommand(removeCommand);
        }

        public IList<PostHistoryData> GetAllHistory(Guid id)
        {
            return PostHistory.ToJavaScriptPostHistory(_eventStoreRepository.All(id));
        }

        public void Dispose()
        {
            Dispose(true);
            GC.SuppressFinalize(this);
        }

        protected virtual void Dispose(bool disposing)
        {
            if (disposing && (_postRepository != null))
            {
                _postRepository.Dispose();
            }
        }
    }
}
