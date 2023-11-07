//このスクリプトがついたオブジェクトをHoloLens2の視線の位置に表示するスクリプト

using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Microsoft.MixedReality.Toolkit;
using Microsoft.MixedReality.Toolkit.Input;

public class EyePos : MonoBehaviour
{
    private float defaultDistanceInMeters = 3.0f;

    void Update()
    {
        var gazeProvider = CoreServices.InputSystem?.GazeProvider;
        if (gazeProvider != null)
        {
            MixedRealityRaycastHit hitInfo = gazeProvider.HitInfo;
            if (hitInfo.collider != null)
            {
                // If there is a hit, use the hit position
                gameObject.transform.position = hitInfo.point;
            }
            else
            {
                // If there is no hit, place the object 1 meter along the gaze direction
                gameObject.transform.position = gazeProvider.GazeOrigin + gazeProvider.GazeDirection.normalized * defaultDistanceInMeters;
            }
        }
    }
}


