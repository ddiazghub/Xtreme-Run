using Godot;
using System;
using System.Collections.Generic;

public class EditProfileGUI : NinePatchRect
{
    
    private Image skinColorPalette = ResourceLoader.Load<Texture>("res://res/Sprites/player/skin_color/skin_color_palette.jpg").GetData();
    private Image clothingColorPalette = ResourceLoader.Load<Texture>("res://res/Sprites/player/clothing_color/clothing_color.png").GetData();
    private Texture lockSprite = ResourceLoader.Load<Texture>("res://res/Sprites/player/level_keys/lock.png");
    
    private string[] keys = {
        "Skin",
        "Top",
        "Bottom"
    };

    private Dictionary<string, int> selected;
    private Dictionary<string, TextureRect> colorSelectors;

    private readonly int DEFAULT_COLOR = 15;

    public override void _Ready()
    {
        this.Hide();

        this.selected = new Dictionary<string, int>();
        this.colorSelectors = new Dictionary<string, TextureRect>();
        Texture lockTexture = ResourceLoader.Load<Texture>("res://res/Sprites/player/level_keys/avatar_color_select.png");

        foreach (string key in this.keys)
        {
            this.selected.Add(key, this.DEFAULT_COLOR);
            TextureRect selector = new TextureRect();
            selector.Texture = lockTexture;
            this.colorSelectors.Add(key, selector);
            this.AddChild(selector);

            this.GetNode<TextureButton>("Panel/" + key + "/" + DEFAULT_COLOR).Connect("pressed", this, nameof(this.OnColorPressed));
        }
        
        this.GetNode<LineEdit>("LineEdit").Text = Profile.CurrentSession.Info.Name;
        this.GetNode<OptionButton>("Panel/Gender").Selected = Convert.ToInt32(Profile.CurrentSession.Info.Avatar.male);

        this.skinColorPalette.Lock();
        this.clothingColorPalette.Lock();

        int skinColorNumber = (int) skinColorPalette.GetSize().x;
        int clothingColorNumber = (int) clothingColorPalette.GetSize().x;

        foreach (string key in this.keys)
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

                if (Profile.CurrentSession.Info.Avatar.GetColor(key) == i)
                    this.selected[key] = i;
            }
        }

        this.GetNode("Cancel").Connect("pressed", this, nameof(this.OnCancelPressed));
        this.GetNode("Panel/Save").Connect("pressed", this, nameof(this.OnSavePressed));
    }

    public override void _Process(float delta)
    {
        foreach (string key in this.keys)
        {
            int buttonCount = this.GetNode("Panel/" + key).GetChildCount();
            Godot.Collections.Array<TextureButton> children = new Godot.Collections.Array<TextureButton>(this.GetNode("Panel/" + key).GetChildren());
            
            foreach (TextureButton button in children)
            {
                if (button.GetChildCount() == 0 && button.Name.ToInt() == this.selected[key])
                    this.colorSelectors[key].RectGlobalPosition = button.RectGlobalPosition - new Vector2(5, 5);
                
                if (!Profile.CurrentSession.Info.OwnedItems[button.Name.ToInt()] && button.GetChildCount() == 0)
                {
                    TextureRect textureRect = new TextureRect();
                    textureRect.Texture = this.lockSprite;
                    textureRect.Name = "Lock";
                    button.AddChild(textureRect);
                }

                if (Profile.CurrentSession.Info.OwnedItems[button.Name.ToInt()] && !(button.GetChildCount() == 0))
                    button.GetNode("Lock").QueueFree();
            }
        }

        if (this.UnsavedChanges())
            this.GetNode<TextureButton>("Panel/Save").Disabled = false;
        else
            this.GetNode<TextureButton>("Panel/Save").Disabled = true;
    }

    public bool UnsavedChanges()
    {
        ProfileInfo profile = Profile.CurrentSession.Info;

        if (!profile.Name.Equals(this.GetNode<LineEdit>("LineEdit").Text) ||
            !(Convert.ToBoolean(this.GetNode<OptionButton>("Panel/Gender").Selected) == profile.Avatar.male))
        {
            return true;    
        }

        foreach (string key in this.keys)
        {
            if (!(profile.Avatar.GetColor(key) == this.selected[key]))
            {
                return true;
            }
        }

        return false;
    }

    public void OnColorPressed()
    {
        foreach (string key in this.keys)
        {
            int buttonCount = this.GetNode("Panel/" + key).GetChildCount();
            Godot.Collections.Array<TextureButton> children = new Godot.Collections.Array<TextureButton>(this.GetNode("Panel/" + key).GetChildren());
            
            foreach (TextureButton button in children)
            {
                if (button.GetChildCount() == 0 && button.Pressed)
                {
                    this.selected[key] = button.Name.ToInt();
                    this.colorSelectors[key].RectGlobalPosition = button.RectGlobalPosition - new Vector2(5, 5);
                }
            }
        }
    }

    public void OnCancelPressed()
    {
        this.Hide();
    }

    public void OnSavePressed()
    {
        ProfileInfo profile = Profile.CurrentSession.Info;
        profile.Name = this.GetNode<LineEdit>("LineEdit").Text;
        profile.Avatar.male = Convert.ToBoolean(this.GetNode<OptionButton>("Panel/Gender").Selected);

        foreach (string key in this.selected.Keys)
        {
            profile.Avatar.SetColor(key, this.selected[key]);
        }

        Profile.CurrentSession.Save();
        
        this.GetNode<AcceptDialog>("SavedAlert").PopupCentered();
    }
}
