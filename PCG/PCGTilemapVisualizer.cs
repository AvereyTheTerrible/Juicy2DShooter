using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Tilemaps;

public class PCGTilemapVisualizer : MonoBehaviour
{
    [SerializeField]
    private Tilemap floorTilemap, frontWallTilemap, backWallTilemap, collisionTilemap, shadowTilemap;
    [SerializeField]
    private TileBase floorTile, wallRuleTile, wallBottom;

    public void PaintFloorTiles(IEnumerable<Vector2Int> floorPositions)
    {
        PaintTiles(floorPositions, floorTilemap, floorTile);
    }

    public void PaintSingleBasicFrontWall(Vector2Int position)
    {
        PaintSingleTile(frontWallTilemap, wallRuleTile, position);
    }

    public void PaintSingleBasicBackWall(Vector2Int position)
    {
        PaintSingleTile(backWallTilemap, wallBottom, position);
    }

    public void PaintWallTileCollider(Vector2Int position)
    {
        PaintSingleTile(collisionTilemap, wallRuleTile, position);
    }

    public void PaintWallTileShadow(Vector2Int position)
    {
        PaintSingleTile(shadowTilemap, wallRuleTile, position);
    }



    internal void PaintSurroundingFloorTiles(HashSet<Vector2Int> floorPositions)
    {
        foreach (var floorPosition in floorPositions)
        {
            foreach (var direction in Direction2D.cardinalDirectionsUnitList)
            {
                var neighbor = floorPosition + direction;
                PaintSingleTile(floorTilemap, floorTile, neighbor);
                foreach (var dir in Direction2D.cardinalDirectionsUnitList)
                {
                    PaintSingleTile(floorTilemap, floorTile, neighbor + dir);
                }

            }

        }
    }
    private void PaintTiles(IEnumerable<Vector2Int> positions, Tilemap tilemap, TileBase tile)
    {
        foreach (var position in positions)
        {
            PaintSingleTile(tilemap, tile, position);
        }
    }

    private void PaintSingleTile(Tilemap tilemap, TileBase tile, Vector2Int position)
    {
        var tilePosition = tilemap.WorldToCell((Vector3Int)position);
        tilemap.SetTile(tilePosition, tile);
    }

    public void Clear()
    {
        frontWallTilemap.ClearAllTiles();
        floorTilemap.ClearAllTiles();
        collisionTilemap.ClearAllTiles();
        shadowTilemap.ClearAllTiles();
    }
}
