using System;
using System.Collections;
using System.Collections.Generic;
using Unity.VisualScripting;
using UnityEngine;

public class CameraSmoothFollow : MonoBehaviour
{
    #region parameters

    [SerializeField]
    private Transform targetTranform;

    [SerializeField]
    private float smoothnessFactor;

    #endregion

    #region properties
    
    public float SmoothnessFactor
    {
        get { return smoothnessFactor; }
        set { smoothnessFactor = value; }
    }

    private float defaultSmoothnessFactor;
    public float DefaultSmoothnessFactor
    {
        get { return smoothnessFactor; }
    }

    #endregion

    #region references

    private Transform _myTransform;

    #endregion

    #region properties

    Vector3 offset;

    private Vector3 velocity = Vector3.zero;

    #endregion

    void Start()
    {
        _myTransform = transform;

        defaultSmoothnessFactor = smoothnessFactor;

        offset = new Vector3(0, 0, _myTransform.position.z);
    }
    public bool R = true;
    void Update()
    {
        Vector3 targetPosition = targetTranform.position + offset;
        
        _myTransform.position = Vector3.SmoothDamp(_myTransform.position, targetPosition, ref velocity, smoothnessFactor);
    }
}
