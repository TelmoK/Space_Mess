using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BlackHoleMonstaerMain : MonoBehaviour
{
    #region parameters

    [SerializeField]
    private float attractionRadius = 4;

    #endregion

    #region references

    private Transform _myTransform;

    private TargetFollower movement;

    private PlayerMain playerRef;

    #endregion

    void Start()
    {
        _myTransform = transform;

        playerRef = FindAnyObjectByType<PlayerMain>();

        movement = GetComponent<TargetFollower>();
        movement.TargetTransform = playerRef.transform;
    }

    void Update()
    {
        Vector2 distanceToPlayer = playerRef.transform.position - _myTransform.position;

        if(distanceToPlayer.magnitude <= attractionRadius)
        {
            playerRef.playerMovement.AddSpeed(-distanceToPlayer.normalized * 30);
        }
    }
}
