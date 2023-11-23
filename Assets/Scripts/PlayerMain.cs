using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerMain : MonoBehaviour
{
    #region parameters

    [SerializeField]
    private int energyUnits;

    #endregion

    #region references

    public Rigidbody2D body;

    public PlayerMovement playerMovement;

    private ShootingComponent playerBlaster;

    #endregion

    #region properties

    private bool boostEnabled = true;

    private Vector2 facingDirection;

    private bool canShoot = true;

    private bool isBoosting = false;

    #endregion

    #region methods

    public void SetFacingDirection(Vector2 direction)
    {
        facingDirection = direction.normalized;
    }

    public void BoostQuery()
    {
        if (playerMovement == null) return;

        if (boostEnabled == false) return;
        playerMovement.Boost(facingDirection);
    }

    public void ShootQuery()
    {
        if (playerBlaster == null) return;

        if (canShoot == false) return;
        playerBlaster.Shoot(facingDirection);
    }

    public void SetIsBoosting(bool value)
    {
        if (!boostEnabled) return;
        isBoosting = value;
    }

    public bool IsBoosting()
    {
        return isBoosting;
    }

    public bool CanShoot()
    {
        return canShoot;
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

    }
}
