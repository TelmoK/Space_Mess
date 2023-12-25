using System.Collections;
using System.Collections.Generic;
using UnityEditor.Animations;
using UnityEditorInternal;
using UnityEngine;

public class BombMonsterMain : MonoBehaviour
{
    #region parameters

    [SerializeField]
    private float targetReachRadius = 7;
    
    #endregion

    #region references

    private Transform _myTransform;

    private TargetTracker movement;

    private PlayerMain playerRef;

    private Rigidbody2D body;

    private Animator animationController;

    #endregion

    #region properties

    private bool targetReached = false;

    private bool playerDetected = false;

    #endregion

    #region methods
    
    private void Explode()
    {
        movement.enabled = false;

        body.velocity = Vector2.zero;

        animationController.SetInteger("AnimState", 1);
    }

    public void GetDestroyed()
    {
        Destroy(gameObject);
    }
    
    #endregion

    void Start()
    {
        _myTransform = transform;

        movement = GetComponent<TargetTracker>();

        playerRef = FindAnyObjectByType<PlayerMain>();

        body = GetComponent<Rigidbody2D>();

        animationController = GetComponent<Animator>();
    }

    void Update()
    {
        if(playerDetected == false)
        {
            RaycastHit2D rayToPlayer = Physics2D.Raycast(_myTransform.position, playerRef.transform.position - _myTransform.position);
            playerDetected = rayToPlayer.collider.gameObject.GetComponent<PlayerMain>() != null;
        }

        if (playerDetected) // Set player as target
        {
            movement.targetTimeTransform = playerRef.GetComponent<TimeTrackedTransform>();
        }

        if ((playerRef.transform.position - _myTransform.position).magnitude <= targetReachRadius && !targetReached)
        {
            targetReached = true;
            Explode();
        }
    }
}
