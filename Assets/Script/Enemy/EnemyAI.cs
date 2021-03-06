using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.AI;

public class EnemyAI : MonoBehaviour
{
    [SerializeField] Transform _target;
    [SerializeField] float _chaseRange = 5f;
    [SerializeField] float _turnSpeed = 5f;

    NavMeshAgent _navMeshAgent;
    float _distanceToTarget = Mathf.Infinity;
    bool isProvoked = false;
    EnemyHealth _health;

    void Start()
    {
        _navMeshAgent = GetComponent<NavMeshAgent>();
        _health = GetComponent<EnemyHealth>();
    }
    void Update()
    {
        if (_health.IsDead())
        {
            enabled = false;
           _navMeshAgent.enabled = false;
        }
        _distanceToTarget = Vector3.Distance(_target.position, transform.position);
        if (isProvoked)
        {   
            EngageTarget();
        }
        else if (_distanceToTarget <= _chaseRange)
        {
            isProvoked = true;
        }
    }
    public void OnDamageTaken()
    {
        isProvoked = true;
    }

    private void EngageTarget()
    {
        FaceTarget();
        if (_distanceToTarget >= _navMeshAgent.stoppingDistance)
        {
            ChaseTarget();
        }
        if (_distanceToTarget <= _navMeshAgent.stoppingDistance)
        {
            AttackTarget();
        }
    }

    private void ChaseTarget()
    {
        GetComponent<Animator>().SetBool("attack", false);
        GetComponent<Animator>().SetTrigger("move");
        _navMeshAgent.SetDestination(_target.position);
    }
    private void AttackTarget()
    {
        GetComponent<Animator>().SetBool("attack", true);
        Debug.Log("Attack Player");
    }
        
    private void FaceTarget()
    {
        Vector3 direction = (_target.position - transform.position).normalized;
        Quaternion lookRotation = Quaternion.LookRotation(new Vector3(direction.x, 0, direction.z));
        transform.rotation = Quaternion.Slerp(transform.rotation, lookRotation, Time.deltaTime * _turnSpeed);
    }

    void OnDrawGizmosSelected()
    {
        Gizmos.color = Color.red;
        Gizmos.DrawWireSphere(transform.position, _chaseRange);
    }
}
