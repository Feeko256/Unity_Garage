using UnityEngine;

public class Movement : MonoBehaviour
{
    public Camera camera;
    public float speed = 5.0f;
    public float jumpHeight = 2.0f;
    private CharacterController controller;
    private Vector3 moveDirection = Vector3.zero;
    private float gravity = 9.81f;

    void Start()
    {
        controller = GetComponent<CharacterController>();
    }

    void Update()
    {
        if (controller.isGrounded)
        {

            float moveHorizontal = Input.GetAxis("Horizontal") ;
            float moveVertical = Input.GetAxis("Vertical");

            Vector3 movement = new Vector3(moveHorizontal, 0.0f, moveVertical);
            moveDirection = camera.transform.TransformDirection(movement) * speed;

            if (Input.GetButton("Jump"))
            {
                moveDirection.y = Mathf.Sqrt(jumpHeight * 2.0f * gravity);
            }
        }

        moveDirection.y -= gravity * Time.deltaTime;
        controller.Move(moveDirection * Time.deltaTime);
    }
}
