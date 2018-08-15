using FrameworkLab.Entities;
using FrameworkLab.Infrastructure;
using Microsoft.EntityFrameworkCore;

namespace FrameworkLab.DataLayer
{
    public static class DbContextExtensions
    {
        public static void SaveAggregate<TMasterEntity>(this DbContext context, TMasterEntity master)
            where TMasterEntity : Entity
        {
            context.ChangeTracker.TrackGraph(
                master,
                n =>
                {
                    var entity = (IHaveTrackingState) n.Entry.Entity;
                    n.Entry.State = entity.TrackingState.ToEntityState();
                });

            context.SaveChanges();
        }
    }
}