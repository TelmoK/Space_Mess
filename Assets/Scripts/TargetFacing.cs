using System;
using System.Collections;
using System.Collections.Generic;
using System.Threading;
using TMPro;
using UnityEngine;

public class TargetFacing : MonoBehaviour
{
    #region parameters

    [SerializeField]
    private float fowollSpeed = 5;
    
    #endregion

    #region references

    private Transform _myTransform;

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
        _myTransform = transform;
    }

    
    void Update()
    {
        Vector2 direction = targetPosition - (Vector2)_myTransform.position;

        float angle = Mathf.Atan2(direction.y, direction.x) * Mathf.Rad2Deg;

        Quaternion rotation = Quaternion.AngleAxis(angle, Vector3.forward);

        _myTransform.rotation = Quaternion.Slerp(_myTransform.rotation, rotation, fowollSpeed * Time.deltaTime);
    }
}
