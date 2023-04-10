using UnityEngine;

public class BossMeleeAttack : MonoBehaviour
{
    [Header("Set up")]
    [SerializeField] Animator bossAnimator;

    [SerializeField] GameObject sword;

    [SerializeField] Rigidbody2D bossRigidBody2D;
    [SerializeField] Transform playerTransform;

    [SerializeField] float speed = 2f;
    [SerializeField] float attackRange = 1.5f;

    float distanceToPlayer;

    void FixedUpdate()
    {
        if (bossAnimator.GetInteger("State") == 2)
        {
            distanceToPlayer = Vector2.Distance(transform.position, playerTransform.position);

            if (distanceToPlayer > attackRange)
            {
                Vector2 direction = (playerTransform.position - transform.position).normalized;
                bossRigidBody2D.velocity = direction * speed;
                sword.SetActive(false);
            }
            else
            {
                sword.SetActive(true);
            }
        }
        else
        {
            sword.SetActive(false);
        }
    }
}
