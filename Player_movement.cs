using Godot;
using System;

public partial class Player_movement : RigidBody2D
{
	[Export]
	public int Speed { get; set; } = 2500;

	[Export]
	public float RotationSpeed { get; set; } = 1.5f;

	private float _yAxis;
	private float _xAxis;
	private Vector2 _forwardVector;
	
	public void GetInput()
	{
		float a;
		_xAxis = Input.GetAxis("look_left","look_right");
		//GD.Print(_xAxis);
		_yAxis = Input.GetAxis("look_up","look_down");
		if(_xAxis!=0 || _yAxis!=0 ){
			a=new Vector2(_xAxis,_yAxis).Angle();
		}else{
			a = GetGlobalMousePosition().AngleToPoint(Position)+(float)Math.PI;
		}
		
		_xAxis = Input.GetAxis("move_left", "move_right");
		_yAxis = Input.GetAxis("move_up", "move_down");
		_forwardVector = new Vector2(_xAxis,_yAxis);
		
		_forwardVector=_forwardVector.Normalized();
		ApplyCentralForce(_forwardVector * Speed);
		Rotation = a;
	}
	
	public override void _PhysicsProcess(double delta)
	{
		GetInput();
	}
	
	// Called when the node enters the scene tree for the first time.
	public override void _Ready()
	{
	}

	// Called every frame. 'delta' is the elapsed time since the previous frame.
	public override void _Process(double delta)
	{
		
	}
	
	
}
