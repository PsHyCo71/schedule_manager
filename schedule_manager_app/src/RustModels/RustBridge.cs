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
    private static partial IntPtr NewWorkHours(string Start, string End);

    [LibraryImport("schedule_manager_core.dll", EntryPoint = "new_task", StringMarshalling = StringMarshalling.Utf8)]
    private static partial IntPtr NewTask(string TaskName, string Arg, string TaskTime);
    [LibraryImport("schedule_manager_core.dll", EntryPoint = "new_event", StringMarshalling = StringMarshalling.Utf8)]
    private static partial IntPtr NewEvent(string EventName, string Arg, string EventDateTime);
    [LibraryImport("schedule_manager_core.dll", EntryPoint = "free_string")]
    private static partial void FreeString(IntPtr Ptr);

    public static WorkHours CreateWorkHours(string Start, string End)
    {
        IntPtr Ptr = NewWorkHours(Start, End);
        string json = Marshal.PtrToStringUTF8(Ptr)!;
        FreeString(Ptr);
        WorkHours WorkHours = JsonSerializer.Deserialize<WorkHours>(json);
        return WorkHours;
    }

    public static WorkTask CreateTask(string TaskName, string Arg, string TaskTime)
    {
        IntPtr Ptr = NewTask(TaskName, Arg, TaskTime);
        string json = Marshal.PtrToStringUTF8(Ptr)!;
        FreeString(Ptr);
        WorkTask WorkTask = JsonSerializer.Deserialize<WorkTask>(json);
        return WorkTask;
    }

    public static Event CreateEvent(string EventName, string Arg, string EventDateTime)
    {
        IntPtr Ptr = NewEvent(EventName, Arg, EventDateTime);
        string json = Marshal.PtrToStringUTF8(Ptr)!;
        FreeString(Ptr);
        Event Event = JsonSerializer.Deserialize<Event>(json);
        return Event;
    }
}
