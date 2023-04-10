using UnityEngine;
using UnityEngine.InputSystem;

public class PlayerSprint : PlayerBase
{
    [Header("Set up")]
    [SerializeField] float speed = 5f;
    [SerializeField] float sprintSpeed = 8f;
    [SerializeField] float minSprintTime = 0f;
    public float maxSprintTime = 5f;
    public float sprintTime = 5f;

    [SerializeField] PlayerMovement playerMovement;  

    bool canSprint;

    protected override void Start()
    {
        base.Start();

        playerMovement.currentSpeed = speed;
    }

    public void Sprint(InputAction.CallbackContext callback)
    {
        canSprint = callback.performed;
    }

    void Update()
    {
        SetPlayerSprint();
    }

    void SetPlayerSprint()
    {
        playerMovement.currentSpeed = speed;

        if (canSprint)
        {
            if (sprintTime > minSprintTime)
            {
                playerMovement.currentSpeed = sprintSpeed;
                sprintTime -= Time.deltaTime;
            }
        }
        else
        {
            sprintTime += Time.deltaTime;
        }
        sprintTime = Mathf.Clamp(sprintTime, minSprintTime, maxSprintTime);
    }
}
