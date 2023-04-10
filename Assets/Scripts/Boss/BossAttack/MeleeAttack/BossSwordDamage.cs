using UnityEngine;
using Cinemachine;

public class BossSwordDamage : MonoBehaviour
{
    [Header("Set up")]
    [SerializeField] AudioClip hitClip;

    [SerializeField] int damage = 5;

    [SerializeField] float force = 2f;

    CinemachineImpulseSource cinemachineImpulseSource;

    void Start()
    {
        cinemachineImpulseSource = FindObjectOfType<CinemachineImpulseSource>();
    }

    void OnTriggerEnter2D(Collider2D other)
    {
        if (other.CompareTag("Player"))
        {
            var player = other.GetComponent<Life>();
            player.Damage(damage);
            AudioManager._instance.PlaySFX(hitClip);
            cinemachineImpulseSource.GenerateImpulseWithForce(force);
            Invincibility.invincibility.PlayerInvincibility();
        }
    }
}
