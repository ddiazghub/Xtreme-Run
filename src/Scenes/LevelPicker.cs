using Godot;
using System;

public class LevelPicker : SpinBox
{
    [Signal]
    public delegate void ValueChanged();

    private double currentValue;

    public override void _Ready()
    {
        this.Value = Profile.CurrentSession.Info.CurrentLevel;
        currentValue = this.Value;

        this.Connect("value_changed", this, nameof(this.OnValueChanged));
    }

    public void OnValueChanged(double value)
    {
        if (this.currentValue == 2 && !Profile.CurrentSession.Info.LevelIsUnlocked((int) value))
        {
            this.Value = this.currentValue;
        }
        else if (this.currentValue == 3 && !Profile.CurrentSession.Info.LevelIsUnlocked((int) value))
        {
            this.Value = 1;      
        }
        else if (this.currentValue == 1 && !Profile.CurrentSession.Info.LevelIsUnlocked((int) value))
        {
            if (Profile.CurrentSession.Info.LevelIsUnlocked(3))
                this.Value = 3;
            else
                this.Value = this.currentValue;
        }

        this.currentValue = this.Value;

        switch (this.Value)
        {
            case 1:
                this.Suffix = ": Caminata Pacífica";
                break;

            case 2:
                this.Suffix = ": Las Alturas";
                break;

            case 3:
                this.Suffix = ": Parkour en la Ciudad";
                break;
        }

        this.EmitSignal("ValueChanged");
    }
}
