using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PickHooded : MonoBehaviour
{
    public PlayerSelect playerSelect;

    void OnMouseDown()
    {
        playerSelect.Hooded();
        Debug.Log("Hooded");
    }
}
