using System.Collections.Generic;

namespace IrmandadeNsg.Domain.Model
{
    public class MainComment : Comment
    {
        public IList<SubComment> SubComments { get; set; }
    }
}