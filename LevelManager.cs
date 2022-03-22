using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class LevelManager : MonoBehaviour
{
    public void DestroyObjectsOfType()
    {
        foreach (AgentMovement enemy in FindObjectsOfType<AgentMovement>())
        {
            print("Should be deleting objects");
            DestroyImmediate(enemy.transform.parent.gameObject);
        }
    }
}
