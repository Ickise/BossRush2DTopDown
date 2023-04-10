using UnityEngine;
using UnityEngine.InputSystem;
using System.Collections;

public class PlayerMovement : MonoBehaviour
{
    public static PlayerMovement player;

    Rigidbody2D playerRigidbody2D;

    Collider2D playerCollider2D;

    public Vector2 direction;
    Vector2 smoothDirection;
    Vector2 smoothVelocity;

    bool canSprint;
    bool canDash;

    float currentSpeed;

    [Header("Set up")]

    [SerializeField] float speed = 5f;
    [SerializeField] float sprintSpeed = 8f;
    [SerializeField] float maxSprintTime = 5f;
    [SerializeField] float minSprintTime = 0f;
    [SerializeField] float sprintTime = 5f;
    [SerializeField] float timeBeforeDash = 5f;
    [SerializeField] float maxTimeBeforeDash = 5f;
    [SerializeField] float minTimeBeforeDash = 0f;
    [SerializeField] float invincibilityTime = 1.3f;

    [SerializeField] Vector2 force;

    [SerializeField] AudioClip dashAudio;

    void Awake()
    {
        player = this;
    }

    void Start()
    {
        currentSpeed = speed;

        playerRigidbody2D = GetComponent<Rigidbody2D>();

        playerCollider2D = GetComponent<Collider2D>();
    }

    public void Move(InputAction.CallbackContext callback)
    {
        direction = callback.ReadValue<Vector2>();
    }

    public void Sprint(InputAction.CallbackContext callback)
    {
        canSprint = callback.performed;
    }

    public void Dash(InputAction.CallbackContext callback)
    {
        canDash = callback.performed;
    }

    void Update()
    {
        SetPlayerSprint();
    }

    void FixedUpdate()
    {
        SetPlayerVelocity();
        SetDash();
    }

    void SetPlayerVelocity()
    {
        smoothDirection = Vector2.SmoothDamp(smoothDirection, direction, ref smoothVelocity, 0.1f);

        playerRigidbody2D.velocity = smoothDirection * currentSpeed;
    }

    void SetPlayerSprint()
    {
        currentSpeed = speed;

        if (canSprint)
        {
            if (sprintTime > minSprintTime)
            {
                currentSpeed = sprintSpeed;
                sprintTime -= Time.deltaTime;
            }
        }
        else
        {
            sprintTime += Time.deltaTime;
        }
        sprintTime = Mathf.Clamp(sprintTime, minSprintTime, maxSprintTime);
    }

    void SetDash()
    {
        if (canDash)
        {
            if (timeBeforeDash == maxTimeBeforeDash)
            {
                AudioManager._instance.PlaySFX(dashAudio);

                force = new Vector2(smoothDirection.x * 6f, smoothDirection.y * 6f);
                playerRigidbody2D.velocity = force * currentSpeed;
                timeBeforeDash = minSprintTime;
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
