using UnityEngine;

public class WeaponRotation : PlayerBase
{
    [SerializeField] Vector2 weaponPositionXPositif;
    [SerializeField] Vector2 weaponPositionXNegatif;

    [SerializeField] Quaternion weaponRotationXPositif;
    [SerializeField] Quaternion weaponRotationXNegatif;

    [SerializeField] PlayerMovement playerMovement;

    void Update()
    {
        SetWeaponRotation();
    }

    public void SetWeaponRotation()
    {
        if (playerMovement.direction.x > 0f)
        {
            gameObject.transform.localPosition = weaponPositionXPositif;
            gameObject.transform.localRotation = weaponRotationXPositif;
        }
        else if (playerMovement.direction.x < 0f)
        {
            gameObject.transform.localPosition = weaponPositionXNegatif;
            gameObject.transform.localRotation = weaponRotationXNegatif;
        }
    }
}
