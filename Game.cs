using Godot;
using System;

public partial class Game : Node2D
{
	private Control PauseMenu;
	private RigidBody2D player;

	// Called when the node enters the scene tree for the first time.
	public override void _Ready()
	{
		PauseMenu = GetNode<Control>("CanvasLayer/PauseMenu");
		player = GetNode<RigidBody2D>("player");
		ProcessMode = ProcessModeEnum.Always;
		
		player.DisableMode = CollisionObject2D.DisableModeEnum.Remove;
		player.ProcessMode = ProcessModeEnum.Pausable;
	}

	// Called every frame. 'delta' is the elapsed time since the previous frame.
	public override void _Process(double delta)
	{
	}

	public void _on_main_menu_pressed()
	{
		GetTree().Paused = false;
		GetTree().ChangeSceneToFile("res://MainMenu.tscn");
		DataManager.Save();
		DataManager.Clear();
	}

	public void _on_close_pressed()
	{
		PauseMenu.Visible = false;
		GetTree().Paused = false;
	}

	public override void _Input(InputEvent @event)
	{
		if(@event.IsActionPressed("Pause"))
		{
			PauseMenu.Visible = !PauseMenu.Visible;
			GetTree().Paused = PauseMenu.Visible;
		}
	}

}
