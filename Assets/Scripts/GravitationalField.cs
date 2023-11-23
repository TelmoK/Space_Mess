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
        PlayerMain player = collision.gameObject.GetComponent<PlayerMain>();

        if (player == null) return;
        
        Vector2 distanceVec = player.body.transform.position - _myTransfrom.position;
            
        // Enters in orbit when movement is more or less tangent
        if (Math.Abs(Vector2.Dot(player.body.velocity, distanceVec)) <= orbitalEntranceErrorMargin)
        {
            isInOrbit = true;
        }

        if (player.IsBoosting())
        {
            gravityIncreaseCount = 0;
            isInOrbit = false;
        }

        if (isInOrbit && !player.IsBoosting())
        {
            if (gravityIncreaseCount == 0 && initialLinearSpeed > 0) player.playerMovement.ScaleSpeed(initialLinearSpeed);
                
            Vector2 g_u = -distanceVec.normalized; // Unitary gravity vector

            float scalar = (-player.body.velocity.x * g_u.x - player.body.velocity.y * g_u.y) / (float)(Math.Pow(g_u.x, 2) + Math.Pow(g_u.y, 2));
            scalar += gravityIncreaseCount;

            player.playerMovement.AddSpeed(g_u * scalar); // Keeps speed tangent to g_u
            
            gravityIncreaseCount += gravityIncreaseIndex;
        }
        
    }

    private void OnTriggerExit2D(Collider2D collision)
    {
        if (collision.gameObject.GetComponent<PlayerMain>() != null) return;
        
        gravityIncreaseCount = 0;
        isInOrbit = false;
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
