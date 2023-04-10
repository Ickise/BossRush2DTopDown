using UnityEngine;

public class Projectiles : MonoBehaviour
{
    [Header("Set up")]
    [SerializeField] int damage;
    
    [SerializeField] float speed;

    private void Start()
    {
        Destroy(gameObject, 2f);
    }

    void Update()
    {
        transform.Translate(speed * Time.deltaTime, 0f, 0f);
    }

    void OnTriggerEnter2D(Collider2D other)
    {
        if (other.CompareTag("Enemy"))
        {
            var target = other.GetComponent<Life>();
            target.Damage(damage);
        }
    }
}
