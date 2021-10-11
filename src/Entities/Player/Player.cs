using Godot;
using System;

public class Player : KinematicBody2D
{
    [Export] public int jumpForce = 100000;
    [Export] public int movementSpeed = 42800;
    [Export] public int topFallSpeed = 100000;
    [Export] public float maxJumpTime = 0.04f;
    [Export] public bool right = true;
    [Export] public int gravity = 10000;
    public Area2D groundCollisionCheck;
    public Area2D frontCollisionCheck;
    public Area2D jumpObjectCollisionCheck;
    public Timer slideTimer;
    public Timer jumpTimer;
    public AnimatedSprite animation;
    public PlayerState persistentState;
    public PlayerState mainAction;
    public PlayerState secondaryAction;
    public PlayerStateFactory stateFactory;
    public Vector2 linearVelocity = new Vector2();

    [Signal]
    public delegate void Dead();

    public override void _Ready()
    {
        this.animation = this.GetNode<AnimatedSprite>("Animation");
        this.slideTimer = this.GetNode<Timer>("SlideTimer");
        this.jumpTimer = this.GetNode<Timer>("JumpTimer");
        this.groundCollisionCheck = this.GetNode<Area2D>("GroundCollisionCheck");
        this.jumpObjectCollisionCheck = this.GetNode<Area2D>("JumpObjectCollisionCheck");
        this.frontCollisionCheck = this.GetNode<Area2D>("FrontCollisionCheck");

        this.stateFactory = new PlayerStateFactory();
        this.ChangePersistentState(PlayerPersistentState.ON_GROUND);
        this.ChangeMainAction(PlayerMainAction.JUMP);
        this.ChangeSecondaryAction(PlayerSecondaryAction.FASTFALL_AND_ROLL);
    }

    public override void _PhysicsProcess(float delta)
    {
        this.persistentState._StatePhysicsProcess(delta);
        this.mainAction._StatePhysicsProcess(delta);
        this.secondaryAction._StatePhysicsProcess(delta);
        this.MoveAndSlide(this.linearVelocity * delta, Vector2.Up);
    }

    public void ChangePersistentState(PlayerPersistentState state)
    {
        if (this.persistentState != null)
        {
            this.persistentState.QueueFree();
        }


        this.persistentState = this.stateFactory.New(state);
        this.AddChild(this.persistentState);
        this.persistentState.Setup();
    }

    public void ChangeMainAction(PlayerMainAction action)
    {
        if (this.mainAction != null)
        {
            this.mainAction.QueueFree();
        }

        this.mainAction = this.stateFactory.New(action);
        this.AddChild(this.mainAction);
        this.mainAction.Setup();
    }

    public void ChangeSecondaryAction(PlayerSecondaryAction action)
    {
        if (this.secondaryAction != null)
        {
            this.secondaryAction.QueueFree();
        }

        this.secondaryAction = this.stateFactory.New(action);
        this.AddChild(this.secondaryAction);
        this.secondaryAction.Setup();
    }

    public void SetHitbox(PlayerPersistentState state) {
        switch (state) {
            case PlayerPersistentState.ON_GROUND:
                this.frontCollisionCheck.GetNode<CollisionShape2D>("RunningCollisionShape").SetDeferred("disabled", false);
                this.frontCollisionCheck.GetNode<CollisionShape2D>("SlidingCollisionShape").SetDeferred("disabled", true);
                this.frontCollisionCheck.GetNode<CollisionShape2D>("JumpingCollisionShape").SetDeferred("disabled", true);
                this.GetNode<CollisionShape2D>("RunningCollision").SetDeferred("disabled", false);
                this.GetNode<CollisionShape2D>("SlidingCollision").SetDeferred("disabled", true);
                break;

            case PlayerPersistentState.ON_AIR:
                this.frontCollisionCheck.GetNode<CollisionShape2D>("RunningCollisionShape").SetDeferred("disabled", true);
                this.frontCollisionCheck.GetNode<CollisionShape2D>("SlidingCollisionShape").SetDeferred("disabled", true);
                this.frontCollisionCheck.GetNode<CollisionShape2D>("JumpingCollisionShape").SetDeferred("disabled", false);
                this.GetNode<CollisionShape2D>("RunningCollision").SetDeferred("disabled", false);
                this.GetNode<CollisionShape2D>("SlidingCollision").SetDeferred("disabled", true);
                break;

            case PlayerPersistentState.SECONDARY_ACTION:
                this.frontCollisionCheck.GetNode<CollisionShape2D>("RunningCollisionShape").SetDeferred("disabled", true);
                this.frontCollisionCheck.GetNode<CollisionShape2D>("SlidingCollisionShape").SetDeferred("disabled", false);
                this.frontCollisionCheck.GetNode<CollisionShape2D>("JumpingCollisionShape").SetDeferred("disabled", true);
                this.GetNode<CollisionShape2D>("RunningCollision").SetDeferred("disabled", true);
                this.GetNode<CollisionShape2D>("SlidingCollision").SetDeferred("disabled", false);
                break;
        }
    }
}


