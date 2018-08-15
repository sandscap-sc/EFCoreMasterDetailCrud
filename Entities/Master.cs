using System.Collections.Generic;

namespace FrameworkLab.Entities
{
    public class Master : Entity
    {
        public string Title { get; set; }
        public ICollection<Detail> Details { get; set; }
    }
}