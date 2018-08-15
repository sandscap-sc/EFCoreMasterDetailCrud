using System.Collections.Generic;

namespace FrameworkLab.Models
{
    public class MasterModel : Model
    {
        public string Title { get; set; }
        public ICollection<DetailModel> Details { get; set; }
    }
}