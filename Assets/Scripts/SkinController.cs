using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SkinController : MonoBehaviour
{
    public GameObject shop;
    public AnimalSkinSelected skin;

    public void SelectSkin(int skinId)
    {
        //print("pokemon toi chon ban " + skinId);
        PlayerPrefs.SetInt("selectedSkin", skinId);
        skin.SetSkin(skinId);
        shop.SetActive(false);
    }
}
