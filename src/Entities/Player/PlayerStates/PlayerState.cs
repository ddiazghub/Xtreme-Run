using System;
using Godot;

public abstract class PlayerState: Node2D {
    protected Player player;

    public void Setup()
    {
        this.player = this.GetParent<Player>();

        this._Init();
    }

    public abstract void _StatePhysicsProcess(float delta);

    public abstract void _Init();

    public virtual void Block() {

    }

    public virtual void UnBlock() {
        
    }
}