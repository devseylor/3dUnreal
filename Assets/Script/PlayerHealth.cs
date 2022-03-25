using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerHealth : MonoBehaviour
{
    [SerializeField] float _health = 100;
   
    public void TakeDamage(float damage)
    {
        _health -= damage;
        if( _health < 1)
        {
            GetComponent<DeathHandler>().HandleDeath();
            Debug.Log("You are dead");
        }
    }
}
