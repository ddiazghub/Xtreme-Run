using Godot;
using System;
using System.Collections.Generic;

/// <summary>
///     Class that contains data related to colors.
/// </summary>
public class Palette {
    /// <summary>
    ///     Singleton instance.
    /// </summary>
    private static Palette instance;

    /// <summary>
    ///     The number of available colors for the player's avatar.
    /// </summary>
    public static readonly int NUMBER_OF_COLORS = 15;

    /// <summary>
    ///     The default threshold difference for doing a palette swap.
    /// </summary>
    public static readonly Color DEFAULT_THRESHOLD = new Color(0.1f, 0.1f, 0.1f);

    /// <summary>
    ///     Default skin, top and bottom colors for male avatar.
    /// </summary>
    public static readonly Dictionary<string, Color[]> DEFAULT_COLORS_MALE = new Dictionary<string, Color[]>()
    {
        ["Skin"] = new Color[] {
            new Color(223, 161, 113) / 255,
            new Color (220, 126, 82) / 255,
            new Color (220, 191, 165) / 255,
            new Color (245, 156, 120) / 255,
        },

        ["Top"] = new Color[] {
            new Color(42, 90, 57) / 255,
            new Color (30, 53, 52) / 255,
            new Color (53, 81, 67) / 255,
        },

        ["Bottom"] = new Color[] {
            new Color(158, 77, 82) / 255,
            new Color (82, 59, 64) / 255
        }
    };

    /// <summary>
    ///     Default skin, top and bottom colors for female avatar.
    /// </summary>
    public static readonly Dictionary<string, Color[]> DEFAULT_COLORS_FEMALE = new Dictionary<string, Color[]>()
    {
        ["Skin"] = new Color[] {
            new Color(223, 161, 113) / 255,
            new Color (248, 179, 123) / 255,
            new Color (204, 118, 79) / 255,
            new Color (192, 112, 77) / 255
        },

        ["Top"] = new Color[] {
            new Color(88, 128, 204) / 255
        },

        ["Bottom"] = new Color[] {
            new Color(96, 96, 96) / 255,
            new Color (154, 133, 113) / 255
        }
    };

    /// <summary>
    ///     The available colors for avatar customization.
    /// </summary>
    public Color[] PaletteColors
    {
        get;
        private set;
    }

    /// <summary>
    ///     Loads palettes.
    /// </summary>
    private Palette()
    {
        this.PaletteColors = new Color[NUMBER_OF_COLORS];

        Image skinColorPalette = ResourceLoader.Load<Texture>("res://res/Sprites/player/skin_color/skin_color_palette.jpg").GetData();
        Image clothingColorPalette = ResourceLoader.Load<Texture>("res://res/Sprites/player/clothing_color/clothing_color.png").GetData();
        
        skinColorPalette.Lock();
        clothingColorPalette.Lock();

        for (int i = 0; i < PaletteColors.Length; i++)
            if (i < 5)
                PaletteColors[i] = skinColorPalette.GetPixel(i, 0);
            else
                PaletteColors[i] = clothingColorPalette.GetPixel(i - 5, 0);

        skinColorPalette.Unlock();
        clothingColorPalette.Unlock();
    }

    /// <summary>
    ///     Gets the game's palette.
    /// </summary>
    public static Palette Instance
    {
        get
        {
            if (instance == null)
                instance = new Palette();

            return instance;
        }
    }

    /// <summary>
    ///     Creates a rectangular shape and fills it with the color with the given id.
    /// </summary>
    /// <param name="id">The color's id.</param>
    /// <param name="size">The rectangle's size.</param>
    /// <returns>An rectangular image texture filled with the color.</returns>
    public Texture TextureFromColor(int id, Vector2 size)
    {
        Image color = new Image();
        color.Create((int) size.x, (int) size.y, false, Image.Format.Rgba8);
        color.Fill(this.PaletteColors[id]);

        ImageTexture texture = new ImageTexture();
        texture.CreateFromImage(color);

        return texture;
    }
}