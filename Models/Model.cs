using FrameworkLab.Infrastructure;

namespace FrameworkLab.Models
{
    public abstract class Model : IHaveTrackingState
    {
        public long Id { get; set; }
        public TrackingState TrackingState { get; set; }
    }
}