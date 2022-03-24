using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.AI;

public class AINavMesh : MonoBehaviour
{


    public bool setFollowFlag = false;
    public bool setFollowPlayer = false;
    public bool setFollowPlayerByDistance = false;

    [Range(5, 10)]
    public int setDistanceDetect;
    
    private Transform targetPosition;

    [SerializeField] private Transform movePositionTransform;
    [SerializeField] private Transform movePositionPlayer;

    private NavMeshAgent navMeshAgent;


    private void Awake()
    {   


        navMeshAgent = GetComponent<NavMeshAgent>();

        if (setFollowFlag)
        {
            targetPosition = movePositionTransform;
        } 
        else if (setFollowPlayer)
        {
            targetPosition = movePositionPlayer;
        } 
        else if (setFollowPlayerByDistance)
        {
            targetPosition = movePositionPlayer;
            SphereCollider rangeSphere = GetComponent<SphereCollider>();
            rangeSphere.radius = setDistanceDetect;
        }

    }

    private void Update()
    {   if (setFollowFlag || setFollowPlayer)
        {
            navMeshAgent.destination = targetPosition.position;
        } 
        else if (setFollowPlayerByDistance)
        {   
            DistanceTarget();
        }

    }


    private void DistanceTarget()
    {
        float distance = Vector3.Distance(targetPosition.position, transform.position);
        if (distance < setDistanceDetect)
        {
            navMeshAgent.destination = targetPosition.position;
        }
    }
}
