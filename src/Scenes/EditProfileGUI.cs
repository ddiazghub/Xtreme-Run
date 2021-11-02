using Godot;
using System;
using System.Collections.Generic;

/// <summary>
///     GUI that allows the player to edit their profile data and customize their avatar.
/// </summary>
public class EditProfileGUI : NinePatchRect {

    /// <summary>
    ///     Emitted if the user profile's data was modified.
    /// </summary>
    [Signal]
    public delegate void ProfileChanged();

    /// <summary>
    ///     Sprite for labeling items which have not been unlocked yet.
    /// </summary>
    private Texture lockSprite = ResourceLoader.Load<Texture>("res://res/Sprites/player/level_keys/lock.png");
    
    /// <summary>
    ///     A copy of the player's avatar which will be edited.
    /// </summary>
    private Avatar editedAvatar = Profile.CurrentSession.Info.Avatar.Clone();

    /// <summary>
    ///     Keys for labeling colors.
    /// </summary>
    private string[] keys = {
        "Skin",
        "Top",
        "Bottom"
    };

    /// <summary>
    ///     The ids of the currently selected colors for skin, top, and bottom.
    /// </summary>
    private Dictionary<string, int> selected;

    /// <summary>
    ///     Icons for labeling the currently selected colors.
    /// </summary>/
    private Dictionary<string, TextureRect> colorSelectors;

    /// <summary>
    ///     The id of the avatar default colors.
    /// </summary>
    private readonly int DEFAULT_COLOR = 15;

    public override void _Ready()
    {
        this.RectGlobalPosition = (Main.WINDOW_SIZE / 2) - (this.RectSize / 2);

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
        this.GetNode<OptionButton>("Panel/Gender").Selected = Convert.ToInt32(Profile.CurrentSession.Info.Avatar.Male);

        foreach (string key in this.keys)
        {
            int end = 0;
            int start = 0;

            if (key.Equals("Skin"))
                end = 5;

            if (key.Equals("Top") || key.Equals("Bottom"))
            {
                start = 5;
                end = 15;
            }

            for (int i = start; i < end; i++)
            {
                TextureButton button = new TextureButton();
                button.Name = i.ToString();
                button.TextureNormal = Palette.Instance.TextureFromColor(i, new Vector2(40, 40));

                this.GetNode("Panel/" + key).AddChild(button);

                button.Connect("pressed", this, nameof(this.OnColorPressed));

                if (Profile.CurrentSession.Info.Avatar.GetColor(key) == i)
                    this.selected[key] = i;
            }
        }

        this.UpdateAvatar();

        this.GetNode("Cancel").Connect("pressed", this, nameof(this.OnCancelPressed));
        this.GetNode("Panel/Save").Connect("pressed", this, nameof(this.OnSavePressed));
        this.GetNode("Panel/Gender").Connect("item_selected", this, nameof(this.OnGenderItemSelected));
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
                
                if (!(button.Name.ToInt() == 15 || button.Name.ToInt() == 16) && !Profile.CurrentSession.Info.OwnedItems[button.Name.ToInt()] && button.GetChildCount() == 0)
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

        if (Convert.ToBoolean(this.GetNode<OptionButton>("Panel/Gender").Selected) != this.editedAvatar.Male)
            this.UpdateAvatar();

        if (this.UnsavedChanges())
            this.GetNode<TextureButton>("Panel/Save").Disabled = false;
        else
            this.GetNode<TextureButton>("Panel/Save").Disabled = true;
    }

    /// <summary>
    ///     Checks if the player has edited their avatar and the changes haven't been saved.
    /// </summary>
    /// <returns>True if the changes are unsaved, false otherwise.</returns>
    public bool UnsavedChanges()
    {
        ProfileInfo profile = Profile.CurrentSession.Info;

        if (!profile.Name.Equals(this.GetNode<LineEdit>("LineEdit").Text) ||
            !(this.editedAvatar.Male == profile.Avatar.Male))
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

    /// <summary>
    ///     Updates the data of the avatar being edited depending on user input. Displays the new avatar.
    /// </summary>
    public void UpdateAvatar()
    {
        this.editedAvatar.Male = Convert.ToBoolean(this.GetNode<OptionButton>("Panel/Gender").Selected);

        foreach (string key in this.selected.Keys)
        {
            this.editedAvatar.SetColor(key, this.selected[key]);
        }

        this.GetNode<TextureRect>("Avatar").Texture = this.editedAvatar.ToTexture();
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
                    this.UpdateAvatar();
                }
            }
        }
    }

    public void OnGenderItemSelected(int index)
    {
        this.editedAvatar.Male = Convert.ToBoolean(index);
        this.UpdateAvatar();
    }

    public void OnCancelPressed()
    {
        this.QueueFree();
    }

    public void OnSavePressed()
    {
        ProfileInfo profile = Profile.CurrentSession.Info;
        string newName = this.GetNode<LineEdit>("LineEdit").Text;
        
        if (!profile.Name.Equals(newName))
        {
            if (!Profile.NameIsAvailable(newName))
            {
                this.GetNode<AcceptDialog>("FailedAlert").PopupCentered();

                return;
            }

            profile.Name = this.GetNode<LineEdit>("LineEdit").Text;
        }

        profile.Avatar.Male = Convert.ToBoolean(this.GetNode<OptionButton>("Panel/Gender").Selected);

        foreach (string key in this.selected.Keys)
        {
            profile.Avatar.SetColor(key, this.selected[key]);
        }

        Profile.CurrentSession.Save();
        
        this.GetNode<AcceptDialog>("SavedAlert").PopupCentered();
        this.EmitSignal("ProfileChanged");
    }
}
