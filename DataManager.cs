using Godot;
using System;
using System.Linq;

public partial class DataManager : GodotObject
{
    public static string name;
    public static string filename;
    public static Vector2? Position = null;

    private static ulong TimeCreated;

    public static class Settings
    {
        public static byte WindowMode;

        public static void Save()
        {
            var file = FileAccess.Open("user://.settings", FileAccess.ModeFlags.Write);
            file.Store8(WindowMode);
            file.Close();
        }
        public static void Load()
        {
		    var file = FileAccess.Open("user://.settings", FileAccess.ModeFlags.Read);
            WindowMode = file.Get8();
            file.Close();
        }
    }

    public static void Save()
    {
        var file = FileAccess.Open("user://saves//" + filename, FileAccess.ModeFlags.Write);
        file.StoreLine(name);
        file.Store64(TimeCreated);
        if(Position != null)
        {
            file.StorePascalString("Player");
            file.StorePascalString("Pos");
            file.StoreFloat(Position.Value.X);
            file.StoreFloat(Position.Value.Y);
        }
        file.Close();
    }

    public static void Clear()
    {
        name = "";
        filename = "";
        Position = null;
        TimeCreated = 0;
    }

    public static void Load(string filename)
    {
        DataManager.filename = filename;
		var file = FileAccess.Open("user://saves//" + filename, FileAccess.ModeFlags.Read);
        name = file.GetLine();
        TimeCreated = file.Get64();
        string item = file.GetPascalString();
        if(item == "Player")
        {
            item = file.GetPascalString();
            if(item == "Pos")
            {
                float x = file.GetFloat();
                float y = file.GetFloat();
                Position = new Vector2(x, y);
            }
        }
        file.Close();
    }

    public static void LoadFileInfo(string filename, out string name, out string date, out string timePlayed)
    {
        timePlayed = GetTimeLastPlayed(FileAccess.GetModifiedTime("user://saves//" + filename));
        var file = FileAccess.Open("user://saves//" + filename, FileAccess.ModeFlags.Read);
        name = file.GetLine();
        date = GetTimeCreated(file.Get64());
    }

    public static void SetTimeCreated(ulong time)
    {
        TimeCreated = time;
    }

    public static string GetTimeCreated()
    {
        return Time.GetDateStringFromUnixTime((long)TimeCreated) + " " + Time.GetTimeStringFromUnixTime((long)TimeCreated);
    }
    public static string GetTimeCreated(ulong time)
    {
        long adjustedTime = (long)time + (Time.GetTimeZoneFromSystem().Values.ElementAt(0).As<long>() * 60);
        return Time.GetDateStringFromUnixTime((long)adjustedTime) + " " + Time.GetTimeStringFromUnixTime((long)adjustedTime);
    }

    public static string GetTimeLastPlayed(ulong timeModified)
    {
        ulong totalTime = (ulong)Time.GetUnixTimeFromSystem() - timeModified;
        if(totalTime < 60) return totalTime.ToString() + " Secs";
        else if(totalTime < 3600) return (totalTime/60).ToString() + " Mins";
        else if(totalTime < 86400) return (totalTime/3600).ToString() + " Hours";
        else if(totalTime < 31536000) return (totalTime/86400).ToString() + " Days";
        else return "Over a Year";
    }
}
