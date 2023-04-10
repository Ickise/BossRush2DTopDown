using UnityEngine;
using UnityEngine.InputSystem;
using System.Collections;

public class PlayerDash : PlayerBase
{
    [Header("Set up")]
    public float timeBeforeDash = 5f;
    public float maxTimeBeforeDash = 5f;
    [SerializeField] float minTimeBeforeDash = 0f;
    [SerializeField] float invincibilityTime = 1.3f;
    [SerializeField] float forceValue = 6f;

    [SerializeField] PlayerMovement playerMovement;

    [SerializeField] Vector2 force;

    [SerializeField] AudioClip dashAudio;

    float currentSpeed = 5;

    bool canDash;

    public void Dash(InputAction.CallbackContext callback)
    {
        canDash = callback.performed;
    }

    void FixedUpdate()
    {
        SetDash();
    }

    void SetDash()
    {
        if (canDash)
        {
            if (timeBeforeDash == maxTimeBeforeDash)
            {
                AudioManager._instance.PlaySFX(dashAudio);

                force = new Vector2(playerMovement.smoothDirection.x * forceValue, playerMovement.smoothDirection.y * forceValue);
                playerRigidbody2D.velocity = force * currentSpeed;

                timeBeforeDash = minTimeBeforeDash;

                StartCoroutine(Invicibility());
            }
        }

        if (timeBeforeDash >= minTimeBeforeDash)
        {
            timeBeforeDash += Time.deltaTime;
        }
        timeBeforeDash = Mathf.Clamp(timeBeforeDash, minTimeBeforeDash, maxTimeBeforeDash);
    }

    IEnumerator Invicibility()
    {
        playerCollider2D.enabled = false;
        yield return new WaitForSeconds(invincibilityTime);
        playerCollider2D.enabled = true;
    }
}
