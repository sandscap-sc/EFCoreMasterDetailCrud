namespace FrameworkLab.Infrastructure
{
    public interface IHaveTrackingState
    {
        TrackingState TrackingState { get; set; }
            
        //ICollection<string> ModifiedProperties { get; set; }
    }
}