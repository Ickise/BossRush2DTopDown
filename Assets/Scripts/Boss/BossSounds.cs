using UnityEngine;

public class BossSounds : MonoBehaviour
{
    [Header("Set up")]
    [SerializeField] AudioClip startMeleeAttack;

    public void StartMeleeAttackAudio()
    {
        AudioManager._instance.PlaySFX(startMeleeAttack);
    }
}
