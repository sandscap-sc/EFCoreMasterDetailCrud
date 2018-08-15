using System.Collections.Generic;

namespace FrameworkLab.Entities
{
    public class Detail : Entity
    {
        public string Title { get; set; }

        public ICollection<DetailOfDetail> Details { get; set; }
        public Master Master { get; set; }
        public long MasterId { get; set; }
    }
}