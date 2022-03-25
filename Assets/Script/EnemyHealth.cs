using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemyHealth : MonoBehaviour
{
    [SerializeField] float _hitPoints = 100f;

    public void TakeDamage(float damage)
    {
        BroadcastMessage("OnDamageTaken");
        _hitPoints -= damage;
        if(_hitPoints <= 0)
        {
            Destroy(gameObject);
        }
    }

}
