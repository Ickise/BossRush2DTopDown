using System.Collections;
using UnityEngine;
using UnityEngine.SceneManagement;

public class DeathMenu : MonoBehaviour
{
    [Header("Set up")]
    [SerializeField] Life playerLife;

    [SerializeField] GameObject deathPanel;

    [SerializeField] AudioClip deathAudio;

    [SerializeField] AudioSource audioSource;

    void Update()
    {
        if (playerLife.currentHealth <= 0)
        {
            deathPanel.SetActive(true);
            audioSource.Stop();
            // AudioManager._instance.PlaySFX(deathAudio); je voulais le mettre mais le son est horrible
            StartCoroutine(GoToMenu());
        }
    }

    IEnumerator GoToMenu()
    {
        yield return new WaitForSeconds(5f);
        SceneManager.LoadScene("Menu");
    }
}
