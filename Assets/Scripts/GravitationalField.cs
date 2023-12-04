using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GravitationalField : MonoBehaviour
{
    #region parameters

    [SerializeField]
    private float gravityFieldRadius = 2.6f;

    [SerializeField]
    private float mcuOrbitalEntranceAngleMargin = 5;

    [SerializeField]
    public float gravityIncreaseIndex = 0.002f;

    [SerializeField]
    private float initialLinearSpeed = -1;

    #endregion

    #region references

    private Transform _myTransfrom;

    private CircleCollider2D gravityFieldArea;

    #endregion

    #region properties

    private float gravityIncreaseCount = 0.002f;

    private bool playerHasAlreadyOrbited = false;

    #endregion

    #region methods

    private void OnTriggerStay2D(Collider2D collision)
    {
        PlayerMain player = collision.gameObject.GetComponent<PlayerMain>();

        if (player == null) return;

        Vector2 distanceVec = player.body.transform.position - _myTransfrom.position;

        // Enters in orbit when movement is more or less tangent
        float angleOfDistanceAndMovement = (float)Math.Acos(Math.Abs(Vector2.Dot(player.body.velocity.normalized, distanceVec.normalized))) / (float)Math.PI * 180;
        
        if (90 - angleOfDistanceAndMovement <= mcuOrbitalEntranceAngleMargin && playerHasAlreadyOrbited == false)
        {
            player.SetIsInOrbit(true);
            playerHasAlreadyOrbited = true;
        }

        if (player.IsInOrbit())
        {
            if(initialLinearSpeed == -1) initialLinearSpeed = player.body.velocity.magnitude;
            player.playerMovement.ScaleSpeed(initialLinearSpeed);

            Vector2 g_u = -distanceVec.normalized; // Unitary gravity vector

            float scalar = (-player.body.velocity.x * g_u.x - player.body.velocity.y * g_u.y) / (float)(Math.Pow(g_u.x, 2) + Math.Pow(g_u.y, 2));
            scalar += gravityIncreaseCount;
            
            player.playerMovement.AddSpeed(g_u * scalar); // Tries to keep speed tangent to g_u
            
            gravityIncreaseCount += gravityIncreaseIndex;
        }
        
    }

    private void OnTriggerExit2D(Collider2D collision)
    {
        if (collision.gameObject.GetComponent<PlayerMain>() == null) return;

        gravityIncreaseCount = 0.002f;
        initialLinearSpeed = -1;

        playerHasAlreadyOrbited = false;
    }

    #endregion

    void Start()
    {
        _myTransfrom = transform;

        gravityFieldArea = GetComponent<CircleCollider2D>();
    }

    void Update()
    {
        gravityFieldArea.radius = gravityFieldRadius;
    }
}
