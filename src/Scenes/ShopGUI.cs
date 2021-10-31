using Godot;
using System;

public class ShopGUI : NinePatchRect
{
    private UInt32[] itemCost;
    
    private Image skinColorPalette = ResourceLoader.Load<Texture>("res://res/Sprites/player/skin_color/skin_color_palette.jpg").GetData();
    private Image clothingColorPalette = ResourceLoader.Load<Texture>("res://res/Sprites/player/clothing_color/clothing_color.png").GetData();
    private Texture checkTick = ResourceLoader.Load<Texture>("res://res/Sprites/player/level_keys/store_check.png");
    private int selected = -1;

    public override void _Ready()
    {
        this.itemCost = new UInt32[SaveFileInfo.OWNED_ITEMS_BUFFER_LENGTH];

        for (int i = 0; i < this.itemCost.Length; i++)
        {
            if (i < 15)
                this.itemCost[i] = 700;
            else if (i == 15)
                this.itemCost[i] = 5000;
            else if (i == 16)
                this.itemCost[i] = 7500;
        }

        this.GetNode<TextureRect>("StoreSelect").Hide();
        this.skinColorPalette.Lock();
        this.clothingColorPalette.Lock();

        this.GetNode<TextureButton>("Cancel").Connect("pressed", this, nameof(this.OnCancelPressed));
        this.Hide();
        int skinColorNumber = (int) skinColorPalette.GetSize().x;
        int clothingColorNumber = (int) clothingColorPalette.GetSize().x;

        for (int i = 0; i < skinColorNumber; i++)
        {
            TextureButton button = new TextureButton();
            button.Name = i.ToString();

            Image color = new Image();
            color.Create(64, 64, false, Image.Format.Rgba8);
            color.Fill(this.skinColorPalette.GetPixel(i, 0));
            ImageTexture texture = new ImageTexture();
            texture.CreateFromImage(color);
            button.TextureNormal = texture;

            this.GetNode("SkinColors/Colors").AddChild(button);
            button.Connect("pressed", this, nameof(this.OnItemButtonPressed));

            if (Profile.CurrentSession.Info.OwnedItems[i])
            {
                TextureRect textureRect = new TextureRect();
                textureRect.Texture = this.checkTick;
                button.AddChild(textureRect);
            }
        }

        for (int i = 5; i < clothingColorNumber + 5; i++)
        {
            TextureButton button = new TextureButton();
            button.Name = i.ToString();
            Image color = new Image();
            color.Create(64, 64, false, Image.Format.Rgba8);
            color.Fill(this.clothingColorPalette.GetPixel(i - 5, 0));
            ImageTexture texture = new ImageTexture();
            texture.CreateFromImage(color);
            button.TextureNormal = texture;
            this.GetNode("ClothingColors/Colors").AddChild(button);
            button.Connect("pressed", this, nameof(this.OnItemButtonPressed));

            if (Profile.CurrentSession.Info.OwnedItems[i])
            {
                TextureRect textureRect = new TextureRect();
                textureRect.Texture = this.checkTick;
                button.AddChild(textureRect);
            }
        }

        for (int i = 15; i < 17; i++)
        {
            TextureButton button = this.GetNode<TextureButton>("LevelKeys/Keys/" + i);
            button.Connect("pressed", this, nameof(this.OnItemButtonPressed));

            if (Profile.CurrentSession.Info.OwnedItems[i])
            {
                TextureRect textureRect = new TextureRect();
                textureRect.Texture = this.checkTick;
                button.AddChild(textureRect);
            }
        }

        this.GetNode("Buy").Connect("pressed", this, nameof(this.OnBuyPressed));
    }

    public void OnItemButtonPressed()
    {
        int skinButtonCount = this.GetNode("SkinColors/Colors").GetChildCount();
        Godot.Collections.Array children = this.GetNode("SkinColors/Colors").GetChildren();

        for (int i = 0; i < skinButtonCount; i++)
        {
            if (((TextureButton) children[i]).GetChildCount() == 0 && ((TextureButton) children[i]).Pressed)
            {
                this.selected = ((Node) children[i]).Name.ToInt();
                this.GetNode<TextureRect>("StoreSelect").RectGlobalPosition = ((TextureButton) children[i]).RectGlobalPosition - new Vector2(5, 5);
                this.GetNode<PointsCounter>("PointsCounter").Set(this.itemCost[this.selected]);
            }
        }

        int clothingButtonCount = this.GetNode("ClothingColors/Colors").GetChildCount();
        children = this.GetNode("ClothingColors/Colors").GetChildren();

        for (int i = 0; i < clothingButtonCount; i++)
        {
            if (((TextureButton) children[i]).GetChildCount() == 0 && ((TextureButton) children[i]).Pressed)
            {
                this.selected = ((Node) children[i]).Name.ToInt();
                this.GetNode<TextureRect>("StoreSelect").RectGlobalPosition = ((TextureButton) children[i]).RectGlobalPosition - new Vector2(5, 5);
                this.GetNode<PointsCounter>("PointsCounter").Set(this.itemCost[this.selected]);
            }
        }

        int keyButtonCount = this.GetNode("LevelKeys/Keys").GetChildCount();
        children = this.GetNode("LevelKeys/Keys").GetChildren();

        for (int i = 0; i < keyButtonCount; i++)
        {
            if (((TextureButton) children[i]).GetChildCount() == 0 && ((TextureButton) children[i]).Pressed)
            {
                this.selected = ((Node) children[i]).Name.ToInt();
                this.GetNode<TextureRect>("StoreSelect").RectGlobalPosition = ((TextureButton) children[i]).RectGlobalPosition - new Vector2(5, 5);
                this.GetNode<PointsCounter>("PointsCounter").Set(this.itemCost[this.selected]);
            }
        }

        this.GetNode<TextureRect>("StoreSelect").Show();
    }

    public void OnCancelPressed()
    {
        this.Hide();
    }

    public void OnBuyPressed()
    {
        if (this.selected == -1)
        {
            return;
        }

        if (Profile.CurrentSession.Info.Points >= this.itemCost[this.selected])
        {
            Profile.CurrentSession.Info.Points = Profile.CurrentSession.Info.Points - (UInt32) this.itemCost[this.selected];
            Profile.CurrentSession.Info.OwnedItems[this.selected] = true;
            Profile.CurrentSession.Save();

            this.GetParent().GetNode<PointsCounter>("PointsCounter").Set(Profile.CurrentSession.Info.Points);

            TextureRect textureRect = new TextureRect();
            TextureButton button;
            textureRect.Texture = this.checkTick;

            if (this.selected < 5)
                button = this.GetNode<TextureButton>("SkinColors/Colors/" + this.selected);
            else if (this.selected < 15)
                button = this.GetNode<TextureButton>("ClothingColors/Colors/" + this.selected);
            else
                button = this.GetNode<TextureButton>("LevelKeys/Keys/" + this.selected);

            button.AddChild(textureRect);
            this.selected = -1;
            this.GetNode<TextureRect>("StoreSelect").Hide();
            this.GetNode<AcceptDialog>("AcceptDialog2").PopupCentered();
        }
        else
        {
            this.GetNode<AcceptDialog>("AcceptDialog").PopupCentered();
        }

    }
}
