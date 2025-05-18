using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerMovement : MonoBehaviour
{

    public float movementSpeed = 1f;

    Rigidbody2D rbody;

    [Header("Animation Settings")]
    public Animator animator;
    private bool facingRight = true;

    private void Awake()
    {
        rbody = GetComponent<Rigidbody2D>();
    }


    // Update is called once per frame
    void FixedUpdate()
    {
        Vector2 currentPos = rbody.position;
        float horizontalInput = Input.GetAxis("Horizontal");
        float verticalInput = Input.GetAxis("Vertical");
        Vector2 inputVector = new Vector2(horizontalInput, verticalInput);
        inputVector = Vector2.ClampMagnitude(inputVector, 1);
        Vector2 movement = inputVector * movementSpeed;
        Vector2 newPos = currentPos + movement * Time.fixedDeltaTime;
        rbody.MovePosition(newPos);
    }

    private void Update()
    {
        if (Input.GetKeyDown(KeyCode.A))
        {
            if (facingRight) Flip();
            animator.SetTrigger("MoveLeft");
        }
        if (Input.GetKeyDown(KeyCode.D))
        {
            if (!facingRight) Flip();
            animator.SetTrigger("MoveRight");
        }
        if (Input.GetKeyDown(KeyCode.W))
        {
            animator.SetTrigger("MoveUp");
        }
        if (Input.GetKeyDown(KeyCode.S))
        {
            animator.SetTrigger("MoveDown");
        }
    }

    private void Flip()
    {
        facingRight = !facingRight;
        Vector3 scale = transform.localScale;
        scale.x *= -1;
        transform.localScale = scale;
    }
}

