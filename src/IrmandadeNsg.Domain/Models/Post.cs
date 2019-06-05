using IrmandadeNsg.Domain.Core.Models;
using System;
using System.Collections.Generic;

namespace IrmandadeNsg.Domain.Models
{
    public class Post : Entity
    {
        //Empty constructor for EF
        protected Post() { }

        public Post(Guid id, string title, string body, string image, string description, string tags, string category, DateTime created, List<MainComment> mainComments)
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
        }

        public string Title { get; set; } = string.Empty;
        public string Body { get; set; } = string.Empty;
        public string Image { get; set; } = string.Empty;
        public string Description { get; set; } = string.Empty;
        public string Tags { get; set; } = string.Empty;
        public string Category { get; set; } = string.Empty;
        public DateTime Created { get; set; } = DateTime.Now;
        public virtual Author Author { get; set; }
        public virtual List<MainComment> MainComments { get; set; }
    }
}
