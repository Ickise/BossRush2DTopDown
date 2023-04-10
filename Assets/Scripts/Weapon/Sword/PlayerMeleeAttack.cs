using UnityEngine;
using UnityEngine.InputSystem;

public class PlayerMeleeAttack : MonoBehaviour
{
    [Header("Set up")]
    [SerializeField] float timeBeforeAttack;
    [SerializeField] float maxTimeBeforeAttack = 1f;
    [SerializeField] float minTimeBeforeAttack = 0f;

    [SerializeField] PlayerRotation playerRotation;

    [SerializeField] Animator playerAnimator;

    [SerializeField] BoxCollider2D swordBoxCollider2D;

    [SerializeField] int damage;

    [SerializeField] AudioClip swordSlash;
    [SerializeField] AudioClip hitBoss;

    bool canMeleeAttack;

    void Start()
    {
        swordBoxCollider2D.enabled = false;
    }

    public void Attack(InputAction.CallbackContext callback)
    {
        canMeleeAttack = callback.performed;
    }

    void Update()
    {
        if (canMeleeAttack)
        {
            if (timeBeforeAttack == maxTimeBeforeAttack)
            {
                if (playerRotation.playerScale.x >= 0f) playerAnimator.SetBool("IsRightMeleeAttacking", true);

                if (playerRotation.playerScale.x < 0f) playerAnimator.SetBool("IsLeftMeleeAttacking", true);
            }
        }
        else
        {
            playerAnimator.SetBool("IsRightMeleeAttacking", false);
            playerAnimator.SetBool("IsLeftMeleeAttacking", false);
        }

        if (timeBeforeAttack >= minTimeBeforeAttack)
        {
            timeBeforeAttack += Time.deltaTime;
        }

        timeBeforeAttack = Mathf.Clamp(timeBeforeAttack, minTimeBeforeAttack, maxTimeBeforeAttack);
    }

    void OnTriggerEnter2D(Collider2D other)
    {
        if (other.CompareTag("Enemy"))
        {
            var target = other.GetComponent<Life>();
            target.Damage(damage);
            AudioManager._instance.PlaySFX(hitBoss);
        }
    }

    public void StartMeleeAttack()
    {
        AudioManager._instance.PlaySFX(swordSlash);
        swordBoxCollider2D.enabled = true;
        timeBeforeAttack = minTimeBeforeAttack;
    }
    public void FinishMeleeAttack()
    {
        swordBoxCollider2D.enabled = false;
    }
}
