using UnityEngine;
using DG.Tweening;

public class BossMovement : MonoBehaviour
{
    [Header("À set")]
    [SerializeField] Transform[] pointDestinations = new Transform[6];

    [SerializeField, Range(0.5f, 5f)] float speed;

    [SerializeField] Ease ease;

    [SerializeField] int actualTarget;

    int newPoint;

    Rigidbody2D bossRigidBody2D;

    void Start()
    {
        transform.position = pointDestinations[0].position;

        bossRigidBody2D = GetComponent<Rigidbody2D>();
    }

    public void Fly()
    {
        while (newPoint == actualTarget)
        {
            newPoint = Random.Range(0, pointDestinations.Length);
        }

        actualTarget = newPoint;

        transform.DOLocalMove(pointDestinations[newPoint].position, speed)
                    .SetSpeedBased()
                    .SetEase(ease)
                    .OnComplete(Fly);
    }
    public void SetFirstPoint()
    {
        newPoint = 0;
    }
    public void StopMove()
    {
        newPoint = -1;
    }
}