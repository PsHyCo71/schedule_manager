using System;
using ScheduleManager.RustModels;
public class Program
{
    public static void Main()
    {
        RustBridge.CreateWorkHours("08:00", "18:00");
    }
}