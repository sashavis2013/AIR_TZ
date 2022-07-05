using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using DG.Tweening;

public class Movement : MonoBehaviour
{
    private bool _doneRoaming=true;
    /// <summary>
    /// Lets objects move within specified radius
    /// </summary>
    /// <param name="movespeed">Movement speed of object</param>
    /// <param name="startPos">Point of radius start</param>
    /// <param name="roamRaduis">Radius of available points to move on</param>
    public void FreeRoam(float movespeed, Vector2 startPos, float roamRaduis)
    {
        if (_doneRoaming)
        {
            _doneRoaming = false;
            Vector2 randomDirection = Random.insideUnitSphere * roamRaduis;
            randomDirection += startPos;

            transform.DOMove(randomDirection, movespeed).SetSpeedBased().SetEase(Ease.Linear).OnComplete(ToggleRoamingStatus);
        }
    }

    private void ToggleRoamingStatus()
    {
        _doneRoaming = !_doneRoaming;
    }
}
