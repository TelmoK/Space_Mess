using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EyeKrakenMain : MonoBehaviour
{
    #region references

    private Transform _myTransform;

    private TargetFacing pointFacer;

    private Rigidbody2D body;
    
    #endregion

    void Start()
    {
        _myTransform = transform;

        pointFacer = GetComponent<TargetFacing>();

        body = GetComponent<Rigidbody2D>();
    }

    void Update()
    {
        pointFacer.SetTargetPosition((Vector2)_myTransform.position + body.velocity);
    }
}
