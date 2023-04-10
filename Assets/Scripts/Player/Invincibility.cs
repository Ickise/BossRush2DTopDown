using System.Collections;
using UnityEngine;

public class Invincibility : MonoBehaviour
{
    [Header("Set up")]
    [SerializeField] float invincibilityTime = 1f;
    [SerializeField] float blinkTime = 0.2f;

    [SerializeField] SpriteRenderer playerSprite;

    [SerializeField] GameObject weaponParent;
    SpriteRenderer weapon;

    Collider2D playerCollider2D;

    public static Invincibility invincibility;

    void Start()
    {
        invincibility = this;

        playerCollider2D = GetComponent<Collider2D>();
    }

    public void PlayerInvincibility()
    {
        StartCoroutine(Fade());
    }
    IEnumerator Fade()
    {
        playerCollider2D.enabled = false;

        weapon = weaponParent.GetComponentInChildren<SpriteRenderer>();

        for (float i = 0; i < invincibilityTime; i += blinkTime)
        {
            playerSprite.enabled = !playerSprite.enabled;
            weapon.enabled = !weapon.enabled;
            yield return new WaitForSeconds(blinkTime);
        }
        
        weapon.enabled = true;
        playerSprite.enabled = true;
        playerCollider2D.enabled = true;
    }
}
