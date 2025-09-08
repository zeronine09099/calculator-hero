using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ButtonScript : MonoBehaviour
{
    public int number = 0;
    public GameManager manager;

    public void OnPlusButtonClicked()
    {
        manager.ChangeWeaponManager(number);
    }
}
