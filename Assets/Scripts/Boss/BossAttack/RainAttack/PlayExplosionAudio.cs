using UnityEngine;

public class PlayExplosionAudio : MonoBehaviour
{
    [SerializeField] AudioClip explosionAudio;

    public void ExplosionAudio()
    {
        AudioManager._instance.PlaySFX(explosionAudio);
    }
}
