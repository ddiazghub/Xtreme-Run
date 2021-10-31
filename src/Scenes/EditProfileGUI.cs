using Godot;
using System;
using System.Collections.Generic;

public class EditProfileGUI : NinePatchRect
{
    
    private Image skinColorPalette = ResourceLoader.Load<Texture>("res://res/Sprites/player/skin_color/skin_color_palette.jpg").GetData();
    private Image clothingColorPalette = ResourceLoader.Load<Texture>("res://res/Sprites/player/clothing_color/clothing_color.png").GetData();
    private Texture checkTick = ResourceLoader.Load<Texture>("res://res/Sprites/player/level_keys/store_check.png");
    private Dictionary<string, int> selected;

    public override void _Ready()
    {
        this.Hide();
        this.selected = new Dictionary<string, int>();
        this.selected.Add("Skin", -1);
        this.selected.Add("Top", -1);
        this.selected.Add("Bottom", -1);
        
        this.skinColorPalette.Lock();
        this.clothingColorPalette.Lock();

        this.GetNode<TextureButton>("Cancel").Connect("pressed", this, nameof(this.OnCancelPressed));
        int skinColorNumber = (int) skinColorPalette.GetSize().x;
        int clothingColorNumber = (int) clothingColorPalette.GetSize().x;

        foreach (string key in this.selected.Keys)
        {
            int end = 0;
            int start = 0;
            Image palette = null;

            if (key.Equals("Skin"))
            {
                end = 5;
                palette = this.skinColorPalette;
            }

            if (key.Equals("Top") || key.Equals("Bottom"))
            {
                start = 5;
                end = 15;
                palette = this.clothingColorPalette;
            }

            for (int i = start; i < end; i++)
            {
                TextureButton button = new TextureButton();
                button.Name = i.ToString();

                Image color = new Image();
                color.Create(40, 40, false, Image.Format.Rgba8);

                if (key.Equals("Skin"))
                    color.Fill(palette.GetPixel(i, 0));
                else
                    color.Fill(palette.GetPixel(i - 5, 0));

                ImageTexture texture = new ImageTexture();
                texture.CreateFromImage(color);
                button.TextureNormal = texture;

                this.GetNode("Panel/" + key).AddChild(button);
                button.Connect("pressed", this, nameof(this.OnColorPressed));

                if (!Profile.CurrentSession.Info.OwnedItems[i])
                {
                    TextureRect textureRect = new TextureRect();
                    textureRect.Texture = this.checkTick;
                    button.AddChild(textureRect);
                }
            }
        }
    }

    public void OnColorPressed()
    {

    }

    public void OnCancelPressed()
    {
        this.Hide();
    }
}
