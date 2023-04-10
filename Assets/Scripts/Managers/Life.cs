using UnityEngine;

public class Life : MonoBehaviour
{
    [Header("Set up")]
    [SerializeField] int maxHealth = 100;
    [SerializeField] int currentHealth;

    // public static Life life;

    private void Start()
    {
        currentHealth = maxHealth;

        // life = this;
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
