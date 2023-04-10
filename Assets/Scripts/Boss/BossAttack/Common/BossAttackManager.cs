using UnityEngine;
using DG.Tweening;

public class BossAttackManager : MonoBehaviour
{
    [Header("Set up")]
    [SerializeField] Animator bossAnimator;

    [SerializeField] int numberOfAttack;

    [SerializeField, Range(0.5f, 5f)] float speed;

    [SerializeField] Transform waitingPoint;

    [SerializeField] Ease ease;

    int randomIntForAttack;

    Rigidbody2D bossRigidbody2D;

    void Start()
    {
        bossAnimator.SetInteger("State", 2);

        bossRigidbody2D = GetComponent<Rigidbody2D>();
    }

    public void StartWaitingAttack()
    {
        bossAnimator.SetInteger("State", 0);

        bossRigidbody2D.velocity = Vector2.zero;

        transform.DOLocalMove(waitingPoint.position, speed)
              .SetSpeedBased()
              .SetEase(ease);
    }

    public void GetRandomInt()
    {
        randomIntForAttack = Random.Range(1, numberOfAttack);

        bossAnimator.SetInteger("State", randomIntForAttack);
    }
}