using Godot;
using System;

public partial class Game : Node2D
{
	private bool paused;
	private Control PauseMenu;

	// Called when the node enters the scene tree for the first time.
	public override void _Ready()
	{
		paused = false;
		PauseMenu = GetNode<Control>("PauseMenu");
	}

	// Called every frame. 'delta' is the elapsed time since the previous frame.
	public override void _Process(double delta)
	{
	}

	public void _on_main_menu_pressed()
	{
		GetTree().ChangeSceneToFile("res://MainMenu.tscn");
	}

	public void _on_close_pressed()
	{
		paused = false;
		PauseMenu.Visible = false;
	}

    public override void _Input(InputEvent @event)
    {
        if(@event.IsActionPressed("Pause") && !paused)
		{
			paused = true;
			PauseMenu.Visible = true;
		}
    }

}
