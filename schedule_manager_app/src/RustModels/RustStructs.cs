using System.Text.Json.Serialization;
namespace ScheduleMAnager.RustModels;

public struct WorkHours
{
    [JsonPropertyName("start")]
    public string Start { get; set; }   // HH:MM

    [JsonPropertyName("end")]
    public string End { get; set; }     // HH:MM
}

public struct WorkTask
{
    [JsonPropertyName("task_name")]
    public string TaskName { get; set; }

    [JsonPropertyName("arg")]
    public string Arg { get; set; }

    [JsonPropertyName("task_time")]
    public string TaskTime { get; set; }     // HH:MM

}

public struct Event
{
    [JsonPropertyName("event_name")]
    public string EventName { get; set; }

    [JsonPropertyName("arg")]
    public string Arg { get; set; }

    [JsonPropertyName("event_date_time")]
    public string EventDateTime { get; set; }   // YYYY-MM-DDTHH:MM+HH:00    
}