using Godot;
using System;

public class ProfileSelect : Node2D
{
    private Button[] saves;
    private ExitGamePopup exitPopup;
    private CreateProfileDialog createPopup;

    public override void _Ready()
    {
        this.saves = new Button[6];

        for (int i = 0; i < 6; i++)
        {
            this.saves[i] = this.GetNode<Button>("GUI/" + i.ToString());
            this.saves[i].Connect("pressed", this, nameof(this.OnSaveButtonPressed));

            if (Profile.Exists(i))
            {
                ProfileInfo profile = Profile.Get(i);
                
                if (profile != null)
                {
                    this.saves[i].GetNode<Label>("Label").Text = profile.Name;
                    Image image = new Image();
                    image.Load("res://res/Sprites/player/idle.png");
                    ImageTexture texture = new ImageTexture();
                    texture.CreateFromImage(image, 0);
                    this.saves[i].GetNode<Sprite>("Sprite").Texture = texture;
                }
            }
        }

        this.exitPopup = this.GetNode<ExitGamePopup>("GUI/ExitGamePopup");
        this.createPopup = this.GetNode<CreateProfileDialog>("GUI/CreateProfileDialog");
    }

    public override void _Process(float delta)
    {
        if (Input.IsActionPressed("ui_cancel"))
        {
            this.exitPopup.PopupCentered();
        }
    }
    public void OnSaveButtonPressed()
    {
        foreach (Button button in this.saves)
        {
            if (button.Pressed)
            {
                if (Profile.Exists(button.Name.ToInt()))
                {
                    Profile.CurrentSession.Load(button.Name.ToInt());
                    this.GetParent<Main>().ChangeScene(GameScenes.MAIN_MENU);
                }
                else
                {
                    this.createPopup.profileID = button.Name.ToInt();
                    this.createPopup.PopupCentered();
                }
            }
        }
    }
}
