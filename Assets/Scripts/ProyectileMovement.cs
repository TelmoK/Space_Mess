using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ProyectileMovement : MonoBehaviour
{
    #region parameters

    private float proyectileSpeed = 30f;

    #endregion

    #region references

    Rigidbody2D body;

    #endregion

    #region properties

    Vector2 movementDirection;

    #endregion

    #region methods

    public void SetupDirection(Vector2 direction)
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
        body.velocity = movementDirection * proyectileSpeed;
    }
}
