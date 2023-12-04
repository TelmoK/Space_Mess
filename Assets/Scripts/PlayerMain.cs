using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerMain : MonoBehaviour
{
    #region parameters

    [SerializeField]
    private int fuelUnits = 5;

    #endregion

    #region references

    [HideInInspector]
    public Rigidbody2D body;

    [HideInInspector]
    public PlayerMovement playerMovement;

    private ShootingComponent playerBlaster;

    #endregion

    #region properties

    private bool boostEnabled = true;

    private Vector2 facingDirection;

    private bool canShoot = true;

    private bool isBoosting = false;

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

        playerMovement.AddSpeed(facingDirection * -playerMovement.BoostSpeed() * 0.03f);
    }

    public bool IsBoosting()
    {
        return isBoosting;
    }

    public void SetBoostEnabled(bool value)
    {
        boostEnabled = value;
    }

    public bool CanShoot()
    {
        return canShoot;
    }

    public void AddFuelUnit()
    {
        fuelUnits++;
    }

    public void ConsumeFuelUnit()
    {
        if (fuelUnits == 0) return;
        
        fuelUnits--;
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
        body = GetComponent<Rigidbody2D>();

        playerMovement = GetComponent<PlayerMovement>();

        playerBlaster = GetComponent<ShootingComponent>();
    }
    
    void Update()
    {
        boostEnabled = (fuelUnits > 0) && isInOrbit == false;
    }
}
