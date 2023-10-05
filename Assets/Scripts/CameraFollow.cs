using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CameraFollow : MonoBehaviour
{
    public float distanceZ;
    public float distanceX;
    public float height;
    public float smooth;
    public Transform target;
    Vector3 velocity;

    // Update is called once per frame
    void Update()
    {
        Vector3 pos = Vector3.zero;
        pos.x = target.position.x - distanceX;
        pos.y = target.position.y + height;
        pos.z = target.position.z - distanceZ;

        transform.position = Vector3.SmoothDamp(transform.position, pos, ref velocity, smooth);
    }
}
