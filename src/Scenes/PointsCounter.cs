using Godot;
using System;

public class PointsCounter : MarginContainer
{
    public override void _Ready()
    {
        Label label = this.GetNode<Label>("Background/Label");
        DynamicFont font = new DynamicFont();
        font.FontData = ResourceLoader.Load<DynamicFontData>("res://res/Fonts/Xolonium-Regular.ttf");
        font.Size = 24;
        GD.Print(Profile.CurrentSession);
        float labelSize = font.GetStringSize(Profile.CurrentSession.Info.Points.ToString()).x;
        this.RectSize += new Vector2(labelSize, 0);
        this.RectPosition += new Vector2(-labelSize, 0);
        this.GetNode<TextureRect>("Background/Icon").RectPosition += new Vector2(labelSize, 0);
        label.Text = Profile.CurrentSession.Info.Points.ToString();
    }
}
