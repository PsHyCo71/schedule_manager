using System.Runtime.InteropServices;
using System.Text.Json;
using ScheduleMAnager.RustModels;

namespace ScheduleManager.RustModels;

/// <summary>
/// This class defines and invokes the four native functions exported from the Rust cdylib,
/// using StringMarshalling.Utf8 for correct marshalling. It also provides wrapper methods
/// for these native functions.
/// </summary>
public partial class RustBridge
{
    [LibraryImport("schedule_manager_core.dll", EntryPoint = "new_hours", StringMarshalling = StringMarshalling.Utf8)]
    private static partial IntPtr NewWorkHours(string start, string end);

    [LibraryImport("schedule_manager_core.dll", EntryPoint = "new_task", StringMarshalling = StringMarshalling.Utf8)]
    private static partial IntPtr NewTask(string taskName, string arg, string taskTime);
    [LibraryImport("schedule_manager_core.dll", EntryPoint = "new_entry", StringMarshalling = StringMarshalling.Utf8)]
    private static partial IntPtr NewEvent(string entryName, string arg, string entryDateTime);
    [LibraryImport("schedule_manager_core.dll", EntryPoint = "free_string")]
    private static partial void FreeString(IntPtr ptr);

    public static WorkHours CreateWorkHours(string start, string end)
    {
        IntPtr ptr = NewWorkHours(start, end);
        string json = Marshal.PtrToStringUTF8(ptr)!;
        FreeString(ptr);
        WorkHours workHours = JsonSerializer.Deserialize<WorkHours>(json);
        return workHours;
    }

    public static WorkTask CreateTask(string taskName, string arg, string taskTime)
    {
        IntPtr ptr = NewTask(taskName, arg, taskTime);
        string json = Marshal.PtrToStringUTF8(ptr)!;
        FreeString(ptr);
        WorkTask workTask = JsonSerializer.Deserialize<WorkTask>(json);
        return workTask;
    }

    public static Entry CreateEvent(string entryName, string arg, string entryDateTime)
    {
        IntPtr ptr = NewEvent(entryName, arg, entryDateTime);
        string json = Marshal.PtrToStringUTF8(ptr)!;
        FreeString(ptr);
        Entry entry = JsonSerializer.Deserialize<Entry>(json);
        return entry;
    }
}
