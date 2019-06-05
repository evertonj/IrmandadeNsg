using IrmandadeNsg.Domain.Models;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;

namespace IrmandadeNsg.Application.ViewModels
{
    public class PostViewModel
    {
        [Key]
        public Guid Id { get; set; }
        public string Title { get; set; } = string.Empty;
        public string Body { get; set; } = string.Empty;
        public string Image { get; set; } = string.Empty;
        public string Description { get; set; } = string.Empty;
        public string Tags { get; set; } = string.Empty;
        public string Category { get; set; } = string.Empty;
        public DateTime Created { get; set; } = DateTime.Now;
        public Author Author { get; set; }
        public List<MainComment> MainComments { get; set; }
    }
}
