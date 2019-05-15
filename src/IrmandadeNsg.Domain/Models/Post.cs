using System;
using System.Collections.Generic;

namespace IrmandadeNsg.Domain.Models
{
    public class Post
    {
        //Empty constructor for EF
        protected Post() { }

        public Post(Guid id, string title, string body, string image, string description, string tags, string category, DateTime created, IList<MainComment> mainComments)
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

        public Guid Id { get; set; }
        public string Title { get; set; } = string.Empty;
        public string Body { get; set; } = string.Empty;
        public string Image { get; set; } = string.Empty;
        public string Description { get; set; } = string.Empty;
        public string Tags { get; set; } = string.Empty;
        public string Category { get; set; } = string.Empty;
        public DateTime Created { get; set; } = DateTime.Now;
        public Author Author { get; set; }
        public IList<MainComment> MainComments { get; set; }
    }
}
