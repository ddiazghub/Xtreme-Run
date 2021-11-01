using System;
using Godot;
using System.Collections.Generic;

public class Avatar {
    public bool male;
    public int skinColor;
    public int topColor;
    public int bottomColor;

    public static readonly Texture EMPTY_SAVE_AVATAR = ResourceLoader.Load<Texture>("res://res/Sprites/player/shadow.png");

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

    public Texture ToTexture()
    {
        string pathToImage;
        Dictionary<string, Color[]> colors;

        if (this.male)
        {
            pathToImage = "res://res/Sprites/player/idle.png";
            colors = Palette.DEFAULT_COLORS_MALE;
        }
        else
        {
            pathToImage = "res://res/Sprites/player/idlef.png";
            colors = Palette.DEFAULT_COLORS_FEMALE;
        }

        List<PaletteSwapEntry> swaps = new List<PaletteSwapEntry>();

        foreach (string key in colors.Keys)
        {
            if (this.GetColor(key) < 15)
            {
                foreach (Color color in colors[key])
                {
                    swaps.Add(new PaletteSwapEntry(color, Palette.Instance.PaletteColors[this.GetColor(key)], Palette.DEFAULT_THRESHOLD));
                }
            }
        }

        Image avatar = PaletteSwapShader.Instance.PaletteSwap(ResourceLoader.Load<Texture>(pathToImage).GetData(), swaps);
        ImageTexture avatarTexture = new ImageTexture();
        avatarTexture.CreateFromImage(avatar);

        return avatarTexture;
    }

    public Avatar Clone()
    {
        return new Avatar(this.male, this.skinColor, this.topColor, this.bottomColor);
    }

    public void Print()
    {
        GD.Print("Male: " + this.male);
        GD.Print("Skin Color: " + this.skinColor);
        GD.Print("Top Color: " + this.topColor);
        GD.Print("Bottom Color: " + this.bottomColor);
    }
}