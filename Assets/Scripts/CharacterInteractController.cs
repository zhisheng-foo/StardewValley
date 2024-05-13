using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CharacterInteractController : MonoBehaviour
{
    CharacterController2D characterController;
    Rigidbody2D rgbd2d;
    [SerializeField] float offsetDistance = 1f;
    [SerializeField] float sizeOfInteractableArea = 1.2f;
    Character character;
    [SerializeReference] HighLightController highlightController;
    private void Awake()
    {
        characterController = GetComponent<CharacterController2D>();
        rgbd2d = GetComponent<Rigidbody2D>();
        character = GetComponent<Character>();
    }

    private void Update()
    {
        Check();
        if (Input.GetMouseButtonDown(1))
        {
            Interact();
            
        }
    }

    private void Check()
    {
        Vector2 position = rgbd2d.position + characterController.lastMotionVector * offsetDistance;


        Collider2D[] colliders = Physics2D.OverlapCircleAll(position, sizeOfInteractableArea);

        //Checking if the tool box collide with the said object 
        foreach (Collider2D c in colliders) 
        {
            Interactable interact = c.GetComponent<Interactable>();
            if (interact != null)
            {
                highlightController.Highlight(interact.gameObject);
                return;
            }
           
        }

        highlightController.Hide();
       
       
    }

    private void Interact()
    {   
        
        Vector2 position = rgbd2d.position + characterController.lastMotionVector * offsetDistance;

        
        Collider2D[] colliders = Physics2D.OverlapCircleAll(position, sizeOfInteractableArea);

        //Checking if the tool box collide with the said object 
        foreach (Collider2D c in colliders) 
        {
            Interactable interact = c.GetComponent<Interactable>();
            if (interact != null)
            {
                interact.Interact(character);
                
                break;
            }
           
        }
    }


}
