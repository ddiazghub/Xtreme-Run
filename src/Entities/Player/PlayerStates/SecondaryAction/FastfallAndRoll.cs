using Godot;
using System;

public class FastFallAndRoll: PlayerState {
    private bool blocked = false;
    public bool performingAction = false;

    public override void _Init()
    {
        this.player.slideTimer.Connect("timeout", this, nameof(this.OnSlideTimerTimeout));
        this.player.slideTimer.Start();
    }

    public override void _StatePhysicsProcess(float delta)
    {
        if (Input.IsActionJustReleased("action_secondary") && this.blocked) {
            this.blocked = false;
        }

        if (Input.IsActionPressed("action_secondary") && !this.blocked)
        {
            if (this.player.persistentState is OnGroundState) {
                this.player.animation.Play("sliding");
                this.performingAction = true;
                this.player.slideTimer.Start();
                this.player.mainAction.Block();
                this.blocked = true;
                this.player.SetHitbox(PlayerPersistentState.SECONDARY_ACTION);
            }

            if (this.player.persistentState is OnAirState) {
                this.player.linearVelocity.y = 100000;
            }
        }
    }

    public void OnSlideTimerTimeout()
    {
        this.player.animation.Play("running");
        this.player.mainAction.UnBlock();
        this.performingAction = false;
        this.player.SetHitbox(PlayerPersistentState.ON_GROUND);
    }
}