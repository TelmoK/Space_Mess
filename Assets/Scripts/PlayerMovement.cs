using System;
using System.Collections;
using System.Collections.Generic;
using System.Runtime.CompilerServices;
using UnityEngine;

public class PlayerMovement : MonoBehaviour
{
    #region parameters

    [SerializeField]
    private float boostSpeed = 8;

    [SerializeField]
    private float maxSpeed = 20;

    #endregion

    #region references

    private Rigidbody2D playerBody;

    #endregion

    #region properties

    private Vector2 speed;

    #endregion

    #region methods

    public void Boost(Vector2 movementDirection)
    {
        float angleOfChange = (float)Math.Acos(Vector2.Dot(speed.normalized, movementDirection.normalized));
        
        if (angleOfChange <= 0.5)
        {
            speed += movementDirection.normalized * boostSpeed;
        }
        else if (angleOfChange > 0.5 && angleOfChange < Math.PI - 0.5)
        {
            speed = speed.normalized * speed.magnitude * 0.4f;
            speed += movementDirection.normalized * boostSpeed;
        }
        else
        {
            speed += movementDirection.normalized * boostSpeed * 1.5f;
        }
    }
    public void AddSpeed(Vector2 _speed)
    {
        speed += _speed;
    }

    public void ScaleSpeed(float scale)
    {
        speed = speed.normalized * scale; playerBody.velocity = speed;
    }

    #endregion

    void Start()
    {
        playerBody = GetComponent<Rigidbody2D>();
    }

    void Update()
    {
        if (speed.magnitude > maxSpeed) speed = speed.normalized * maxSpeed;

        if (playerBody != null) playerBody.velocity = speed;
    }
}
