using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.AI;

public class Navigation : MonoBehaviour
{
    [SerializeField]
    public NavMeshSurface NavMeshSurface;

    private void Start()
    {
        NavMeshSurface.BuildNavMesh();
    }
}
