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
    private float firstShootAngle = 0;

    [SerializeField]
    private float shootFrecuencePerSecond = 2;

    #endregion

    #region refereneces

    private Transform _myTransform;

    private ShootingComponent shooter;

    private Timer shootingTimer;

    private PlayerMain playerRef;

    private Animator animator;

    #endregion

    #region methods
    
    public void Shoot()
    {
        float anglePiece = 360 / numberOfShootedProyectiles;

        for (int i = 0; i < numberOfShootedProyectiles; i++)
        {
            float x = (float)Math.Cos(anglePiece * i + firstShootAngle);
            float y = (float)Math.Sin(anglePiece * i + firstShootAngle);

            Vector2 direction = new Vector2(x, y);

            shooter.Shoot(direction);
        }
    }
    
    #endregion

    void Start()
    {
        _myTransform = transform;

        shooter = GetComponent<ShootingComponent>();

        playerRef = FindAnyObjectByType<PlayerMain>();

        shootingTimer = GetComponent<Timer>();
        shootingTimer.SetTime(1 / shootFrecuencePerSecond);
    }

    void Update()
    {
        RaycastHit2D playerRay = Physics2D.Raycast(_myTransform.position, playerRef.transform.position - _myTransform.position);

        bool playerInFront = playerRay.collider != null && playerRay.collider.gameObject.GetComponent<PlayerMain>() != null;
        
        shootingTimer.SetRestart(playerInFront);

        if (shootingTimer.IsTimerRunning() == false && playerInFront) shootingTimer.TimerStart();
    }
}
