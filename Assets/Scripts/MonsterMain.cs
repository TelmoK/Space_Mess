using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MonsterMain : MonoBehaviour
{
    #region parameters

    [SerializeField]
    private int lifePoints = 2;

    #endregion

    #region methods

    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.gameObject.GetComponent<ProyectileMovement>() == null) return;
        
        if (lifePoints > 0) lifePoints--;
    }

    #endregion

    void Start()
    {
        
    }

    void Update()
    {
        if (lifePoints == 0) Destroy(gameObject);
    }
}
