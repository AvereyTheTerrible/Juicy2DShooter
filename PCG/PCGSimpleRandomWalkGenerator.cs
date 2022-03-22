using System;
using System.Collections;
using System.Collections.Generic;
using System.Linq;
using UnityEngine;
using UnityEngine.Events;
using Cinemachine;
using Random = UnityEngine.Random;

public class PCGSimpleRandomWalkGenerator : PCGAbstractMapGenerator
{
    [SerializeField]
    protected SOSimpleRandomWalk randomWalkParameters;

    [SerializeField]
    private int enemyAmountToSpawn;

    [field: SerializeField]
    public UnityEvent OnGenerateMap;

    [SerializeField]
    private GameObject enemyPrefabToSpawn, heroPrefab;

    protected override void RunProceduralGeneration()
    {
        OnGenerateMap?.Invoke();
        HashSet<Vector2Int> floorPositions = RunRandomWalk(randomWalkParameters, startPosition);
        tilemapVisualizer.Clear();

        var instance = Instantiate(heroPrefab, (Vector3Int)startPosition, Quaternion.identity);
        FindObjectOfType<CinemachineVirtualCamera>().Follow = instance.GetComponentInChildren<Hero>().transform;
        tilemapVisualizer.PaintFloorTiles(floorPositions);
        for (int i = 0; i < enemyAmountToSpawn; i++)
        {
            var randomIndex = Random.Range(0, floorPositions.Count);

            var randomPosition = (Vector3Int)floorPositions.ElementAt(randomIndex);
            Instantiate(enemyPrefabToSpawn, randomPosition, Quaternion.identity);
        }


        tilemapVisualizer.PaintSurroundingFloorTiles(floorPositions);
        PCGWallGenerator.CreateWalls(floorPositions, tilemapVisualizer);
        PCGWallGenerator.CreateWallsColliders(floorPositions, tilemapVisualizer);
        PCGWallGenerator.CreateWallShadows(floorPositions, tilemapVisualizer);
    }

    protected HashSet<Vector2Int> RunRandomWalk(SOSimpleRandomWalk parameters, Vector2Int position)
    {
        var currentPosition = position;
        HashSet<Vector2Int> floorPositions = new HashSet<Vector2Int>();
        for (int i = 0; i < randomWalkParameters.iterations; i++)
        {
            var path = PCGAlgorithms.SimpleRandomWalk(currentPosition, randomWalkParameters.walkLength);
            floorPositions.UnionWith(path);
            if (randomWalkParameters.startRandomlyEachIteration)
                currentPosition = floorPositions.ElementAt(
                    UnityEngine.Random.Range(
                        0, 
                        floorPositions.Count));
        }
        return floorPositions;
    }
}
