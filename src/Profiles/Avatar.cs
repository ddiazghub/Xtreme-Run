using System;
using Godot;

public class Avatar {
    public bool male;
    public int skinColor;
    public int topColor;
    public int bottomColor;

    public Avatar(bool male, int skinColor, int topColor, int bottomColor)
    {
        this.male = male;
        this.skinColor = skinColor;
        this.topColor = topColor;
        this.bottomColor = bottomColor;
    }

    public int GetColor(string key)
    {
        switch (key)
        {
            case "Skin":
                return this.skinColor;

            case "Top":
                return this.topColor;
            
            case "Bottom":
                return this.bottomColor;
            
            default:
                return -1;
        }
    }

    public void SetColor(string key, int color)
    {
        switch (key)
        {
            case "Skin":
                this.skinColor = color;
                break;

            case "Top":
                this.topColor = color;
                break;
            
            case "Bottom":
                this.bottomColor = color;
                break;
        }
    }

    public void Print()
    {
        GD.Print("Male: " + this.male);
        GD.Print("Skin Color: " + this.skinColor);
        GD.Print("Top Color: " + this.topColor);
        GD.Print("Bottom Color: " + this.bottomColor);
    }
}