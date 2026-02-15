using Godot;
using System;

public partial class DataManager : GodotObject
{
    public static string name;
    public static string filename;

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
