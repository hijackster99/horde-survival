using Godot;
using System;

public partial class Player_movement : CharacterBody2D
{
	[Export]
	public int Speed { get; set; } = 40;

	[Export]
	public float RotationSpeed { get; set; } = 1.5f;

	private float _rotationDirection;
	private float _rotateUD;
	private float _rotateLR;
	private Vector2 _goalRotation;
	
	public void GetInput()
	{
		//_rotationDirection = Input.GetAxis("move_left", "move_right");
		
		_rotateLR = Input.GetAxis("move_left", "move_right");
		//GD.Print(_rotateLR);
		_rotateUD = Input.GetAxis("move_up", "move_down");
		_goalRotation += new Vector2(_rotateLR,_rotateUD);
		GD.Print("Goalrotation " + (_goalRotation.Angle()*(Math.PI/180)));
		_goalRotation=_goalRotation.Normalized();
		//Velocity = Transform.X * Input.GetAxis("move_down", "move_up") * Speed;
		Velocity = _goalRotation.Normalized() * Speed;
	}
	
	public override void _PhysicsProcess(double delta)
	{
		GetInput();
		//float normalLerp = _goalRotation.Angle()-Rotation;
		Rotation = Mathf.Lerp(Rotation,_goalRotation.Angle(),(float)delta*4.0f);
		GD.Print("Rotation " + (Rotation*(Math.PI/180)));
		//Rotation += _rotateLR* RotationSpeed * (float)delta;
		//Rotation += _rotateUD * RotationSpeed * (float)delta;
		//GD.Print(_goalRotation);
		MoveAndSlide();
		//Rotation = Input.GetAxis()
		//GD.Print(Transform.X.Normalized());
		//GD.Print(Position.X);
		
		/*int xAxis = 0;
		int yAxis = 0;
		
		if(Input.IsActionPressed("move_right")){
			xAxis+=1;
		}
		if(Input.IsActionPressed("move_left")){
			xAxis-=1;
		}
		
		if(Input.IsActionPressed("move_up")){
			yAxis-=1;
		}
		if(Input.IsActionPressed("move_down")){
			yAxis+=1;
		}
		
		if(xAxis == 0){
			if(yAxis>0){
				//down
				//GD.Print("penis");
				Rotation = (float)Math.PI;
			}else if(yAxis<0){
				//up
				Rotation = 0;
			}
			//
		}else if(yAxis==0){
			if(xAxis>0){
				//right
				Rotation = (float)Math.PI/2.0f;
			}else if(xAxis<0){
				//left
				Rotation = (float)Math.PI*1.5f;
			}
		}else{
			if(xAxis>0){
				if(yAxis>0){
					//downright
					Rotation = (float)Math.PI*.75f;
				}else{
					//upright
					Rotation = (float)Math.PI*.25f;
				}
			}else{
				if(yAxis>0){
					//downleft
					Rotation = (float)Math.PI*1.25f;
				}else{
					//upleft
					Rotation = (float)Math.PI*1.75f;
				}
			}
		}*/
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
