using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GravitationalEnergyLoader : MonoBehaviour
{
    #region parameters

    //private int

    #endregion

    #region references

    private GravitationalField gravityField;
    
    #endregion

    #region methods

    
    #endregion

    void Start()
    {
        gravityField = GetComponent<GravitationalField>();
    }

    void Update()
    {
        if(gravityField.orbitalEntranceDistanceVector != Vector2.zero)
        {
            Vector2 beginDistDir = gravityField.orbitalEntranceDistanceVector.normalized;
            Vector2 currentDistDir = gravityField.distanceVector.normalized;

            float angleOfCurrentAndBeginDistVec = (float)Math.Acos(Math.Abs(Vector2.Dot(beginDistDir, currentDistDir))) / (float)Math.PI * 180;

            if(angleOfCurrentAndBeginDistVec <= 5)
            {
                gravityField.playerContained.AddEnergyUnits(1);
             //   Debug.Log("YEAR");
            }
        }
    }
}
