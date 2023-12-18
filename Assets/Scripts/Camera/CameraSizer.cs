using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CameraSizer : MonoBehaviour
{
    #region parameters

    [SerializeField]
    private float resizeFactor = 0.015f;
    
    #endregion

    #region properties

    private float cameraTargetSize = 10;

    #endregion

    #region references

    private Camera camera;

    #endregion

    #region methods
    
    public void SetCameraTargetSize(float targetSize)
    {
        cameraTargetSize = targetSize;
    }
    
    #endregion

    void Start()
    {
        camera = GetComponent<Camera>();
    }

    void FixedUpdate()
    {
        //float scaleTimeIndex = Math.Abs(cameraTargetSize - camera.orthographicSize) * 0.009f;

        if (cameraTargetSize - camera.orthographicSize < 0)
        {
            camera.orthographicSize *= 1 - resizeFactor;//camera.orthographicSize -= scaleTimeIndex;
            if (cameraTargetSize - camera.orthographicSize >= 0) camera.orthographicSize = cameraTargetSize;
        }
        else
        {
            camera.orthographicSize *= 1 + resizeFactor;//camera.orthographicSize += scaleTimeIndex;
            if (cameraTargetSize - camera.orthographicSize <= 0) camera.orthographicSize = cameraTargetSize;
        }
    }
}
