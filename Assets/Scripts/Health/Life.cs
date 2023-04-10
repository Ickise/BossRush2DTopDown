using UnityEngine;

public class Life : MonoBehaviour
{
    [Header("Set up")]
    public int maxHealth = 100;
    public int currentHealth;

    private void Start()
    {
        currentHealth = maxHealth;
    }

    public void Damage(int damageAmount)
    {
        currentHealth -= damageAmount;
        if (currentHealth <= 0)
        {
            Destroy(gameObject);
        }
    }
}
