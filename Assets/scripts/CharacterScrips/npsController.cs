using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.AI;

public class npsController : MonoBehaviour
{
    public NavMeshAgent agent;
    public Animator animator;

    public GameObject Path;
    public Transform[] PathPoints;

    public int index = 0;
    public float minDistance = 10;

    void Start()
    {
        agent = GetComponent<NavMeshAgent>();
        animator = GetComponent<Animator>();
        PathPoints = new Transform[Path.transform.childCount];
        for (int i = 0; i < PathPoints.Length; i++)
        {
            PathPoints[i] = Path.transform.GetChild(i);
        }
    }

    void FixedUpdate()
    {
        roam();
    }

    void roam()
    {
        if (Vector3.Distance(transform.position, PathPoints[index].position) < minDistance)
        {
            //if (index >= 0 && index < PathPoints.Length)
            if (index + 1 != PathPoints.Length)
            {
                index += 1;
            }
            else {
                index = 0;
            }
        }
        agent.SetDestination(PathPoints[index].position);
        animator.SetFloat("vertical", !agent.isStopped ? 1 : 0);
	
    }

}
