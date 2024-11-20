using System.Diagnostics;

namespace Laborotorna14.Exporter
{
    public class Tags
    {
        static ActivitySource activitySource = new ActivitySource(  "Laborotorna14");
        public void TagsProcess()
        {
            using (var activity = activitySource.StartActivity("Activity"))
            {
                if (activity != null)
                {
                    activity.SetTag("http.method", "GET");
                    activity.SetTag("user.id", "12345");
                    activity.SetTag("operation.status", "success");
                }
            }
        }
    }
}
