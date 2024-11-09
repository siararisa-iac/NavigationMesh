using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.AI;


public class ClickToMove : MonoBehaviour
{
    [SerializeField]
    private Transform targetMarker; 
    private NavMeshAgent agent;

    private void Awake(){
        agent = GetComponent<NavMeshAgent>();
    }
   
    // Update is called once per frame
    private void Update()
    {
        if(Input.GetMouseButtonDown(0))
        {
            //Raycast to where the player agent will move
            Ray ray = Camera.main.ScreenPointToRay(Input.mousePosition);
            if(Physics.Raycast(ray, out RaycastHit hitInfo))
            {
                UpdateTarget(hitInfo.point);
            }
        }
    }

    private void UpdateTarget(Vector3 position)
    {
        agent.SetDestination(position);
        targetMarker.position = position;
    }
}
