using Godot;
using System;

/// <summary>
///     Class that contains fields needed for Palette swapping.
/// </summary>
public class PaletteSwapEntry
{
    /// <summary>
    ///     Original target color.
    /// </summary>
    public Color original;

    /// <summary>
    ///     The color that the original will be swapped for.
    /// </summary>
    public Color newColor;

    /// <summary>
    ///     The threshold for swapping.
    /// </summary>
    public Color threshold;

    /// <summary>
    ///     Creates a new palette swap entry.
    /// </summary>
    /// <param name="original">Original target color.</param>
    /// <param name="newColor">The threshold for swapping.</param>
    /// <param name="threshold">Creates a new palette swap entry.</param>
    public PaletteSwapEntry(Color original, Color newColor, Color threshold)
    {
        this.original = original;
        this.newColor = newColor;
        this.threshold = threshold;
    }
}