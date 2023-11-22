using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ShootingComponent : MonoBehaviour
{
    #region references

    [SerializeField]
    private GameObject proyectilePrefab;

    private Transform _myTransform;

    #endregion

    #region methods

    public void Shoot(Vector3 proyectileDirection)
    {
        GameObject proyectile = Instantiate(proyectilePrefab, _myTransform.position, Quaternion.identity);
        proyectile.GetComponent<ProyectileMovement>().SetupDirection(proyectileDirection);
    }

    #endregion

    void Start()
    {
        _myTransform = transform;
    }

    void Update()
    {
        
    }
}
