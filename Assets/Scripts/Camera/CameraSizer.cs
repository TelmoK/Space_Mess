using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CameraSizer : MonoBehaviour
{
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

    void Update()
    {
        float scaleTimeIndex = Math.Abs(cameraTargetSize - camera.orthographicSize) * 0.005f;

        if (cameraTargetSize - camera.orthographicSize < 0)
        {
            camera.orthographicSize -= scaleTimeIndex;
            if (cameraTargetSize - camera.orthographicSize >= 0) camera.orthographicSize = cameraTargetSize;
        }
        else
        {
            camera.orthographicSize += scaleTimeIndex;
            if (cameraTargetSize - camera.orthographicSize <= 0) camera.orthographicSize = cameraTargetSize;
        }
    }
}
