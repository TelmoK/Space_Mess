using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ProyectileMovement : MonoBehaviour
{
    #region parameters

    [SerializeField]
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

    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.gameObject.GetComponent<MonsterMain>() == null) return;

        Destroy(gameObject);
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
