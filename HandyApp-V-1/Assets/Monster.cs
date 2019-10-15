using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.AI;
public class Monster : MonoBehaviour
{
    public Maneger maneger;
    NavMeshAgent navMeshAgent;

    private void Start()
    {
        navMeshAgent = GetComponent<NavMeshAgent>();
    }
    private void OnTriggerEnter(Collider other)
    {
        if (other.gameObject.name == maneger.player1.name)
        {
            navMeshAgent.nextPosition = other.transform.position;
        }
    }
    private void OnTriggerExit(Collider other)
    {
        if (other.gameObject.name == maneger.player1.name)
        {
            navMeshAgent.nextPosition = transform.position;
        }
    }
}
