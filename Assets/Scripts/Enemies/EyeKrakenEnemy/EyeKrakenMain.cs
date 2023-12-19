using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EyeKrakenMain : MonoBehaviour
{
    #region references

    private Transform _myTransform;

    private PlayerMain playerRef;

    private TargetFacing pointFacer;

    private Rigidbody2D body;

    private Animator animator;

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
    
    #endregion

    void Start()
    {
        _myTransform = transform;

        playerRef = FindAnyObjectByType<PlayerMain>();

        pointFacer = GetComponent<TargetFacing>();

        body = GetComponent<Rigidbody2D>();

        animator = GetComponent<Animator>();
    }

    void Update()
    {
        pointFacer.SetTargetPosition((Vector2)_myTransform.position + body.velocity);

        ManageAttack();
    }
}
