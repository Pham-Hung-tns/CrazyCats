using UnityEngine;

public class SimpleTouchToMove : MonoBehaviour
{
    Touch touch;
    //vi tri ngon tay tuong tac voi man hinh
    Vector3 initPos;

    // huong di chuyen
    Vector3 direction;

    Vector3 moveDirection;
    public GameManager gm;
    public float speed = 0.5f;
    public float gravity = 10f;
    public float jumpForce = 5f;
    public float stopForce = 2f;
    public CharacterController characterController;
    public GameObject jumpEffect;

    private Animator anim;
    bool canMove = false;

    private void Start()
    {
        anim = GetComponent<Animator>();
    }
    void Update()
    {
        if (gm.gameEnded)
        {
            anim.SetBool("canMove", false);
            return;
        }
            if (Input.touchCount > 0)
        {
            canMove = true;


            touch = Input.GetTouch(0);
            if (touch.phase == TouchPhase.Began)
            {
                initPos = touch.position;
            }
            if (touch.phase == TouchPhase.Moved)
            {
                direction = touch.deltaPosition;
            }

            if (characterController.isGrounded)
            {
                moveDirection = new Vector3(
                    touch.position.x - initPos.x,
                    0,
                    touch.position.y - initPos.y
                    );

                Quaternion targetRotation = moveDirection != Vector3.zero ? Quaternion.LookRotation(moveDirection) : transform.rotation;
                transform.rotation = targetRotation;
                moveDirection = moveDirection.normalized * speed;
            }

        }
        else
        {
            canMove = false;
            moveDirection = Vector3.Lerp(moveDirection, Vector3.zero, Time.deltaTime * stopForce);
        }

        anim.SetBool("canMove", canMove);

        if (Input.GetMouseButtonUp(0) && characterController.isGrounded)
        {
            Instantiate(jumpEffect, transform.position, Quaternion.identity);
            moveDirection.y += jumpForce;
        }

        moveDirection.y = moveDirection.y - (gravity * Time.deltaTime);

        characterController.Move(moveDirection * Time.deltaTime);

    }
}
