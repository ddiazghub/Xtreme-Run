using Godot;
using System;

public class PaletteSwapEntry
{
    public Color original;
    public Color newColor;
    public Color threshold;

    public PaletteSwapEntry(Color original, Color newColor, Color threshold)
    {
        this.original = original;
        this.newColor = newColor;
        this.threshold = threshold;
    }
}