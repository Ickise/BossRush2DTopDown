using UnityEngine;
using UnityEngine.InputSystem;

public class SwitchWeapon : MonoBehaviour
{
    [Header("Set up")]
    [SerializeField] int currentWeaponIndex;

    [SerializeField] GameObject[] guns;
    [SerializeField] GameObject weaponHolder;
    [SerializeField] GameObject currentGun;

    int totalWeapons = 1;

    void Start()
    {
        totalWeapons = weaponHolder.transform.childCount;
        guns = new GameObject[totalWeapons];

        for (int i = 0; i < totalWeapons; i++)
        {
            guns[i] = weaponHolder.transform.GetChild(i).gameObject;
            guns[i].SetActive(false);
        }

        guns[0].SetActive(true);
        currentGun = guns[0];
        currentWeaponIndex = 0;
    }

    public void SwitchWeapons(InputAction.CallbackContext callback)
    {
        if(!callback.performed)
            return;
            
        if (callback.ReadValue<Vector2>().y < 0f)
        {
            if (currentWeaponIndex < totalWeapons - 1)
            {
                guns[currentWeaponIndex].SetActive(false);
                currentWeaponIndex ++;
                guns[currentWeaponIndex].SetActive(true);
                currentGun = guns[currentWeaponIndex];
            }
        }
        else if (callback.ReadValue<Vector2>().y > 0f)
        {
            if (currentWeaponIndex > 0)
            {
                guns[currentWeaponIndex].SetActive(false);
                currentWeaponIndex --;
                guns[currentWeaponIndex].SetActive(true);
                currentGun = guns[currentWeaponIndex];
            }
        }
    }
}
