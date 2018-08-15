namespace FrameworkLab.Entities
{
    public class DetailOfDetail : Entity
    {
        public string Title { get; set; }
        public Detail Detail { get; set; }
        public long DetailId { get; set; }
    }
}