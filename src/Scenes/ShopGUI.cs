using Godot;
using System;

/// <summary>
///     The shop from which the player can buy items.
/// </summary>
public class ShopGUI : NinePatchRect
{
    /// <summary>
    ///     Emitted if the player profile changed. (If an item was bought)
    /// </summary>
    [Signal]
    public delegate void ProfileChanged();

    /// <summary>
    ///     Array containing the cost of each item.
    /// </summary>
    private UInt32[] itemCost;

    /// <summary>
    ///     Image texture of the check for labeling owned items.
    /// </summary>
    private Texture checkTick = ResourceLoader.Load<Texture>("res://res/Sprites/player/level_keys/store_check.png");

    /// <summary>
    ///     Image texture of the lock for labeling locked items.
    /// </summary>
    private Texture lockSprite = ResourceLoader.Load<Texture>("res://res/Sprites/player/level_keys/lock_big.png");
    
    /// <summary>
    ///     The currently selected item.
    /// </summary>
    private int selected = -1;

    /// <summary>
    ///     Keys for labeling items.
    /// </summary>
    private string[] keys = {
        "Skin",
        "Clothing",
        "Keys"
    };

    public override void _Ready()
    {
        this.RectGlobalPosition = (Main.WINDOW_SIZE / 2) - (this.RectSize / 2);
        this.itemCost = new UInt32[SaveFileInfo.OWNED_ITEMS_BUFFER_LENGTH];

        for (int i = 0; i < this.itemCost.Length; i++)
        {
            if (i < 15)
                this.itemCost[i] = 700;
            else if (i == 15)
                this.itemCost[i] = 5000;
            else if (i == 16)
                this.itemCost[i] = 15000;
        }

        this.GetNode<TextureRect>("StoreSelect").Hide();

        this.GetNode<TextureButton>("Cancel").Connect("pressed", this, nameof(this.OnCancelPressed));

        foreach (string key in this.keys)
        {
            int end = 0;
            int start = 0;

            if (key.Equals("Skin"))
                end = 5;

            if (key.Equals("Clothing"))
            {
                start = 5;
                end = 15;
            }

            if (key.Equals("Keys"))
            {
                start = 15;
                end = 17;
            }

            for (int i = start; i < end; i++)
            {
                TextureButton button;

                if (key.Equals("Keys"))
                {
                    button = this.GetNode<TextureButton>("Keys/Buttons/" + i);
                }
                else
                {
                    button = new TextureButton();
                    button.Name = i.ToString();
                    button.TextureNormal = Palette.Instance.TextureFromColor(i, new Vector2(64, 64));

                    if (!PlayerSession.ActiveSession.Profile.OwnedItems[16])
                    {
                        TextureRect textureRect = new TextureRect();
                        textureRect.Texture = this.lockSprite;
                        button.AddChild(textureRect);
                    }
                    
                    this.GetNode(key + "/Buttons").AddChild(button);
                }

                button.Connect("pressed", this, nameof(this.OnItemButtonPressed));
                if (PlayerSession.ActiveSession.Profile.OwnedItems[i])
                {
                    TextureRect textureRect = new TextureRect();
                    textureRect.Texture = this.checkTick;
                    button.AddChild(textureRect);
                }
            }
        }

        this.GetNode("Buy").Connect("pressed", this, nameof(this.OnBuyPressed));
    }

    public void OnItemButtonPressed()
    {
        foreach (string key in this.keys)
        {
            int buttonCount = this.GetNode(key + "/Buttons").GetChildCount();
            Godot.Collections.Array<TextureButton> children = new Godot.Collections.Array<TextureButton>(this.GetNode(key + "/Buttons").GetChildren());
            
            foreach (TextureButton button in children)
            {
                if (button.GetChildCount() == 0 && button.Pressed)
                {
                    this.selected = button.Name.ToInt();
                    this.GetNode<TextureRect>("StoreSelect").RectGlobalPosition = button.RectGlobalPosition - new Vector2(5, 5);
                    this.GetNode<PointsCounter>("PointsCounter").Set(this.itemCost[this.selected]);
                    this.GetNode<TextureRect>("StoreSelect").Show();
                }
            }
        }
    }

    public void OnCancelPressed()
    {
        this.QueueFree();
    }

    public void OnBuyPressed()
    {
        if (this.selected == -1)
        {
            return;
        }

        if (PlayerSession.ActiveSession.Profile.Points >= this.itemCost[this.selected])
        {
            PlayerSession.ActiveSession.Profile.Points = PlayerSession.ActiveSession.Profile.Points - (UInt32) this.itemCost[this.selected];
            PlayerSession.ActiveSession.Profile.OwnedItems[this.selected] = true;
            PlayerSession.ActiveSession.Save();

            TextureRect textureRect = new TextureRect();
            TextureButton button;
            textureRect.Texture = this.checkTick;

            if (this.selected < 5)
                button = this.GetNode<TextureButton>("Skin/Buttons/" + this.selected);
            else if (this.selected < 15)
                button = this.GetNode<TextureButton>("Clothing/Buttons/" + this.selected);
            else
                button = this.GetNode<TextureButton>("Keys/Buttons/" + this.selected);

            button.AddChild(textureRect);
            this.selected = -1;
            this.GetNode<TextureRect>("StoreSelect").Hide();
            this.GetNode<AcceptDialog>("AcceptDialog2").PopupCentered();
        }
        else
        {
            this.GetNode<AcceptDialog>("AcceptDialog").PopupCentered();
        }

        this.EmitSignal("ProfileChanged");
    }
}
