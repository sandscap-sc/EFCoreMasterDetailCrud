using Microsoft.EntityFrameworkCore;

namespace FrameworkLab.Infrastructure
{
    public static class TrackingStateExtensions
    {
        public static EntityState ToEntityState(this TrackingState trackingState)
        {
            switch (trackingState)
            {
                case TrackingState.Added:
                    return EntityState.Added;
    
                case TrackingState.Modified:
                    return EntityState.Modified;
    
                case TrackingState.Deleted:
                    return EntityState.Deleted;
    
                case TrackingState.Unchanged:
                    return EntityState.Unchanged;
    
                default:
                    return EntityState.Unchanged;
            }
        }
    
        public static TrackingState ToTrackingState(this EntityState state)
        {
            switch (state)
            {
                case EntityState.Added:
                    return TrackingState.Added;
    
                case EntityState.Modified:
                    return TrackingState.Modified;
    
                case EntityState.Deleted:
                    return TrackingState.Deleted;
    
                case EntityState.Unchanged:
                    return TrackingState.Unchanged;
    
                default:
                    return TrackingState.Unchanged;
            }
        }
    }
}