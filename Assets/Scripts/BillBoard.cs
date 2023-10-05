using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BillBoard : MonoBehaviour
{
    Camera cam;
    private void Start()
    {
        cam = FindObjectOfType(typeof(Camera)) as Camera;
    }

    private void Update()
    {
        transform.LookAt(cam.transform.position);
        transform.Rotate(cam.transform.rotation.x, 180, cam.transform.rotation.z);
    }
}
