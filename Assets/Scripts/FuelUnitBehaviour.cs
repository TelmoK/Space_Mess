using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class FuelUnitBehaviour : MonoBehaviour
{
    #region methods

    private void OnTriggerEnter2D(Collider2D collision)
    {
        PlayerMain player = collision.gameObject.GetComponent<PlayerMain>();

        if (player == null) return;

        //TODO Animation
        Destroy(gameObject);
    }

    #endregion
    void Start()
    {
        
    }

    void Update()
    {
        
    }
}
