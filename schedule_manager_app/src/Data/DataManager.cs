namespace ScheduleManager.Data;

public static class DataManager
{
    private static Schedule schedule = Load();

    public static Schedule Load()
    {
        if (File.Exists("schedule.json"))
        {
            string json = File.ReadAllText("schedule.json");
            Schedule schedule = JsonSerializer.Deserialize<Schedule>(json);
            return schedule;
        }
        else
        {
            Schedule schedule = new Schedule();
            return schedule;
        }
    }

    public static void SaveWorkHours(string start, string end)
    {
        WorkHours hours = RustBridge.CreateWorkHours(start, end);
        schedule.workHours = hours;
        File.WriteAllText("schedule.json", JsonSerializer.Serialize(schedule, new JsonSerializerOptions { WriteIndented = true }));
    }

    public static void SaveTask(string taskName, string arg, string taskTime)
    {
        WorkTask task = RustBridge.CreateTask(taskName, arg, taskTime);
        schedule.tasks.Add(task);
        File.WriteAllText("schedule.json", JsonSerializer.Serialize(schedule, new JsonSerializerOptions { WriteIndented = true }));
    }

    public static void SaveEntry(string entryName, string arg, string entryTime)
    {
        Entry entry = RustBridge.CreateEntry(entryName, arg, entryTime);
        schedule.entries.Add(entry);
        File.WriteAllText("schedule.json", JsonSerializer.Serialize(schedule, new JsonSerializerOptions { WriteIndented = true }));
    }
}