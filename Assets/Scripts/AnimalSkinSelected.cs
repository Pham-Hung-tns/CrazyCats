using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class AnimalSkinSelected : MonoBehaviour
{
    public Texture2D[] skinColors;
    public Material animalMaterial;
    int selectedSkin;
    private void Awake()
    {
        selectedSkin = PlayerPrefs.GetInt("selectedSkin", 0);
        animalMaterial.mainTexture = skinColors[selectedSkin];
    }

    public void SetSkin(int id)
    {
        animalMaterial.mainTexture = skinColors[id];
    }
}