/*using Godot;
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
    public int TopFallSpeed;
    
    [Export]
    public float MaxJumpTime;

    [Signal]
    public delegate void Dead();

    private bool _canJump = true;
    private bool _jumping = false;
    private bool _right = true;
    private bool _onJumpObject = false;
    private bool _released = true;
    private bool _sliding = false;
    private Vector2 _linearVelocity = new Vector2();
    private Area2D _groundCollisionCheck;
    private Area2D _frontCollisionCheck;
    private Area2D _jumpObjectCollisionCheck;
    private Timer _slideTimer;
    private AnimatedSprite _animation;
    private float _jumptime = 0;

    public override void _Ready()
    {
        this._animation = this.GetNode<AnimatedSprite>("Animation");
        this._animation.Play("running");
        this._slideTimer = this.GetNode<Timer>("SlideTimer");
        this._slideTimer.Connect("timeout", this, nameof(this.OnSlideTimerTimeout));
        this._groundCollisionCheck = this.GetNode<Area2D>("GroundCollisionCheck");
        this._groundCollisionCheck.Connect("body_entered", this, nameof(this.OnGroundCollisionCheckBodyEntered));
        this._groundCollisionCheck.Connect("body_exited", this, nameof(this.OnGroundCollisionCheckBodyExited));
        this._jumpObjectCollisionCheck = this.GetNode<Area2D>("JumpObjectCollisionCheck");
        this._jumpObjectCollisionCheck.Connect("area_entered", this, nameof(this.OnJumpObjectCollisionCheckAreaEntered));
        this._jumpObjectCollisionCheck.Connect("area_exited", this, nameof(this.OnJumpObjectCollisionCheckAreaExited));
        this._frontCollisionCheck = this.GetNode<Area2D>("FrontCollisionCheck");
        this._frontCollisionCheck.Connect("body_entered", this, nameof(this.OnFrontCollisionCheckBodyEntered));
    }

    public override void _PhysicsProcess(float delta)
    {
        GD.Print(this._frontCollisionCheck.GetNode<CollisionShape2D>("RunningCollisionShape").Disabled);
        if (Input.IsActionPressed("jump") && !this._sliding)
        {
            if (this._canJump || (this._onJumpObject && this._released))
            {
                this._jumping = true;
                this._released = false;
                this._canJump = false;
                this._jumptime = 0;
            }
        }

        if (Input.IsActionJustReleased("jump") )
        {
            this._released = true;
        }

        if (Input.IsActionPressed("down") && this.IsOnFloor() && !this._sliding)
        {
            this._animation.Play("sliding");
            this._frontCollisionCheck.GetNode<CollisionShape2D>("RunningCollisionShape").Disabled = true;
            this._frontCollisionCheck.GetNode<CollisionShape2D>("SlidingCollisionShape").Disabled = false;
            this.GetNode<CollisionShape2D>("RunningCollision").Disabled = true;
            this.GetNode<CollisionShape2D>("SlidingCollision").Disabled = false;
            this._sliding = true;
            this._slideTimer.Start();
        }

        if (this._jumping)
        {
            this._linearVelocity.y -= this.JumpForce;
            
            if (this._jumptime > this.MaxJumpTime)
            {
                this._jumping = false;
            }

            this._jumptime += delta;
        }

        if (this._right)
            this._linearVelocity.x = this.MovementSpeed;
        else
            this._linearVelocity.x = this.MovementSpeed;

        if (this._linearVelocity.y > -10000 && this._linearVelocity.y < 10000)
            this._linearVelocity.y += this.Gravity / 5;
        else
            this._linearVelocity.y += this.Gravity;
        
        if (this._linearVelocity.y > this.TopFallSpeed)
            this._linearVelocity.y = this.TopFallSpeed;

        if (this._linearVelocity.y < -this.JumpForce)
            this._linearVelocity.y = -this.JumpForce;

        this.MoveAndSlide(this._linearVelocity * delta, Vector2.Up);
    }

    public void OnGroundCollisionCheckBodyEntered(Node body)
    {
        if (body.IsInGroup("solid"))
        {
            this._canJump = true;
            this._frontCollisionCheck.GetNode<CollisionShape2D>("RunningCollisionShape").Disabled = false;
        }
    }

    public void OnGroundCollisionCheckBodyExited(Node body)
    {
        if (body.IsInGroup("solid")) 
        {
            this._frontCollisionCheck.GetNode<CollisionShape2D>("RunningCollisionShape").Disabled = true;

            if (!this._jumping)
            {
                this._canJump = false;
                this._linearVelocity.y = 5000;
            }
        }
    }

    public void OnJumpObjectCollisionCheckAreaEntered(Area2D area)
    {
        if (area.IsInGroup("jump"))
        {
            this._onJumpObject = true;
        }

        if (area.IsInGroup("jump_auto"))
        {
            this._jumping = true;
            this._released = false;
            this._canJump = false;
            this._jumptime = 0;
        }
    }

    public void OnJumpObjectCollisionCheckAreaExited(Area2D area)
    {
        this._onJumpObject = false;
        if (area.IsInGroup("jump") && !this.IsOnFloor())
        {
            this._canJump = false;
        }
    }

    public void OnFrontCollisionCheckBodyEntered(Node body)
    {
        if (body.IsInGroup("solid"))
        {
            EmitSignal("Dead");
        }
    }

    public void OnSlideTimerTimeout()
    {
        this._animation.Play("running");
        if (this.IsOnFloor())
            this._frontCollisionCheck.GetNode<CollisionShape2D>("RunningCollisionShape").Disabled = false;
        this._frontCollisionCheck.GetNode<CollisionShape2D>("SlidingCollisionShape").Disabled = true;
        this.GetNode<CollisionShape2D>("RunningCollision").Disabled = false;
        this.GetNode<CollisionShape2D>("SlidingCollision").Disabled = true;
        this._frontCollisionCheck.GetNode<CollisionShape2D>("SlidingCollisionShape").Disabled = false;
        this._sliding = false;

    }
*//*

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

