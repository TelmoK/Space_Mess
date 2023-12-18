using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerMain : MonoBehaviour
{
    #region parameters

    [SerializeField]
    private int energyUnits = 20;

    #endregion

    #region references

    [HideInInspector]
    private Rigidbody2D _body;

    [HideInInspector]
    public PlayerMovement _playerMovement;

    private ShootingComponent playerBlaster;

    private CameraAnimatorControl cameraAnimator;

    #endregion

    #region properties

    public Rigidbody2D body
    {
        get { return _body; }
    }

    public PlayerMovement playerMovement
    {
        get { return _playerMovement; }
    }

    private Vector2 facingDirection;

    private bool boostEnabled = true;

    private bool canShoot = true;

    private bool isInOrbit = false;

    #endregion

    #region methods

    public void SetFacingDirection(Vector2 direction)
    {
        facingDirection = direction.normalized;
    }

    public void BoostQuery()
    {
        if (playerMovement == null) return;

        if (isInOrbit == true)
        {
            SetIsInOrbit(false);
            return;
        }

        if (boostEnabled == false) return;

        playerMovement.Boost(facingDirection);
    }

    public void ShootQuery()
    {
        if (playerBlaster == null) return;

        if (canShoot == false) return;

        playerBlaster.Shoot(facingDirection);

        ConsumeEnergyUnits(1);

        cameraAnimator.SetCameraState(CameraAnimatorControl.CamState.ShootShake);

        playerMovement.AddSpeed(facingDirection * -playerMovement.BoostSpeed() * 0.03f);
    }

    public void AddEnergyUnits(int numberOfUnits)
    {
        energyUnits += Math.Abs(numberOfUnits);
    }

    public void ConsumeEnergyUnits(int numberOfUnits)
    {
        if (energyUnits == 0) return;

        energyUnits -= numberOfUnits;

        if (energyUnits < 0) energyUnits = 0;
    }

    public bool IsInOrbit()
    {
        return isInOrbit;
    }

    public void SetIsInOrbit(bool value)
    {
        isInOrbit = value;
    }

    #endregion
    void Start()
    {

        _body = GetComponent<Rigidbody2D>();

        _playerMovement = GetComponent<PlayerMovement>();

        playerBlaster = GetComponent<ShootingComponent>();

        cameraAnimator = Camera.main.GetComponent<CameraAnimatorControl>();
    }
    
    void Update()
    {
        boostEnabled = /*isInDarkArea == false &&*/ isInOrbit == false;

        canShoot = energyUnits > 0;
    }
}
