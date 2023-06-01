using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PickSharpShooter : MonoBehaviour
{
    public PlayerSelect playerSelect;

    void OnMouseDown()
    {
        playerSelect.SharpShooter();

    }
}
