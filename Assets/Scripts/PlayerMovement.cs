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

    private Vector3 speed;

    #endregion

    #region methods

    public void Boost(Vector3 movementDirection)
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
            speed += movementDirection.normalized * boostSpeed * 2;
        }
    }
    public void AddSpeed(Vector3 _speed)
    {
        speed += _speed;
    }

    public void SetSpeed(Vector3 _speed)
    {
        speed = _speed;
    }
    public void ScaleSpeed(float scale)
    {
        speed = speed.normalized * scale;
    }

    #endregion

    void Start()
    {
        playerBody = GetComponent<Rigidbody2D>();
    }

    void Update()
    {
        speed = new Vector3(speed.x, speed.y, 0);// set the z to 0 to avoid problems

        if (speed.magnitude > maxSpeed) speed = speed.normalized * maxSpeed;

        if(playerBody != null) playerBody.velocity = speed;Debug.Log("Speed Module: " + playerBody.velocity.magnitude);
    }
}
