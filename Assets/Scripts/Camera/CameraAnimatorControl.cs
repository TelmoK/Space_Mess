using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CameraAnimatorControl : MonoBehaviour
{
    #region references

    private Animator cameraAnimator;

    #endregion

    #region properties
    
    public enum CamState {Idle = 0, ShootShake = 1}
    
    #endregion

    #region methods
    
    public void SetCameraState(CamState cameraState)
    {
        cameraAnimator.SetInteger("CameraMode", (int)cameraState);
    }
    
    #endregion

    void Start()
    {
        cameraAnimator = GetComponent<Animator>();
    }

    void Update()
    {
        
    }
}
