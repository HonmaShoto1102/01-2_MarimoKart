using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.AI;

public class EnemyMove : MonoBehaviour
{

    public GameObject[] checkPoint;
    public NavMeshAgent agent;

    private int i = 0;

    void Start()
    {
       // agent = GetComponent<NavMeshAgent>();
    }

    void Update()
    {
        if (agent.pathStatus != NavMeshPathStatus.PathInvalid)
            agent.SetDestination(checkPoint[i].transform.position);
        Debug.Log(i);
    }




    void OnTriggerEnter(Collider collider)
    {
        Debug.Log("atta");
        if (collider.CompareTag("Player")==true)
        {
            Debug.Log("atta2");
            i++;
        }
    }

    void OnDrawGizmos()
    {
        if (agent != null)
        {
            Vector3[] corners = agent.path.corners;
            Gizmos.color = Color.red;

            for (int i = 0; i < corners.Length - 1; i++)
            {
                Gizmos.DrawLine(corners[i], corners[i + 1]);
            }
        }
    }
}
