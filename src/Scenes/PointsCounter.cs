using Godot;
using System;

/// <summary>
///     Node for displaying a number of points.
/// </summary>
public class PointsCounter : MarginContainer
{
    private Vector2 initialPosition;
    private Vector2 iconInitialPosition;

    public override void _Ready()
    {
        this.initialPosition = this.RectPosition;
        this.iconInitialPosition = this.GetNode<TextureRect>("Background/Icon").RectPosition;
    }

    /// <summary>
    ///     Sets a new number of points to display.
    /// </summary>
    /// <param name="points">Number of points.</param>
    public void Set(UInt32 points)
    {
        this.RectSize = new Vector2(104, 46);
        this.RectPosition = this.initialPosition;
        this.GetNode<TextureRect>("Background/Icon").RectPosition = this.iconInitialPosition;

        string text = points.ToString();
        Label label = this.GetNode<Label>("Background/Label");
        TextureRect icon = this.GetNode<TextureRect>("Background/Icon");
        DynamicFont font = new DynamicFont();
        font.FontData = ResourceLoader.Load<DynamicFontData>("res://res/Fonts/Xolonium-Regular.ttf");
        font.Size = 24;
        float labelSize = font.GetStringSize(text).x;

        this.RectSize += new Vector2(labelSize, 0);
        this.RectPosition += new Vector2(-labelSize, 0);
        icon.RectPosition += new Vector2(labelSize, 0);
        label.Text = text;
    }
}
