using Godot;
using System;

/// <summary>
///     Node for making tilesets from an image.
/// </summary>
public class TileSetMaker : Node
{
    /// <summary>
    ///     The size of each tile.
    /// </summary>
    [Export]
    public Vector2 TileSize = new Vector2(64, 64);

    /// <summary>
    ///     The image texture from which to create the tileset.
    /// </summary>
    [Export]
    public Texture Texture;

    /// <summary>
    ///     The path where the tileset will be save.
    /// </summary>
    [Export]
    public string FilePath = "res://src/Maps/Tiles/tiles.tres";

    public override void _Ready()
    {
        int textureWidth = this.Texture.GetWidth() / (int) this.TileSize.x;
        int textureHeight = this.Texture.GetHeight() / (int) this.TileSize.y;

        TileSet tileSet = new TileSet();
        int id = 0;

        for (int x = 0; x < textureWidth; x++)
        {
            for (int y = 0; y < textureHeight; y++)
            {
                Rect2 region = new Rect2(
                    x * this.TileSize.x,
                    y * this.TileSize.y,
                    this.TileSize.x,
                    this.TileSize.y
                );

                tileSet.CreateTile(id);
                tileSet.TileSetTexture(id, this.Texture);
                tileSet.TileSetRegion(id, region);
                RectangleShape2D shape = new RectangleShape2D();
                shape.Extents = TileSize / 2;
                tileSet.TileSetShape(id, id, shape);
                tileSet.TileSetShapeOffset(id, id, TileSize / 2);
                id++;
            }
        }

        ResourceSaver.Save(this.FilePath, tileSet);
    }
}
