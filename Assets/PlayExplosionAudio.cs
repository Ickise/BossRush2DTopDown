using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayExplosionAudio : MonoBehaviour
{
    [SerializeField] AudioClip explosionAudio;

    public void ExplosionAudio()
    {
        AudioManager._instance.PlaySFX(explosionAudio);
    }
}
