using System.Text.Json.Serialization;

public struct Event
{
    [JsonPropertyName("event_name")]
    public string eventName { get; set; }

    [JsonPropertyName("arg")]
    public string arg { get; set; }

    [JsonPropertyName("event_date_time")]
    public string eventDateTime { get; set; }     // YYYY-MM-DDTHH:MM+HH:00    
}