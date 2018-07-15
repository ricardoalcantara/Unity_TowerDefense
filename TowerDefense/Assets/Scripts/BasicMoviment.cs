using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.AI;

public class BasicMoviment : MonoBehaviour
{
    NavMeshAgent _navMeshAgent;

    [SerializeField]
    private GameObject _targetGameobject;
    void Start()
    {
        _navMeshAgent = GetComponent<NavMeshAgent>();
        _navMeshAgent.destination = _targetGameobject.transform.position;
    }

    void Update()
    {

    }
}
