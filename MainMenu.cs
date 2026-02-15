using Godot;
using System;
using System.Collections.Generic;
using System.IO.Enumeration;
using System.Linq;

public partial class MainMenu : Node2D
{
	private Container Main;
	private Container Settings;
	private Container Load;
	private Container MenuButtons;
	private Container GameCreation;
	private LineEdit SaveName;
	private ItemList List;
	private List<string> Saves;

	// Called when the node enters the scene tree for the first time.
	public override void _Ready()
	{
		DirAccess.MakeDirAbsolute("user://saves");

		Main = GetNode<Container>("MenuButtons/MainMenu");
		Settings = GetNode<Container>("MenuButtons/SettingsMenu");
		Load = GetNode<Container>("MenuButtons/LoadMenu");
		MenuButtons = GetNode<Container>("MenuButtons");
		GameCreation = GetNode<Container>("GameCreation");
		SaveName = GetNode<LineEdit>("GameCreation/VBoxContainer/SaveName");
		List = GetNode<ItemList>("MenuButtons/LoadMenu/Saves");

		Saves = new List<string>();
	}

	// Called every frame. 'delta' is the elapsed time since the previous frame.
	public override void _Process(double delta)
	{
	}

	public void _on_play_pressed()
	{
		MenuButtons.Visible = false;
		GameCreation.Visible = true;
	}
	public void _on_load_pressed()
	{
		Main.Visible = false;
		Load.Visible = true;

		UpdateLoadList();
	}
	public void _on_settings_pressed()
	{
		Main.Visible = false;
		Settings.Visible = true;
	}
	public void _on_quit_pressed()
	{
		GetTree().Quit();
	}
	public void _on_back_pressed()
	{
		Settings.Visible = false;
		Load.Visible = false;
		GameCreation.Visible = false;
		MenuButtons.Visible = true;
		Main.Visible = true;
	}

	public void _on_start_pressed()
	{
		string name = SaveName.Text.Trim();
		if(name != "")
		{
			string filename = GetFileName(name);
			int i = 1;
			while(FileAccess.FileExists("user://saves//" + filename + ".dat"))
			{
				filename = filename + "_" + i;
				i++;
			}

			DataManager.name = name;
			DataManager.filename = filename + ".dat";
			DataManager.Save();

			GetTree().ChangeSceneToFile("res://Game.tscn");
		}
	}

	private string GetFileName(string name)
	{
		string filename = name.ToLower().Replace(' ', '-');

		return filename;
	}

	private void UpdateLoadList()
	{
		Saves.Clear();

		var dir = DirAccess.Open("user://saves");
		if(dir != null)
		{
			foreach(string file in dir.GetFiles())
			{
				string name = DataManager.LoadName(file);
				List.AddItem(name);
				Saves.Add(file);
			}
		}
	}

	public void _on_select_pressed()
	{
		if(!List.GetSelectedItems().IsEmpty())
		{
			_on_saves_item_activated(List.GetSelectedItems()[0]);
		}
	}

	public void _on_saves_item_activated(int index)
	{
		if(index < Saves.Count)
		{
			DataManager.Load(Saves.ElementAt<string>(index));
			GetTree().ChangeSceneToFile("res://Game.tscn");
		}
	}
}
