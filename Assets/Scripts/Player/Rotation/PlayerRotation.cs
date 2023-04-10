using UnityEngine;

public class PlayerRotation : PlayerBase
{

    [Header("Set up")]
    [SerializeField] Sprite frontSprite;
    [SerializeField] Sprite backSprite;

    [SerializeField] SpriteRenderer playerSpriteRenderer;

    [SerializeField] PlayerMovement playerMovement;

    public Vector3 playerScale;

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
