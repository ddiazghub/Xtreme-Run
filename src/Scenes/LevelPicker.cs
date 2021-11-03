using Godot;
using System;

/// <summary>
///     Node for picking a level on the main menu.
/// </summary>
public class LevelPicker : SpinBox
{
    /// <summary>
    ///     Emitted when the player changes the value on this picker.
    /// </summary>
    [Signal]
    public delegate void ValueChanged();

    /// <summary>
    ///     The current value.
    /// </summary>
    private double currentValue;

    public override void _Ready()
    {
        this.Value = PlayerSession.ActiveSession.Profile.CurrentLevel;
        currentValue = this.Value;

        this.Connect("value_changed", this, nameof(this.OnValueChanged));

        this.OnValueChanged(this.Value);
    }

    public void OnValueChanged(double value)
    {
        if (this.currentValue == 2 && !PlayerSession.ActiveSession.Profile.LevelIsUnlocked((int) value))
        {
            this.Value = this.currentValue;
        }
        else if (this.currentValue == 3 && !PlayerSession.ActiveSession.Profile.LevelIsUnlocked((int) value))
        {
            this.Value = 1;      
        }
        else if (this.currentValue == 1 && !PlayerSession.ActiveSession.Profile.LevelIsUnlocked((int) value))
        {
            if (PlayerSession.ActiveSession.Profile.LevelIsUnlocked(3))
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
