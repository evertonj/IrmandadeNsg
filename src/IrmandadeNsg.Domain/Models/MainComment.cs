using System.Collections.Generic;

namespace IrmandadeNsg.Domain.Models
{
    public class MainComment : Comment
    {
        public IList<SubComment> SubComments { get; set; }
    }
}