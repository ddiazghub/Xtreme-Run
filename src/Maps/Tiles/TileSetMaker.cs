using Godot;
using System;

public class TileSetMaker : Node
{
    private Vector2 _tileSize = new Vector2(64, 64);
    private Texture _texture;

    public override void _Ready()
    {
        this._texture = this.GetNode<Sprite>("Sprite").Texture;
        int textureWidth = this._texture.GetWidth() / (int) this._tileSize.x;
        int textureHeight = this._texture.GetHeight() / (int) this._tileSize.y;

        TileSet tileSet = new TileSet();
        int id = 0;

        for (int x = 0; x < textureWidth; x++)
        {
            for (int y = 0; y < textureHeight; y++)
            {
                Rect2 region = new Rect2(
                    x * this._tileSize.x,
                    y * this._tileSize.y,
                    this._tileSize.x,
                    this._tileSize.y
                );

                tileSet.CreateTile(id);
                tileSet.TileSetTexture(id, this._texture);
                tileSet.TileSetRegion(id, region);
                RectangleShape2D shape = new RectangleShape2D();
                shape.Extents = _tileSize / 2;
                tileSet.TileSetShape(id, id, shape);
                tileSet.TileSetShapeOffset(id, id, _tileSize / 2);
                id++;
            }
        }

        ResourceSaver.Save("res://src/Maps/Tiles/level3tiles.tres", tileSet);
    }
}
