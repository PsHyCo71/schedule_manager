using System.Text.Json.Serialization;

public struct WorkTask
{
    [JsonPropertyName("task_name")]
    public string taskName { get; set; }

    [JsonPropertyName("arg")]
    public string arg { get; set; }

    [JsonPropertyName("task_time")]
    public string taskTime { get; set; }     // HH:MM
    
}