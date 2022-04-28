using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Pickup : MonoBehaviour
{
    [SerializeField] int _ammoAmount = 5;
    [SerializeField] AmmoType _ammoType;

    private void OnTriggerEnter(Collider other)
    {
        if (other.CompareTag("Player"))
        {
            FindObjectOfType<Ammo>().IncreaseCurrentAmmo(_ammoType,_ammoAmount);
            Destroy(gameObject);
        }
    }
}
