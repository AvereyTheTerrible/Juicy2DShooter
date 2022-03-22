using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public static class PCGWallGenerator
{
    public static void CreateWalls(HashSet<Vector2Int> floorPositions, PCGTilemapVisualizer tilemapVisualizer)
    {
        var basicWallPositions = FindWallsInDirections(floorPositions, Direction2D.cardinalDirectionsList);
        foreach (var position in basicWallPositions)
        {
            tilemapVisualizer.PaintSingleBasicFrontWall(position);
            tilemapVisualizer.PaintSingleBasicFrontWall(position + new Vector2Int(0, 1)); // up
            tilemapVisualizer.PaintSingleBasicFrontWall(position + new Vector2Int(1, 1)); // upright
            tilemapVisualizer.PaintSingleBasicFrontWall(position + new Vector2Int(1, 0)); // right
            tilemapVisualizer.PaintSingleBasicFrontWall(position + new Vector2Int(1, -1)); // rightdown
            tilemapVisualizer.PaintSingleBasicFrontWall(position + new Vector2Int(0, -1)); // down
            tilemapVisualizer.PaintSingleBasicFrontWall(position + new Vector2Int(-1, -1)); // leftdown
            tilemapVisualizer.PaintSingleBasicFrontWall(position + new Vector2Int(-1, 0)); // left
            tilemapVisualizer.PaintSingleBasicFrontWall(position + new Vector2Int(-1, 1)); // leftup);
        }
    }

    public static void CreateWallsColliders(HashSet<Vector2Int> floorPositions, PCGTilemapVisualizer tilemapVisualizer)
    {
        var basicWallPositions = FindWallsInDirections(floorPositions, Direction2D.cardinalDirectionsList);
        foreach (var position in basicWallPositions)
        {
            tilemapVisualizer.PaintWallTileCollider(position);
            tilemapVisualizer.PaintWallTileCollider(position + new Vector2Int(0, 1)); // up
            tilemapVisualizer.PaintWallTileCollider(position + new Vector2Int(1, 1)); // upright
            tilemapVisualizer.PaintWallTileCollider(position + new Vector2Int(1, 0)); // right
            tilemapVisualizer.PaintWallTileCollider(position + new Vector2Int(1, -1)); // rightdown
            tilemapVisualizer.PaintWallTileCollider(position + new Vector2Int(0, -1)); // down
            tilemapVisualizer.PaintWallTileCollider(position + new Vector2Int(-1, -1)); // leftdown
            tilemapVisualizer.PaintWallTileCollider(position + new Vector2Int(-1, 0)); // left
            tilemapVisualizer.PaintWallTileCollider(position + new Vector2Int(-1, 1)); // leftup);
        }
    }

    public static void CreateWallShadows(HashSet<Vector2Int> floorPositions, PCGTilemapVisualizer tilemapVisualizer)
    {
        var basicWallPositions = FindWallsInDirections(floorPositions, Direction2D.cardinalDirectionsList);
        foreach (var position in basicWallPositions)
        {
            tilemapVisualizer.PaintWallTileShadow(position);
            tilemapVisualizer.PaintWallTileShadow(position + new Vector2Int(0, 1)); // up
            tilemapVisualizer.PaintWallTileShadow(position + new Vector2Int(1, 1)); // upright
            tilemapVisualizer.PaintWallTileShadow(position + new Vector2Int(1, 0)); // right
            tilemapVisualizer.PaintWallTileShadow(position + new Vector2Int(1, -1)); // rightdown
            tilemapVisualizer.PaintWallTileShadow(position + new Vector2Int(0, -1)); // down
            tilemapVisualizer.PaintWallTileShadow(position + new Vector2Int(-1, -1)); // leftdown
            tilemapVisualizer.PaintWallTileShadow(position + new Vector2Int(-1, 0)); // left
            tilemapVisualizer.PaintWallTileShadow(position + new Vector2Int(-1, 1)); // leftup);
        }
    }

    private static HashSet<Vector2Int> FindWallsInDirections(HashSet<Vector2Int> floorPositions, List<Vector2Int> directionList)
    {
        HashSet<Vector2Int> wallPositions = new HashSet<Vector2Int>();
        foreach (var position in floorPositions)
        {
            foreach (var direction in directionList)
            {
                var neighborPosition = position + direction;
                if (!floorPositions.Contains(neighborPosition))
                {
                    wallPositions.Add(neighborPosition);
                }
            }
        }

        return wallPositions;
    }
}
