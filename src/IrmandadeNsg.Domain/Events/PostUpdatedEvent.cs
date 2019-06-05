using IrmandadeNsg.Domain.Core.Events;
using IrmandadeNsg.Domain.Models;
using System;
using System.Collections.Generic;

namespace IrmandadeNsg.Domain.Events
{
    public class PostUpdatedEvent : Event
    {
        public PostUpdatedEvent(Guid id, string title, string body, string image, string description, string tags, string category, DateTime created, IList<MainComment> mainComments)
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
        public string Title { get; set; } 
        public string Body { get; set; } 
        public string Image { get; set; } 
        public string Description { get; set; } 
        public string Tags { get; set; } 
        public string Category { get; set; } 
        public DateTime Created { get; set; } 
        public IList<MainComment> MainComments { get; set; }
    }
}
