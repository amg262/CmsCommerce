using EPiServer.PlugIn;
using EPiServer.Scheduler;

namespace CmsCommerce.Templates.Jobs
{
    [ScheduledPlugIn(
        DisplayName = "Jobs",
        Description = "",
        GUID = "9C38DE9D-721F-4D49-9A66-3AD706E744A0",
        IntervalType = ScheduledIntervalType.Hours,
        IntervalLength = 12,
        DefaultEnabled = true,
        Restartable = true)]
    public class Jobs : ScheduledJobBase
    {
        private bool _stopSignaled;

        public Jobs()
        {
            IsStoppable = true;
        }

        /// <summary>
        /// Called when a scheduled job executes
        /// </summary>
        /// <returns>A status message to be stored in the database log and visible from admin mode</returns>
        public override string Execute()
        {
            //Call OnStatusChanged to periodically notify progress of job for manually started jobs
            OnStatusChanged($"Starting execution of {GetType()}");

            //Add implementation

            //For long running jobs periodically check if stop is signaled and if so stop execution
            if (_stopSignaled)
            {
                return "Stop of job was called";
            }

            return "Change to message that describes outcome of execution";
        }

        /// <summary>
        /// Called when a user clicks on Stop for a manually started job, or when ASP.NET shuts down.
        /// </summary>
        public override void Stop()
        {
            _stopSignaled = true;
        }
    }
}
