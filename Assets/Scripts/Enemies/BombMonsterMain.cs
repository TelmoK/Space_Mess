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

    private Transform _myTranform;

    private TargetTracker movement;

    private PlayerMain playerRef;

    private Rigidbody2D body;

    private Animator animationController;

    #endregion

    #region properties

    private bool targetReached = false;

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
        _myTranform = transform;

        movement = GetComponent<TargetTracker>();

        playerRef = FindAnyObjectByType<PlayerMain>();

        body = GetComponent<Rigidbody2D>();

        animationController = GetComponent<Animator>();
    }

    void Update()
    {
        if((playerRef.transform.position - _myTranform.position).magnitude <= targetReachRadius && !targetReached)
        {
            targetReached = true;
            Explode();
        } 
    }
}
