using System.ComponentModel.DataAnnotations.Schema;
using FrameworkLab.Infrastructure;

namespace FrameworkLab.Entities
{
    public abstract class Entity : IHaveTrackingState
    {
        public long Id { get; set; }
        [NotMapped] public TrackingState TrackingState { get; set; }
    }
}