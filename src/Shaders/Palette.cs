using Godot;
using System;
using System.Collections.Generic;

public class Palette {

    private static Palette instance;
    public static readonly int NUMBER_OF_COLORS = 15;
    public static readonly Color DEFAULT_THRESHOLD = new Color(0.1f, 0.1f, 0.1f);
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

    public Color[] PaletteColors
    {
        get;
        private set;
    }

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

    public static Palette Instance
    {
        get
        {
            if (instance == null)
                instance = new Palette();

            return instance;
        }
    }

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