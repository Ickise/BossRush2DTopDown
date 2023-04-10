using UnityEngine;
using Cinemachine;

public class RainAttack : MonoBehaviour
{
    [Header("Set up")]
    [SerializeField] int damage = 10;

    [SerializeField] float force;

    [SerializeField] AudioClip hitClip;

    CinemachineImpulseSource cinemachineImpulseSource;
    void Start()
    {
        cinemachineImpulseSource = FindObjectOfType<CinemachineImpulseSource>();
        Destroy(GetComponentInParent<Collider2D>().gameObject, 1.1f);
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
