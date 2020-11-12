using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.AI;

// All objects that the player interacts with are Interactable
public class Interactable : MonoBehaviour
{
    [HideInInspector]
    public NavMeshAgent playerAgent;
    private bool hasInteracted;

    //Moves the player infront of the interactable object
    public virtual void MoveToInteraction(NavMeshAgent playerAgent)
    {
        hasInteracted = false;
        this.playerAgent = playerAgent;
        playerAgent.stoppingDistance = 3f;
        playerAgent.destination = this.transform.position;
    }

    //This method ensures the interaction method is not trigerred before the player has arrived at the destination
    private void Update()
    {
        if (!hasInteracted && playerAgent != null && !playerAgent.pathPending)
        {
            if (playerAgent.remainingDistance <= playerAgent.stoppingDistance)
            {   

                Interact();
                LookAtRightDirection();
                hasInteracted = true;
            }
        }
    }

    void LookAtRightDirection()
    {
        playerAgent.updateRotation = false;
        Vector3 lookDirection = new Vector3(transform.position.x, playerAgent.transform.position.y, transform.position.z);
        playerAgent.transform.LookAt(lookDirection);
        playerAgent.updateRotation = true;
    
    }

    //The action to perform when the player has arrived to the destination. It has to be overriten
    public virtual void Interact()
    {
        Debug.Log("Interacting with base class");
    }

}
