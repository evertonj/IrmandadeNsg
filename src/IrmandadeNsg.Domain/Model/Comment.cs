using System;

namespace IrmandadeNsg.Domain.Model
{
    public class Comment
    {
        public int Id { get; set; } = 0;
        public string Message { get; set; } = string.Empty;
        public DateTime Created { get; set; } = DateTime.Now;
    }
}
