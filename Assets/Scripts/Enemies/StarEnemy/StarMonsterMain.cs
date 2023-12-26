using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class StarMonsterMain : MonoBehaviour
{
    #region parameters

    [SerializeField]
    private int numberOfShootedProyectiles = 7;

    [SerializeField]
    private float shootFrecuencePerSecond = 2;

    [SerializeField]
    private float maxShootDistance = 10;

    #endregion

    #region refereneces

    private Transform _myTransform;

    private Rigidbody2D body;

    private ShootingComponent shooter;

    private TargetFollower movement;

    private Timer shootingTimer;

    private PlayerMain playerRef;

    private Animator animator;

    #endregion

    #region properties

    private float firstShootAngle = 0;

    #endregion

    #region methods

    public void Shoot()
    {
        firstShootAngle = GetAngleToPlayer();

        float anglePiece = 360 / numberOfShootedProyectiles;

        for (int i = 0; i < numberOfShootedProyectiles; i++)
        {
            float x = (float)Math.Cos(anglePiece * i + firstShootAngle);
            float y = (float)Math.Sin(anglePiece * i + firstShootAngle);

            Vector2 direction = new Vector2(x, y);

            shooter.Shoot(direction);
        }
    }

    private float GetAngleToPlayer()
    {
        Vector2 dirVecToPlayer = ((Vector2)playerRef.transform.position - (Vector2)_myTransform.position).normalized;
        
        float angle = (float)Math.Abs(Math.Acos(Vector2.Dot(Vector2.right, dirVecToPlayer)));

        if (playerRef.transform.position.y < _myTransform.position.y) angle *= -1;

        return angle;
    }
    
    #endregion

    void Start()
    {
        _myTransform = transform;

        body = GetComponent<Rigidbody2D>();

        shooter = GetComponent<ShootingComponent>();

        playerRef = FindAnyObjectByType<PlayerMain>();

        movement = GetComponent<TargetFollower>();
        movement.targetTransform = playerRef.transform;

        shootingTimer = GetComponent<Timer>();
        shootingTimer.SetTime(1 / shootFrecuencePerSecond);
    }

    void Update()
    {
        Vector2 vectorToPlayer = playerRef.transform.position - _myTransform.position;

        RaycastHit2D playerRay = Physics2D.Raycast(_myTransform.position, vectorToPlayer);

        bool playerInFront = playerRay.collider != null && playerRay.collider.gameObject.GetComponent<PlayerMain>() != null;
        
        //Shooting
        shootingTimer.SetRestart(playerInFront);

        if (shootingTimer.IsTimerRunning() == false && playerInFront) shootingTimer.TimerStart();

        //Movement
        movement.enabled = playerInFront && vectorToPlayer.magnitude > maxShootDistance;
        if (!movement.enabled) body.velocity = Vector2.zero;
    }
}
