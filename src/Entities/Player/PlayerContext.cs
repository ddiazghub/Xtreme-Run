using Godot;
using System;

public class PlayerContext
{
    public Area2D groundCollisionCheck;
    public Area2D frontCollisionCheck;
    public Area2D jumpObjectCollisionCheck;
    public Timer slideTimer;
    public Timer jumpTimer;
    public AnimatedSprite animation;
    public int jumpForce = 100000;
    public int movementSpeed = 42800;
    public int topFallSpeed = 100000;
    public float maxJumpTime = 0.04f;
    public bool right = true;
    public int gravity = 10000;
}

