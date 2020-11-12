using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.AI;

public class WorldInteraction : MonoBehaviour
{
    NavMeshAgent playerAgent;
    private Animator animator;

    // Start is called before the first frame update
    void Start()
    {

        playerAgent = GetComponent<NavMeshAgent>();
        animator = GetComponent<Animator>();
    }

    // Update is called once per frame
    void Update()
    {

        
       if (playerAgent.remainingDistance <= playerAgent.stoppingDistance)
       {
            animator.SetBool("moveFast", false);
       }
       if (Input.GetMouseButtonDown(1) && !UnityEngine.EventSystems.EventSystem.current.IsPointerOverGameObject())
       {
           GetInteraction();
       }
    }

    //Gets the object that is hit by clicking with the mouse and perform an action depending on what object is clicked
    void GetInteraction()
    {
        Ray interactionRay = Camera.main.ScreenPointToRay(Input.mousePosition);
        RaycastHit interactionInfo;
        if (Physics.Raycast(interactionRay, out interactionInfo, Mathf.Infinity))
        {
            animator.SetBool("moveFast", true);
            GameObject interactedObject = interactionInfo.collider.gameObject;
            if (interactedObject.tag == "Interactable Object" || interactedObject.tag == "Enemy")
            {
                interactedObject.GetComponent<Interactable>().MoveToInteraction(playerAgent);
            }
            else {
                playerAgent.stoppingDistance = 0;
                playerAgent.destination = interactionInfo.point;

            }
        }
    }
}
