namespace ScheduleManager.RustModels;

public struct WorkHours
{
    [JsonPropertyName("start")]
    public string start { get; set; }   // HH:MM:SS

    [JsonPropertyName("end")]
    public string end { get; set; }     // HH:MM:SS
}

public struct WorkTask
{
    [JsonPropertyName("task_name")]
    public string taskName { get; set; }

    [JsonPropertyName("arg")]
    public string arg { get; set; }

    [JsonPropertyName("task_time")]
    public string taskTime { get; set; }     // HH:MM:SS

}

public struct Entry
{
    [JsonPropertyName("entry_name")]
    public string entryName { get; set; }

    [JsonPropertyName("arg")]
    public string arg { get; set; }

    [JsonPropertyName("entry_date_time")]
    public string entryDateTime { get; set; }   // YYYY-MM-DDTHH:MM:SS    
}

public struct Schedule
{
    public WorkHours? workHours { get; set; }
    public List<WorkTask> tasks { get; set; } = new List<WorkTask>();
    public List<Entry> entries { get; set; } = new List<Entry>();

    public Schedule()
    {
    }
}