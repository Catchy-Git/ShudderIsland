using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PickHammer : MonoBehaviour
{
    public PlayerSelect playerSelect;

    void OnMouseDown()
    {
        playerSelect.Hammer();

    }
}
