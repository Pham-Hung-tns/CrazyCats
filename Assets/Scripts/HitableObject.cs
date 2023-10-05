using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class HitableObject : MonoBehaviour
{
    public int point = 20;
    public int coin;

    private void Awake()
    {
        coin = PlayerPrefs.GetInt("coinsLevel",1);
    }
}
