using Godot;
using System;

public partial class Player_movement : RigidBody2D
{
	[Export]
	public int Speed { get; set; } = 2500;

	[Export]
	public float RotationSpeed { get; set; } = 1.5f;

	private float _rotationDirection;
	private float _yAxis;
	private float _xAxis;
	private Vector2 _forwardVector;
	
	public void GetInput()
	{
		//_rotationDirection = Input.GetAxis("move_left", "move_right");
		//GD.Print("Goalrotation " + (_goalRotation.Angle()*(Math.PI/180)));
		//Velocity = Transform.X * Input.GetAxis("move_down", "move_up") * Speed;
		//LookAt(GetGlobalMousePosition());
		float a;
		_xAxis = Input.GetAxis("look_left","look_right");
		//GD.Print(_xAxis);
		_yAxis = Input.GetAxis("look_up","look_down");
		if(_xAxis!=0 || _yAxis!=0 ){
			a=new Vector2(_xAxis,_yAxis).Angle();
		}else{
			a = GetGlobalMousePosition().AngleToPoint(Position)+(float)Math.PI;
		}
		
		
		//GD.Print(Position);
		_xAxis = Input.GetAxis("move_left", "move_right");
		//GD.Print(_xAxis);
		_yAxis = Input.GetAxis("move_up", "move_down");
		//GD.Print(_yAxis);
		_forwardVector = new Vector2(_xAxis,_yAxis);
		//GD.Print(_forwardVector);
		
		_forwardVector=_forwardVector.Normalized();
		//Velocity = _goalRotation * Speed;
		ApplyCentralForce(_forwardVector * Speed);
		Rotation = a;//LinearVelocity.Angle();
		
	}
	
	public override void _PhysicsProcess(double delta)
	{
		GetInput();
		
		//MoveAndSlide();
		/*float normalLerp = _goalRotation.Angle()-Rotation;
		GD.Print("Nlerp: "+normalLerp);
		float weight = 4.0f;
		if(normalLerp>Math.PI){
			GD.Print("ReducedLerp");
			weight*=-1;
		}*/
		//Rotation = Mathf.Lerp(Rotation,_goalRotation.Angle(),(float)delta*weight);
		//GD.Print("Rotation " + (Rotation*(Math.PI/180)));
		//Rotation += _rotateLR* RotationSpeed * (float)delta;
		//Rotation += _rotateUD * RotationSpeed * (float)delta;
		//GD.Print(_goalRotation);
		
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
