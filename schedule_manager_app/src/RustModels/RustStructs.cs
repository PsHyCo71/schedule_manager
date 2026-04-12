using System.Text.Json.Serialization;
namespace ScheduleMAnager.RustModels;

public struct WorkHours
{
    [JsonPropertyName("start")]
    public string start { get; set; }   // HH:MM

    [JsonPropertyName("end")]
    public string end { get; set; }     // HH:MM
}

public struct WorkTask
{
    [JsonPropertyName("task_name")]
    public string taskName { get; set; }

    [JsonPropertyName("arg")]
    public string arg { get; set; }

    [JsonPropertyName("task_time")]
    public string taskTime { get; set; }     // HH:MM

}

public struct Entry
{
    [JsonPropertyName("entry_name")]
    public string entryName { get; set; }

    [JsonPropertyName("arg")]
    public string arg { get; set; }

    [JsonPropertyName("entry_date_time")]
    public string entryDateTime { get; set; }   // YYYY-MM-DDTHH:MM+HH:00    
}