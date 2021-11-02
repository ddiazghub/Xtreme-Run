using System;
using Godot;
using System.Collections.Generic;

/// <summary>
///     This class represents a customizable player avatar.
/// </summary>
public class Avatar {

    /// <summary>
    ///     The avatar's Gender. True if male, false if female.
    /// </summary>
    public bool Male { get; set; }

    /// <summary>
    ///     Id of the avatar's skin color.
    /// </summary>
    public int SkinColor;

    /// <summary>
    ///     Id of the avatar's bottom color.
    /// </summary>
    public int TopColor;

    /// <summary>
    ///     Id of the avatar's top color.
    /// </summary>
    public int BottomColor;

    /// <summary>
    ///     Default avatar for non-created profiles.
    /// </summary>
    public static readonly Texture EMPTY_SAVE_AVATAR = ResourceLoader.Load<Texture>("res://res/Sprites/player/shadow.png");

    /// <summary>
    ///     Creates a new avatar from the supplied data.
    /// </summary>
    /// <param name="male">The avatar's Gender. True if male, false if female.</param>
    /// <param name="skinColor">Id of the avatar's skin color.</param>
    /// <param name="topColor">Id of the avatar's bottom color.</param>
    /// <param name="bottomColor">Default avatar for non-created profiles.</param>
    public Avatar(bool male, int skinColor, int topColor, int bottomColor)
    {
        this.Male = male;
        this.SkinColor = skinColor;
        this.TopColor = topColor;
        this.BottomColor = bottomColor;
    }

    /// <summary>
    ///     Gets one of the avatar's colors from a given string.
    /// </summary>
    /// <param name="key">Can be Skin, Top or Bottom.</param>
    /// <returns>The color corresponding to the string.</returns>
    public int GetColor(string key)
    {
        switch (key)
        {
            case "Skin":
                return this.SkinColor;

            case "Top":
                return this.TopColor;
            
            case "Bottom":
                return this.BottomColor;
            
            default:
                return -1;
        }
    }

    /// <summary>
    ///     Sets one of the avatar's colors from a given string.
    /// </summary>
    /// <param name="key">Can be Skin, Top or Bottom.</param>
    public void SetColor(string key, int color)
    {
        switch (key)
        {
            case "Skin":
                this.SkinColor = color;
                break;

            case "Top":
                this.TopColor = color;
                break;
            
            case "Bottom":
                this.BottomColor = color;
                break;
        }
    }

    /// <summary>
    ///     Performs a palette swap on the default avatar, swapping the default colors for the colors specified in each property.
    ///     Converts the avatar into an image texture.
    /// </summary>
    /// <returns>The avatar as an image texture.</returns>
    public Texture ToTexture()
    {
        string pathToImage;
        Dictionary<string, Color[]> colors;

        if (this.Male)
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

    /// <summary>
    ///     Clones the avatar.
    /// </summary>
    /// <returns>A copy of the avatar.</returns>
    public Avatar Clone()
    {
        return new Avatar(this.Male, this.SkinColor, this.TopColor, this.BottomColor);
    }
}