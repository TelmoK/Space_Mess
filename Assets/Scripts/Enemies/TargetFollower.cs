using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TargetFollower : MonoBehaviour
{
    #region parameters

    [SerializeField]
    private float maxSpeed = 6;

    [SerializeField]
    private float minSpeed = 3;

    #endregion

    #region references

    [SerializeField]
    public Transform targetTransform;

    private Rigidbody2D body;

    #endregion

    #region properties
    
    public Transform TargetTransform
    {
        get { return targetTransform; }
        set { targetTransform = value; }
    }
    
    #endregion

    void Start()
    {
        body = GetComponent<Rigidbody2D>();
    }

    void Update()
    {
        if(targetTransform != null)
        {
            Vector2 distToTarget = targetTransform.position - transform.position;

            Vector2 movement = distToTarget;
            if (movement.magnitude > maxSpeed) movement = movement.normalized * maxSpeed;
            if (movement.magnitude < minSpeed) movement = movement.normalized * minSpeed;

            if (distToTarget.magnitude > 0.01f) body.velocity = movement;
            else body.velocity = Vector2.zero;
        }
        else
        {
            body.velocity = Vector2.zero;    
        }
    }
}
