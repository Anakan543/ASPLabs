using OpenTelemetry;
using OpenTelemetry.Metrics;
using Serilog;
using System.Diagnostics;

namespace Laborotorna14.Exporter
{
    class SerilogExporterTracing : BaseExporter<Activity>
    {
        public override ExportResult Export(in Batch<Activity> batch)
        {

            foreach (var activity in batch)
            {
                foreach (var tag in activity.Tags)
                {
                    Log.Information($"Tag: {tag.Key}, Value: {tag.Value}");
                }
                Log.Information($"TraceId: {activity.TraceId}, Name: {activity.DisplayName}, Duration: {activity.Duration}");
            }
            return ExportResult.Success;
        }
    }
    class SerilogExporterMetrics : BaseExporter<Metric>
    {
        public override ExportResult Export(in Batch<Metric> batch)
        {
            foreach (var metric in batch)
            {
                foreach (var metricPoint in metric.GetMetricPoints())
                {
                    Log.Information(
                        $"Metric: {metric.Name}, Value: {metricPoint}, Timestamp: {metricPoint.EndTime}");
                }
            }
            return ExportResult.Success;
        }
    }
}
