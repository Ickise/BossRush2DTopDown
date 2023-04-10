using UnityEngine;

public class WeaponRotation : MonoBehaviour
{
    [SerializeField] Vector2 weaponPositionXPositif;
    [SerializeField] Vector2 weaponPositionXNegatif;

    [SerializeField] Quaternion weaponRotationXPositif;
    [SerializeField] Quaternion weaponRotationXNegatif;

    void Update()
    {
        SetWeaponRotation();
    }

    public void SetWeaponRotation()
    {
        if (PlayerMovement.player.direction.x > 0f)
        {
            gameObject.transform.localPosition = weaponPositionXPositif;
            gameObject.transform.localRotation = weaponRotationXPositif;
        }
        else if (PlayerMovement.player.direction.x < 0f)
        {
            gameObject.transform.localPosition = weaponPositionXNegatif;
            gameObject.transform.localRotation = weaponRotationXNegatif;
        }
    }
}
