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

    private PlayerMovement playerMovement;

    private ShootingComponent playerBlaster;

    #endregion

    #region properties

    private bool boostEnabled = true;

    private Vector3 facingDirection;

    private bool canShoot = true;

    #endregion

    #region methods

    public void SetFacingDirection(Vector3 direction)
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

    public bool CanShoot()
    {
        return canShoot;
    }

    #endregion
    void Start()
    {
        playerMovement = GetComponent<PlayerMovement>();

        playerBlaster = GetComponent<ShootingComponent>();
    }

    void Update()
    {
        
    }
}
