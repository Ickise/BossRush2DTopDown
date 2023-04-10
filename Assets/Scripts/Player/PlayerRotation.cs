using UnityEngine;

public class PlayerRotation : MonoBehaviour
{
    SpriteRenderer weaponSpriteRenderer;

    public Vector3 playerScale;

    [Header("Setup")]
    [SerializeField] Sprite frontSprite;
    [SerializeField] Sprite backSprite;

    [SerializeField] SpriteRenderer playerSpriteRenderer;

    [SerializeField] GameObject weaponSwitching;

    [SerializeField] Vector2 weaponPositionXPositif;
    [SerializeField] Vector2 weaponPositionXNegatif;

    [SerializeField] Quaternion weaponRotationXPositif;
    [SerializeField] Quaternion weaponRotationXNegatif;

    void Update()
    {
        RotateInDirectionOfInput();
    }

    void RotateInDirectionOfInput()
    {
        if (PlayerMovement.player.direction.x != 0f)
        {
            // weaponSpriteRenderer = weaponSwitching.GetComponentInChildren<SpriteRenderer>();

            // if (PlayerMovement.player.direction.x >= 0f)
            // {
            //     weaponSpriteRenderer.gameObject.transform.localPosition = weaponPositionXPositif;
            //     weaponSpriteRenderer.gameObject.transform.localRotation = weaponRotationXPositif;
            // }
            // else if (PlayerMovement.player.direction.x <= 0f)
            // {
            //     weaponSpriteRenderer.gameObject.transform.localPosition = weaponPositionXNegatif;
            //     weaponSpriteRenderer.gameObject.transform.localRotation = weaponRotationXNegatif;
            // }

            playerScale = playerSpriteRenderer.transform.localScale;
            playerScale.x = Mathf.Sign(PlayerMovement.player.direction.x);
            playerSpriteRenderer.transform.localScale = playerScale;
        }

        if (PlayerMovement.player.direction.y != 0f)
        {
            playerSpriteRenderer.sprite = PlayerMovement.player.direction.y > 0f ? backSprite : frontSprite;
        }
    }
}
