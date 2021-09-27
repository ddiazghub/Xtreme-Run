using Godot;
using System;

public class Player : KinematicBody2D
{
    [Export]
    public int JumpForce;
    [Export]
    public int Gravity;
    
    [Export]
    public int MovementSpeed;
    //Help
    [Export]
    public int TopJumpSpeed;
    
    [Export]
    public float MaxJumpTime;
    

    private bool _canJump = true;
    private bool _jumping = false;
    private bool _right = true;
    private Vector2 _linearVelocity = new Vector2();
    private Area2D _groundCollisionCheck;
    private AnimatedSprite _animation;
    private float _jumptime = 0;

    public override void _Ready()
    {
        this._animation = this.GetNode<AnimatedSprite>("Animation");
        this._animation.Play("running");
        this._groundCollisionCheck = this.GetNode<Area2D>("GroundCollisionCheck");
        this._groundCollisionCheck.Connect("body_entered", this, nameof(this.OnGroundCollisionCheckBodyEntered));
    }

    public override void _PhysicsProcess(float delta)
    {
        if (Input.IsActionPressed("jump") && this._canJump)
        {
            this._jumping = true;
        }

        if (this._jumping)
        {
            this._linearVelocity.y -= this.JumpForce;
            
            if (this._jumptime > this.MaxJumpTime)
            {
                this._jumping = false;
                this._canJump = false;
            }

            this._jumptime += delta;
        }

        if (this._right)
            this._linearVelocity.x = this.MovementSpeed;
        else
            this._linearVelocity.x = this.MovementSpeed;

        if (this._linearVelocity.y > -10000 && this._linearVelocity.y < 10000)
            this._linearVelocity.y += this.Gravity / 3;
        else
            this._linearVelocity.y += this.Gravity;
        
        if (this._linearVelocity.y > this.TopJumpSpeed)
            this._linearVelocity.y = this.TopJumpSpeed;

        if (this._linearVelocity.y < -this.TopJumpSpeed)
            this._linearVelocity.y = -this.TopJumpSpeed;

        this.MoveAndSlide(this._linearVelocity * delta, Vector2.Up);
    }

    public void OnGroundCollisionCheckBodyEntered(Node body)
    {
        if (body.IsInGroup("solid"))
        {
            this._canJump = true;
            this._jumptime = 0;
        }
    }
    /*

 Grounded?
var grounded = false 

# Jumping
var can_jump = false
var jump_time = 0
const TOP_JUMP_TIME = 0.1 # in seconds

# Start
func _ready():
	# Set player properties
	acceleration = 1000
	top_move_speed = 200
	top_jump_speed = 400

# Apply force
func apply_force(state):
	# Move Left
	if(Input.is_action_pressed("ui_left")):
		directional_force += DIRECTION.LEFT
	
	# Move Right
	if(Input.is_action_pressed("ui_right")):
		directional_force += DIRECTION.RIGHT
	
	# Jump
	if(Input.is_action_pressed("ui_select") && jump_time < TOP_JUMP_TIME && can_jump):
		directional_force += DIRECTION.UP
		jump_time += state.get_step()
	elif(Input.is_action_just_released("ui_select")):
		can_jump = false # Prevents the player from jumping more than once while in air
	
	# While on the ground
	if(grounded):
		can_jump = true
		jump_time = 0


# Enter Ground
func _on_ground_check_body_enter( body ):
	# Get groups
	var groups = body.get_groups()
	
	# If we are on a solid ground
	if(groups.has("solid")):
		grounded = true


# Exit Ground
func _on_ground_check_body_exit( body ):
	# Get groups
	var groups = body.get_groups()
	
	# If we are on a solid ground
	if(groups.has("solid")):
		grounded = false



    public void ApplyForce(Physics2DDirectBodyState state, Vector2 force) {
        if (this._canJump && Input.IsActionPressed("jump"))
        {
            force.y += -1;
            
		jump_time += state.get_step()
	elif(Input.is_action_just_released("ui_select")):
		can_jump = false # Prevents the player from jumping more than once while in air
        }
        }

        if (this._right)
        {
            force.x += 1;
        }
    }
    */
}
