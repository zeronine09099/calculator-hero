using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ButtonScript : MonoBehaviour
{
    public int number = 0;
    public GameManager manager;

    public void OnPlusButtonClicked()
    {
        number = 0;
        manager.ChangeWeaponManager(number);
    }

    public void OnMinusButtonClicked()
    {
        number = 1;  
        manager.ChangeWeaponManager(number);
    }
}
