using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EyeKrakenMain : MonoBehaviour
{
    #region references

    private Transform _myTransform;

    private Rigidbody2D body;

    private Animator animator;

    private SpriteRenderer sprRenderer;

    private TargetTracker chaseMovement;

    private PlayerMain playerRef;

    private TargetFacing pointFacer;

    #endregion

    #region properties

    private bool playerDetected = false;

    #endregion

    #region methods

    private void ManageAttack()
    {
        Vector2 distanceToPlayer = playerRef.transform.position - _myTransform.position;
        RaycastHit2D attackRangeRay = Physics2D.Raycast(_myTransform.position, body.velocity, 3.5f);

        if (attackRangeRay.collider != null && attackRangeRay.collider.gameObject.GetComponent<PlayerMain>() != null)
        {
            animator.SetInteger("AnimState", 1);
        }
        else
        {
            animator.SetInteger("AnimState", 0);
        }
    }

    private void ManageMovement()
    {
        if (playerDetected == false)
        {
            RaycastHit2D rayToPlayer = Physics2D.Raycast(_myTransform.position, playerRef.transform.position - _myTransform.position);
            playerDetected = rayToPlayer.collider.gameObject.GetComponent<PlayerMain>() != null;
        }
        
        if (playerDetected && sprRenderer.isVisible) // Set player as target
        {
            chaseMovement.targetTimeTransform = playerRef.GetComponent<TimeTrackedTransform>();
        }
    }
    
    #endregion

    void Start()
    {
        _myTransform = transform;

        playerRef = FindAnyObjectByType<PlayerMain>();

        pointFacer = GetComponent<TargetFacing>();

        body = GetComponent<Rigidbody2D>();

        animator = GetComponent<Animator>();

        sprRenderer = GetComponent<SpriteRenderer>();

        chaseMovement = GetComponent<TargetTracker>();
    }

    void Update()
    {
        pointFacer.SetTargetPosition((Vector2)_myTransform.position + body.velocity.normalized);

        ManageMovement();

        ManageAttack();
    }
}
