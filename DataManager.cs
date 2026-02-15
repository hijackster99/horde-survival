using Godot;
using System;

public partial class DataManager : GodotObject
{
    public static string name;
    public static string filename;

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
        file.Close();
    }

    public static void Load(string filename)
    {
        DataManager.filename = filename;
		var file = FileAccess.Open("user://saves//" + filename, FileAccess.ModeFlags.Read);
        name = file.GetLine();
        file.Close();
    }

    public static string LoadName(string filename)
    {
        var file = FileAccess.Open("user://saves//" + filename, FileAccess.ModeFlags.Read);
        return file.GetLine();
    }
}
