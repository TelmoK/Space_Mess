using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ProyectileMovement : MonoBehaviour
{
    #region parameters

    private float proyectileSpeed = 30;

    #endregion

    #region references

    Rigidbody2D body;

    #endregion

    #region properties

    Vector3 movementDirection;

    #endregion

    #region methods

    public void SetupDirection(Vector3 direction)
    {
        movementDirection = direction.normalized;
    }

    #endregion

    void Start()
    {
        body = GetComponent<Rigidbody2D>();
    }

    void Update()
    {
        body.velocity = movementDirection * proyectileSpeed;Debug.Log("Bullet Speed: " + body.velocity.magnitude);
    }
}
