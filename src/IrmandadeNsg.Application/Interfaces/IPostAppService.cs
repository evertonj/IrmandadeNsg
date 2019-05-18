using System;
using System.Collections.Generic;
using IrmandadeNsg.Application.EventSourcedNormalizers;
using IrmandadeNsg.Application.ViewModels;

namespace IrmandadeNsg.Application.Interfaces
{
    public interface IPostAppService : IDisposable
    {
        void Register(PostViewModel postViewModel);
        IEnumerable<PostViewModel> GetAll();
        PostViewModel GetById(Guid id);
        void Update(PostViewModel postViewModel);
        void Remove(Guid id);
        IList<PostHistoryData> GetAllHistory(Guid id);
    }
}
