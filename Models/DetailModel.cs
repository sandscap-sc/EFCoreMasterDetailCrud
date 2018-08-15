using System.Collections.Generic;

namespace FrameworkLab.Models
{
    public class DetailModel : Model
    {
        public string Title { get; set; }
        public ICollection<DetailOfDetailModel> Details { get; set; }
    }
}