using UnityEngine;

public class BossSounds : MonoBehaviour
{
    [Header("Set up")]
    [SerializeField] AudioClip startMeleeAttackAudio;
    [SerializeField] AudioClip endOfWaitingAudio;

    public void StartMeleeAttackAudio()
    {
        AudioManager._instance.PlaySFX(startMeleeAttackAudio);
    }
    public void EndOfWaitingAudio()
    {
        AudioManager._instance.PlaySFX(endOfWaitingAudio);
    }
}
