using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public abstract class PCGAbstractMapGenerator : MonoBehaviour
{
    [SerializeField]
    protected PCGTilemapVisualizer tilemapVisualizer = null;
    [SerializeField]
    protected Vector2Int startPosition = Vector2Int.zero;

    public void GenerateDungeon()
    {
        tilemapVisualizer.Clear();
        FindObjectOfType<LevelManager>().DestroyObjectsOfType();
        RunProceduralGeneration();
    }

    protected abstract void RunProceduralGeneration();
}
