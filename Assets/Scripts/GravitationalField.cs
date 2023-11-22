using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GravitationalField : MonoBehaviour
{
    #region parameters

    [SerializeField]
    private float orbitalEntranceErrorMargin = 0.8f;

    [SerializeField]
    public float gravityIncreaseIndex = 0.001f;

    [SerializeField]
    private float initialLinearSpeed = -1;

    #endregion

    #region references

    private Transform _myTransfrom;

    #endregion

    #region properties

    private bool isInOrbit = false;

    private float gravityIncreaseCount = 0;

    #endregion

    #region methods

    private void OnTriggerStay2D(Collider2D collision)
    {
        if(collision.gameObject.GetComponent<PlayerMain>() != null)
        {
            Rigidbody2D body = collision.gameObject.GetComponent<Rigidbody2D>();
            PlayerMovement bodyMovement = collision.gameObject.GetComponent<PlayerMovement>();

            Vector3 distanceVec = body.transform.position - _myTransfrom.position;
            float dot = Vector3.Dot(body.velocity, distanceVec);
            
            // Enters in orbit when movement is more or less tangent
            if (Math.Abs(dot) <= orbitalEntranceErrorMargin)
                isInOrbit = true;

            if (isInOrbit)
            {
                if (gravityIncreaseCount == 0 && initialLinearSpeed > 0) bodyMovement.ScaleSpeed(initialLinearSpeed);
                
                Vector2 g_u = -distanceVec.normalized; // Unitary gravity vector

                float scalar = (-body.velocity.x * g_u.x - body.velocity.y * g_u.y) / (float)(Math.Pow(g_u.x, 2) + Math.Pow(g_u.y, 2));
                scalar += gravityIncreaseCount;

                bodyMovement.AddSpeed(g_u * scalar); // Keeps speed tangent to g_u
                
                gravityIncreaseCount += gravityIncreaseIndex;
            }
        }
    }

    private void OnTriggerExit2D(Collider2D collision)
    {
        if(collision.gameObject.GetComponent<PlayerMain>() != null)
        {
            gravityIncreaseCount = 0;
            isInOrbit = false;
        }
    }

    #endregion

    void Start()
    {
        _myTransfrom = transform;
    }

    void Update()
    {
        
    }
}
