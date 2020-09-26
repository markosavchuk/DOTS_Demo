using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.AI;

public class CharacterControllerScript : MonoBehaviour
{
    private bool _isMoving;
    private List<Vector3> _availablePositions;
    private NavMeshAgent _navMeshAgent;

    private void Awake()
    {
        _availablePositions = Initialization.Instance.AvailablePositions;
        _navMeshAgent = GetComponent<NavMeshAgent>();
    }

    private void Update()
    {
        if (!_isMoving)
        {
            _isMoving = true;

            var randomPosition = _availablePositions[Random.Range(0, _availablePositions.Count)];
            _navMeshAgent.SetDestination(randomPosition);            
        }
        else
        {
            if (!_navMeshAgent.pathPending)
            {
                if (_navMeshAgent.remainingDistance <= _navMeshAgent.stoppingDistance )//||
                {
                    _isMoving = false;
                }
            }
        }
    }
}
