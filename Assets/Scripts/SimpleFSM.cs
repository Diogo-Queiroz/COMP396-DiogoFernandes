using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public enum EnemySimpleFSMStates
{
    Patrol,
    Chase,
    Attack
}

public class SimpleFSM : MonoBehaviour
{
    [SerializeField] private EnemySimpleFSMStates _currentState;
    [SerializeField] private GameObject _player;
    
    [Header("Guard Stats")]
    [SerializeField, Range(8f, 15f)] 
    private float _distanceToChase = 10f;

    [SerializeField, Range(0.12f, 0.80f)]
    private float _fieldOfView = 0.28f;

    [SerializeField, Range(2f, 7f)]
    private float _distanceToAttack = 3f;

    [SerializeField] private bool _isInFront;
    
    void Start()
    {
        _currentState = EnemySimpleFSMStates.Patrol;
        _player = GameObject.FindWithTag("Player");
    }

    void Update()
    {
        FiniteStateMachineRunner();
    }
    private void FiniteStateMachineRunner()
    {
        switch (_currentState)
        {
            case EnemySimpleFSMStates.Patrol:
                Patrol();
                break;
            case EnemySimpleFSMStates.Chase:
                Chase();
                break;
            case EnemySimpleFSMStates.Attack:
                Attack();
                break;
            default: 
                Debug.LogError("State in FSM not implemented");
                break;
        }
    }

    private void Patrol()
    {
        Debug.Log("Patrolling...");
        Vector3 playerPosInRelationToGuard = _player.transform.position - transform.position;
        float distanceToPlayer = playerPosInRelationToGuard.magnitude;
        Vector3 directionToPlayer = playerPosInRelationToGuard / distanceToPlayer;

        _isInFront = Vector3.Dot(transform.forward, directionToPlayer) > _fieldOfView;
        if (_isInFront && distanceToPlayer < _distanceToChase)
        {
            _currentState = EnemySimpleFSMStates.Chase;
        }
    }
    private void Chase()
    {
        Debug.Log("CHAAAASEEEE....");
    }
    private void Attack() { }
}
