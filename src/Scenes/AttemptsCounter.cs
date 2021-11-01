using Godot;
using System;

public class AttemptsCounter : Label
{
    private Vector2 initialPosition;
    private Vector2 rectInitialPosition;
    private NinePatchRect rect;

    public override void _Ready()
    {
        this.initialPosition = this.RectPosition;
        this.rect = this.GetNode<NinePatchRect>("NinePatchRect");
        this.rectInitialPosition = this.rect.RectPosition;
    }

    public void Set(int attempts)
    {
        this.RectSize = new Vector2(97, 28);
        this.RectPosition = this.initialPosition;
        this.rect.RectPosition = this.rectInitialPosition;

        string text = attempts.ToString();
        DynamicFont font = new DynamicFont();
        font.FontData = ResourceLoader.Load<DynamicFontData>("res://res/Fonts/Xolonium-Regular.ttf");
        font.Size = 24;
        float displacement = font.GetStringSize(text).x / 2;
        this.Text = "Intento " + text;
        this.RectPosition += new Vector2(-displacement, 0);
    }
}
