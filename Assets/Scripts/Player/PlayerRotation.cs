using UnityEngine;

public class PlayerRotation : PlayerBase
{
    SpriteRenderer weaponSpriteRenderer;

    public Vector3 playerScale;

    [Header("Setup")]
    [SerializeField] Sprite frontSprite;
    [SerializeField] Sprite backSprite;

    [SerializeField] SpriteRenderer playerSpriteRenderer;

    [SerializeField] GameObject weaponSwitching;

    [SerializeField] PlayerMovement playerMovement;

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
        if (playerMovement.direction.x != 0f)
        {
            playerScale = playerSpriteRenderer.transform.localScale;
            playerScale.x = Mathf.Sign(playerMovement.direction.x);
            playerSpriteRenderer.transform.localScale = playerScale;
        }

        if (playerMovement.direction.y != 0f)
        {
            playerSpriteRenderer.sprite = playerMovement.direction.y > 0f ? backSprite : frontSprite;
        }
    }
}
