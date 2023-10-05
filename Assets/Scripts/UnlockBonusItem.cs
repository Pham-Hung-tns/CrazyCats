using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class UnlockBonusItem : MonoBehaviour
{
    int totalDay; // tong so ngay choi game
    public Button skin2;
    private void Start()
    {
        totalDay = PlayerPrefs.GetInt("DaysPlayed",0);

        if(totalDay >= 2)
        {
            PlayerPrefs.SetInt("Skin2_Unlocked", 1);
            skin2.interactable = true;
        }
    }
}
