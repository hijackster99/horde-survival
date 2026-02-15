extends CharacterBody2D

@export var movement_speed : float = 500
var character_direction : Vector2

public override void _physics_process(delta):
	character_direction.x = Input.get_axis("move_left", "move_right")
	character_direction.y = Input.get_axis("move_up", "move_down")
	if character_direction.x > 0 :%sprite.flip_h = false
		
	elif
