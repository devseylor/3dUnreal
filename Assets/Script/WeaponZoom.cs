using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Cinemachine;
using StarterAssets;

public class WeaponZoom : MonoBehaviour
{
    [SerializeField] CinemachineVirtualCamera _cameraFOV;
    [SerializeField] float _zoomOutFov = 40;
    [SerializeField] float _zoomInFov = 20;
    [SerializeField] float _zoomOutSensitivity = 1;
    [SerializeField] float _zoomInSensitivity = 0.5f;

    private FirstPersonController _firstPersonController;
    bool zoomedInToggle = false;

    void Start()
    {
        _firstPersonController = GetComponent<FirstPersonController>();   
    }
    void Update()
    {
        if (Input.GetMouseButtonDown(1))
        {
            if(zoomedInToggle == false)
            {
                zoomedInToggle = true;
                _cameraFOV.m_Lens.FieldOfView = _zoomInFov;
                _firstPersonController.RotationSpeed = _zoomInSensitivity;
            }
            else
            {
                zoomedInToggle = false;
                _cameraFOV.m_Lens.FieldOfView = _zoomOutFov;
                _firstPersonController.RotationSpeed = _zoomOutSensitivity;
            }
        }    
    }
}
