using IrmandadeNsg.Domain.Core.Models;
using System;

namespace IrmandadeNsg.Domain.Models
{
    public class Comment : Entity
    {
        public string Message { get; set; } = string.Empty;
        public DateTime Created { get; set; } = DateTime.Now;
    }
}
