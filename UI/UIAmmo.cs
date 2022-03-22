using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;

public class UIAmmo : MonoBehaviour
{
    [SerializeField]
    private TextMeshProUGUI text = null;

    public void UpdateAmmoText(int ammoCount)
    {
        if (ammoCount == 0)
            text.color = Color.red;

        else
            text.color = Color.white;

        text.SetText(ammoCount.ToString());
    }
}