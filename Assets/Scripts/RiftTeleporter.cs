using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class RiftTeleporter : MonoBehaviour
{
    #region references

    [SerializeField]
    private GameObject linkedRift;

    #endregion

    #region methods

    private void OnTriggerEnter2D(Collider2D collision)
    {
        if(collision.GetComponent<PlayerMain>() != null)
        {
            collision.transform.position = linkedRift.transform.position;
        }
    }

    #endregion

    void Start()
    {
        
    }

    void Update()
    {
        
    }
}
