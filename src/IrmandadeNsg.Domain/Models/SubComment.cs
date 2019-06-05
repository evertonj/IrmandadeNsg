using System;

namespace IrmandadeNsg.Domain.Models
{
    public class SubComment : Comment
    {
        public Guid MainCommentId { get; set; }
    }
}
