using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerCollisionManager : MonoBehaviour
{
    #region references

    PlayerMain playerMain;

    #endregion

    #region methods

    private void OnTriggerEnter2D(Collider2D collision)
    {
        if(collision.gameObject.GetComponent<FuelUnitBehaviour>() != null)
        {
            playerMain.AddFuelUnit();
        }

        if(collision.gameObject.GetComponent<GravitationalField>() != null)
        {
        //    playerMain.SetBoostEnabled(false);
        }
    }

    private void OnTriggerExit2D(Collider2D collision)
    {
        if (collision.gameObject.GetComponent<GravitationalField>() != null)
        {
        //    playerMain.SetBoostEnabled(true);
        }
    }

    #endregion

    void Start()
    {
        playerMain = GetComponent<PlayerMain>();
    }

    void Update()
    {
        
    }
}
