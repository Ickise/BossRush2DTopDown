using UnityEngine.UI;
using UnityEngine;

public class HealthBar : MonoBehaviour
{
    [Header("Set up")]
    [SerializeField] Image healthBar;

    [SerializeField] Life gameObjectLife;

    float lerpSpeed;

    private void Update()
    {
        lerpSpeed = 3f * Time.deltaTime;

        HealthBarFiller();
        ColorChanger();
    }

    void HealthBarFiller()
    {
        healthBar.fillAmount = Mathf.Lerp(healthBar.fillAmount, (float)gameObjectLife.currentHealth / (float)gameObjectLife.maxHealth, lerpSpeed);
    }

    void ColorChanger()
    {
        Color healthColor= Color.Lerp(Color.red, Color.green, ((float)gameObjectLife.currentHealth / (float)gameObjectLife.maxHealth));

        healthBar.color = healthColor;
    }
}
