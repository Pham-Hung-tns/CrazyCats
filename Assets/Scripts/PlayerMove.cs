using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerMove : MonoBehaviour
{
    private Touch touch;
    public float speed;
    public float posXmax;
    public float posXmin;

    // Update is called once per frame
    void Update()
    {
        // neu phat hien ra nguoi choi nhan vao man hinh
        if(Input.touchCount > 0)
        {
            // thong tin ngon tay dau tien nhan trn man hinh
            touch = Input.GetTouch(0);

            // touch.phase: trang thai cua ngon tay
            if (touch.phase == TouchPhase.Moved)
            {
                Vector3 pos = touch.deltaPosition;
                transform.position = new Vector3(
                    transform.position.x + pos.x * speed, 
                    transform.position.y, 
                    transform.position.z);
                if(transform.position.x > posXmax)
                {
                    transform.position = new Vector3(
                    posXmax,
                    transform.position.y,
                    transform.position.z);
                }
                else if(transform.position.x < posXmin)
                {
                    transform.position = new Vector3(
                    posXmin,
                    transform.position.y,
                    transform.position.z);
                }
            }
        }
    }
}
