using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.AI;

public class Agent : MonoBehaviour
{
    public GameObject waypoint;
    private NavMeshAgent nav_agent;


    // Start is called before the first frame update
    void Start()
    {
        //Get a reference to the components.
        nav_agent = GetComponent<NavMeshAgent>();

        //Tell the agent where to go.
        nav_agent.SetDestination(waypoint.transform.position);
    }

    // Update is called once per frame
    void Update()
    {
        
    }
}
