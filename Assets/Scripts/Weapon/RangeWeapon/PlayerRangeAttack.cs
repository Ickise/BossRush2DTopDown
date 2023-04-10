using UnityEngine.InputSystem;
using UnityEngine;

public class PlayerRangeAttack : MonoBehaviour
{
    [Header("Set up")]
    [SerializeField] float timeBeforeAttack;
    [SerializeField] float maxTimeBeforeAttack = 1f;
    [SerializeField] float minTimeBeforeAttack = 0f;

    [SerializeField] Animator playerAnimator;

    [SerializeField] Transform projectile;

    [SerializeField] AudioClip shoot;

    bool canRangeAttack;

    Vector2 mousePosition;

    public void Attack(InputAction.CallbackContext callback)
    {
        canRangeAttack = callback.performed;
    }

    public void Mouse(InputAction.CallbackContext callback)
    {
        mousePosition = callback.ReadValue<Vector2>();
    }

    void Update()
    {
        if (canRangeAttack)
        {
            if (timeBeforeAttack == maxTimeBeforeAttack)
            {
                playerAnimator.SetBool("IsRangeAttacking", true);
            }
        }
        else
        {
            playerAnimator.SetBool("IsRangeAttacking", false);
        }

        if (timeBeforeAttack >= minTimeBeforeAttack)
        {
            timeBeforeAttack += Time.deltaTime;
        }

        timeBeforeAttack = Mathf.Clamp(timeBeforeAttack, minTimeBeforeAttack, maxTimeBeforeAttack);
    }

    public void StartRangeAttack()
    {
        timeBeforeAttack = minTimeBeforeAttack;
        AudioManager._instance.PlaySFX(shoot);
        Transform newProjectile = Instantiate(projectile, transform.position, Quaternion.identity);

        Vector3 worldPosition = Camera.main.ScreenToWorldPoint(mousePosition);
        Vector3 direction = worldPosition - transform.position;
        direction.z = 0f;

        newProjectile.right = direction;
    }
    public void FinishRangeAttack()
    {

    }
}
