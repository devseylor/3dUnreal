using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemyAttack : MonoBehaviour
{
    PlayerHealth _target;
    [SerializeField] float _damage = 40f;
    void Start()
    {
        _target = FindObjectOfType<PlayerHealth>();
    }
    
    public void AttackHitEvent()
    {
        if (_target == null) return;
        _target.TakeDamage(_damage);
    }
}
