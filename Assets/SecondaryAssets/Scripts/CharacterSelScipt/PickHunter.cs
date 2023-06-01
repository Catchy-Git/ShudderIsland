using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PickHunter : MonoBehaviour
{
    public PlayerSelect playerSelect;

    void OnMouseDown()
    {
        playerSelect.Hunter();

    }
}
