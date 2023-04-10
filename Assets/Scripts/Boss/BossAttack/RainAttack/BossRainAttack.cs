using UnityEngine;

public class BossRainAttack : MonoBehaviour
{
    [Header("Set up")]
    [SerializeField] Animator bossAnimator;

    [SerializeField] GameObject visualMark;

    [SerializeField] int numberOfAttackZones = 3;

    [SerializeField] float minDistance = 1.0f;
    [SerializeField] float maxDistance = 4.0f;

    void Update()
    {
        var bossMovement = GetComponent<BossMovement>();
    }

    public void StartRainAttack()
    {
        for (int i = 0; i < numberOfAttackZones; i++)
        {
            float distance = Random.Range(minDistance, maxDistance);
            Vector3 position = transform.position * distance; 
            
            Instantiate(visualMark, position, Quaternion.identity);
        }
    }
}
