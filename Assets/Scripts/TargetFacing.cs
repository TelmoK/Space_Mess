using System;
using System.Collections;
using System.Collections.Generic;
using System.Threading;
using TMPro;
using UnityEngine;

public class TargetFacing : MonoBehaviour
{
    #region references

    private Transform _myTransfrom;

    private Vector2 targetPosition = Vector2.right;

    #endregion

    #region methods
    
    public void SetTargetPosition(Vector2 newTargetPosition)
    {
        targetPosition = newTargetPosition;
    }
    
    #endregion

    void Start()
    {
        _myTransfrom = transform;
    }

    
    void Update()
    {
        Quaternion rotation = Quaternion.LookRotation(targetPosition - (Vector2)transform.position, _myTransfrom.TransformDirection(Vector3.up));

        Quaternion targetRotation = new Quaternion(0, 0, rotation.z, rotation.w);

        _myTransfrom.rotation = Quaternion.Slerp(_myTransfrom.rotation, targetRotation, 0.1f);
        

    }
}
