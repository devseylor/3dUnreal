using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Cinemachine;
using StarterAssets;
using UnityEngine.InputSystem;
using System;

public class Weapon : MonoBehaviour
{
    [SerializeField] Camera FPCamera;
    [SerializeField] float _range = 100f;
    [SerializeField] float _damage = 30f;
    [SerializeField] ParticleSystem _muzzleFlash;
    [SerializeField] GameObject _hitEffect;
    private StarterAssetsInputs _starterAssetsInputs;
    private void Awake()
    {
        _starterAssetsInputs = FindObjectOfType<StarterAssetsInputs>();
    }

    void Update()
    {
        if (_starterAssetsInputs.shoot)
        {
            Shoot();
            _starterAssetsInputs.shoot = false;
        }
        
    }

    public void Shoot()
    {
        PlayMuzzleFlash();
        ProcessRaycast();
    }

    private void PlayMuzzleFlash()
    {
        _muzzleFlash.Play();
    }

    private void ProcessRaycast()
    {
        RaycastHit hit;
        if (Physics.Raycast(FPCamera.transform.position, FPCamera.transform.forward, out hit, _range))
        {
            CreateHitImpact(hit);
            EnemyHealth target = hit.transform.GetComponent<EnemyHealth>();
            if (target == null) return;
            target.TakeDamage(_damage);
        }
        else
        {
            return;
        }
    }

    private void CreateHitImpact(RaycastHit hit)
    {
        GameObject impact =  Instantiate(_hitEffect, hit.point, Quaternion.LookRotation(hit.normal));
        Destroy(impact, 0.3f);
    }
}
