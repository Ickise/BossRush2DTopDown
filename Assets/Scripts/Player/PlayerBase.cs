using UnityEngine;
using UnityEngine.InputSystem;

public class PlayerBase : MonoBehaviour
{
    [SerializeField] protected Rigidbody2D playerRigidbody2D;

    [SerializeField] protected Collider2D playerCollider2D;
    
    protected virtual void Start()
    {
        if(playerRigidbody2D == null) playerRigidbody2D = GetComponent<Rigidbody2D>();

        if(playerCollider2D == null) playerCollider2D = GetComponent<Collider2D>();
    }
}
