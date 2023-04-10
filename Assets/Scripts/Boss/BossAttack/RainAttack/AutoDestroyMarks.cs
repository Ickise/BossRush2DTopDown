using System.Collections;
using UnityEngine;

public class AutoDestroyMarks : MonoBehaviour
{
    [SerializeField] GameObject explosion;

    void Start()
    {
        StartCoroutine(SpawnExplosion());
        Destroy(gameObject, 1.2f);
    }

    IEnumerator SpawnExplosion()
    {
        yield return new WaitForSeconds(1f);
        GameObject _obj = Instantiate(explosion, transform.position, Quaternion.identity);
    }
}
