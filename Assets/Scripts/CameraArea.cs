using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CameraArea : MonoBehaviour
{
    #region parameters

    [SerializeField]
    private float cameraSize = 10;

    [SerializeField]
    private float localCameraSmoothness = -1;

    #endregion

    #region references

    [SerializeField]
    private Camera camera;

    private CameraSmoothFollow cameraFollow;

    #endregion

    #region properties

    private bool playerInside = false;
    
    #endregion

    #region methods

    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.gameObject.GetComponent<PlayerMain>() != null) playerInside = true;
    }

    private void OnTriggerExit2D(Collider2D collision)
    {
        if (collision.gameObject.GetComponent<PlayerMain>() != null) playerInside = false;
    }

    #endregion

    void Start()
    {
        cameraFollow = camera.gameObject.GetComponent<CameraSmoothFollow>();
    }

    void Update()
    {
        if (playerInside)
        {
            if (localCameraSmoothness != -1) cameraFollow.SmoothnessFactor = localCameraSmoothness;
            else cameraFollow.SmoothnessFactor = cameraFollow.DefaultSmoothnessFactor;

            float scaleTimeIndex = Math.Abs(cameraSize - camera.orthographicSize) * 0.005f;

            if(cameraSize - camera.orthographicSize < 0)
            {
                camera.orthographicSize -= scaleTimeIndex;
                if(cameraSize - camera.orthographicSize >= 0) camera.orthographicSize = cameraSize;
            }
            else
            {
                camera.orthographicSize += scaleTimeIndex;
                if (cameraSize - camera.orthographicSize <= 0) camera.orthographicSize = cameraSize;
            }
        }
    }
}
