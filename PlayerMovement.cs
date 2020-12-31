using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerMovement : MonoBehaviour
{
    public CharacterController characterController;
    public float speed = 10f;
    public float gravity = -9.81f;
    public float jumpHeight = 3f;

    Vector3 velocity;

    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        float x = Input.GetAxis("Horizontal") * Time.deltaTime * speed;
        float y = Input.GetAxis("Vertical") * Time.deltaTime * speed;

        Vector3 move = transform.right * x + transform.forward * y;

        characterController.Move(move);

        velocity.y += gravity * Time.deltaTime;
        characterController.Move(velocity*Time.deltaTime);

        if (characterController.isGrounded && Input.GetKey(KeyCode.Space))
            velocity.y = jumpHeight;

        if (characterController.isGrounded&&velocity.y<0f)
            velocity.y = -2f;
    }
}
