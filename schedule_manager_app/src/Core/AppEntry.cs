namespace ScheduleManager.Core;

public static class AppEntry
{
    public static void Run(string[] args)
    {
        StartApp();
        LoadData();
        ShowMenu();
    }

    private static void StartApp()
    {
        Console.WriteLine($"Hello, World!");
        
    }

    private static void LoadData()
    {
    }

    private static void ShowMenu()
    {
    }
}