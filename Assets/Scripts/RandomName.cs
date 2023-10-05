using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class RandomName : MonoBehaviour
{
    string[] names = {"Qynh", "Kate", "Jinro", "QiQi", "Hana", "Joz", "Pitokir", "Varog" };

    private void Awake()
    {
        this.gameObject.name = names[Random.Range(0, names.Length)];
    }
}
