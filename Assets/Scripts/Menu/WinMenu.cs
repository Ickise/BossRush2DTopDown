using System.Collections;
using UnityEngine;
using UnityEngine.SceneManagement;

public class WinMenu : MonoBehaviour
{
    [Header("Set up")]
    [SerializeField] Life bossLife;

    [SerializeField] GameObject winPanel;

    [SerializeField] AudioClip winAudio;

    [SerializeField] AudioSource audioSource;

    void Update()
    {
        if (bossLife.currentHealth <= 0)
        {
            winPanel.SetActive(true);
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
