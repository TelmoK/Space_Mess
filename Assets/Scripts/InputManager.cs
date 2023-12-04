using System.Collections;
using System.Collections.Generic;
using Unity.VisualScripting;
using UnityEngine;

public class InputManager : MonoBehaviour
{
    #region references

    [SerializeField]
    private GameObject playerObj;
    private PlayerMain player;

    #endregion

    void Start()
    {
        player = playerObj.GetComponent<PlayerMain>();
    }

    void Update()
    {
        if (player != null)
        {
            if (Input.GetKeyDown(KeyCode.A)) player.BoostQuery();

            if (Input.GetMouseButtonDown(0)) player.ShootQuery();
            
            player.SetFacingDirection((Vector2)(Camera.main.ScreenToWorldPoint(Input.mousePosition) - player.transform.position));
        }
    }
}
