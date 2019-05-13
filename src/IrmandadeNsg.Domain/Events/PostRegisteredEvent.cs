using IrmandadeNsg.Domain.Core.Events;
using IrmandadeNsg.Domain.Models;
using System;
using System.Collections.Generic;

namespace IrmandadeNsg.Domain.Events
{
    public class PostRegisteredEvent : Event
    {
        public PostRegisteredEvent(Guid id, string title, string body, string image, string description, string tags, string category, DateTime created, IList<MainComment> mainComments)
        {
            Id = id;
            Title = title;
            Body = body;
            Image = image;
            Description = description;
            Tags = tags;
            Category = category;
            Created = created;
            MainComments = mainComments;
            AggregateId = id;
        }

        public Guid Id { get; set; }
        public string Title { get; set; } = string.Empty;
        public string Body { get; set; } = string.Empty;
        public string Image { get; set; } = string.Empty;
        public string Description { get; set; } = string.Empty;
        public string Tags { get; set; } = string.Empty;
        public string Category { get; set; } = string.Empty;
        public DateTime Created { get; set; } = DateTime.Now;
        public IList<MainComment> MainComments { get; set; }
    }
}
