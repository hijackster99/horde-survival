using Godot;
using System;

public partial class MainMenu : Node2D
{
	private Container Main;
	private Container Settings;
	private Container Load;

	// Called when the node enters the scene tree for the first time.
	public override void _Ready()
	{
		Main = GetNode<Container>("CenterContainer/MainMenu");
		Settings = GetNode<Container>("CenterContainer/SettingsMenu");
		Load = GetNode<Container>("CenterContainer/LoadMenu");
	}

	// Called every frame. 'delta' is the elapsed time since the previous frame.
	public override void _Process(double delta)
	{
	}

	public void _on_play_pressed()
	{
		GetTree().ChangeSceneToFile("res://Game.tscn");
	}
	public void _on_load_pressed()
	{
		Main.Visible = false;
		Load.Visible = true;
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
		Main.Visible = true;
	}
}
