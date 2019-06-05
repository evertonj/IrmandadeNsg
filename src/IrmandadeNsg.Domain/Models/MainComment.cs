using System.Collections.Generic;

namespace IrmandadeNsg.Domain.Models
{
    public class MainComment : Comment
    {
        public ICollection<SubComment> SubComments { get; set; }
    }
}