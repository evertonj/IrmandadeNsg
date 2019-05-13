using IrmandadeNsg.Domain.Core.Commands;
using IrmandadeNsg.Domain.Models;
using System;
using System.Collections.Generic;

namespace IrmandadeNsg.Domain.Commands
{
    public abstract class PostCommand : Command
    {
        public Guid Id { get; set; }
        public string Title { get; protected set; } = string.Empty;
        public string Body { get; protected set; } = string.Empty;
        public string Image { get; protected set; } = string.Empty;
        public string Description { get; protected set; } = string.Empty;
        public string Tags { get; protected set; } = string.Empty;
        public string Category { get; protected set; } = string.Empty;
        public DateTime Created { get; protected set; } = DateTime.Now;
        public IList<MainComment> MainComments { get; protected set; }
    }
}
