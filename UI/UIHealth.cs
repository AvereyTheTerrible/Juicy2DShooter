using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class UIHealth : MonoBehaviour
{
    [SerializeField]
    private GameObject heartPrefab = null, healthPanel = null;
    [SerializeField]
    private Sprite heartFull = null, heartEmpty = null;

    private int heartCount = 0;
    private List<Image> hearts = new List<Image>();


    public void Initialize(int lifeCount)
    {
        heartCount = lifeCount;
        foreach (Transform child in healthPanel.transform)
        {
            Destroy(child.gameObject);
        }

        for (int i = 0; i < lifeCount; i++)
        {
            hearts.Add(Instantiate(heartPrefab, healthPanel.transform).GetComponent<Image>());
        }
    }

    public void UpdateUI(int health)
    {
        int currentIndex = 0;
        for (int i = 0; i < heartCount; i++)
        {
            if (currentIndex >= health)
                hearts[i].sprite = heartEmpty;
            else
                hearts[i].sprite = heartFull;

            currentIndex++;
        }
    }
}