using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MonsterMovement : MonoBehaviour
{
    #region parameters

    [SerializeField]
    private float maxSpeed = 6;

    [SerializeField]
    private float minSpeed = 3;
    Transform playerT;
    Rigidbody2D body;
    #endregion

    void Start()
    {
        playerT = FindObjectOfType<PlayerMain>().gameObject.transform;
        body = GetComponent<Rigidbody2D>();
    }

    void Update()
    {
        Vector2 distToPlayer = playerT.position - transform.position;
        
        if(distToPlayer.magnitude < 25)
        {
            Vector2 movement = distToPlayer;
            if (movement.magnitude > maxSpeed) movement = movement.normalized * maxSpeed;
            if (movement.magnitude < minSpeed) movement = movement.normalized * minSpeed;

            if(distToPlayer.magnitude > 1.5f)
                body.velocity = movement;
        }
        
    }
}
