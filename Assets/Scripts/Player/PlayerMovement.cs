using UnityEngine;
using UnityEngine.InputSystem;

public class PlayerMovement : PlayerBase
{
    public Vector2 direction;
    public Vector2 smoothDirection;
    Vector2 smoothVelocity;

    public float currentSpeed = 5;

    public void Move(InputAction.CallbackContext callback)
    {
        direction = callback.ReadValue<Vector2>();
    }

    void FixedUpdate()
    {
        SetPlayerVelocity();
    }

    void SetPlayerVelocity()
    {
        smoothDirection = Vector2.SmoothDamp(smoothDirection, direction, ref smoothVelocity, 0.1f);

        playerRigidbody2D.velocity = smoothDirection * currentSpeed;
    }
}
