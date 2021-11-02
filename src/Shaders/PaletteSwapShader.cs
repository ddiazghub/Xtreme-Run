using Godot;
using System;
using System.Collections.Generic;

/// <summary>
///     "Shader" for swapping colors in game textures.
/// </summary>
public class PaletteSwapShader {
    private static PaletteSwapShader instance;

    /// <summary>
    ///     Performs a palette swap on the given image by calculating the difference between each pixel's color and the target colors to swap.
    ///     Swaps each color whose difference with the target colors is smaller than the threshold.
    /// </summary>
    /// <param name="image">The image in which to swap colors.</param>
    /// <param name="swaps">A list of the colors that will be swapped.</param>
    /// <returns></returns>
    public Image PaletteSwap(Image image, List<PaletteSwapEntry> swaps)
    {
        Image modified = new Image();
        modified.CopyFrom(image);
        modified.Lock();

        List<List<Vector2>> toSwap = new List<List<Vector2>>();
        
        foreach (PaletteSwapEntry swap in swaps)
        {
            List<Vector2> pixelsToSwap = new List<Vector2>();
            Vector2 size = modified.GetSize();

            for (int i = 0; i < size.x; i++)
            {
                for (int j = 0; j < size.y; j++)
                {
                    Color pixel = modified.GetPixel(i, j);
                    Vector3 originalColor = new Vector3(swap.original.r, swap.original.b, swap.original.g);
                    Vector3 testColor = new Vector3(pixel.r, pixel.b, pixel.g);
                    Vector3 threshold = new Vector3(swap.threshold.r, swap.threshold.b, swap.threshold.g);

                   float difference = Math.Abs((originalColor - testColor).Length());
                    
                    if (difference < threshold.Length())
                        pixelsToSwap.Add(new Vector2(i, j));
                }
            }

            toSwap.Add(pixelsToSwap);
        }

        for (int i = 0; i < toSwap.Count; i++)
        {
            foreach (Vector2 pixel in toSwap[i])
            {
                modified.SetPixel((int) pixel.x, (int) pixel.y, swaps[i].newColor);
            }
        }

        modified.Unlock();

        return modified;
    }

    /// <summary>
    ///     Gets the shader instance.
    /// </summary>
    public static PaletteSwapShader Instance
    {
        get
        {
            if (instance == null)
                instance = new PaletteSwapShader();

            return instance;
        }
    }
}