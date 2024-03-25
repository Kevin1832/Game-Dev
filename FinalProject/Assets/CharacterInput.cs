using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CharacterInput : MonoBehaviour
{
    [SerializeField] CharacterInput characterInput; 
    
    [SerializeField] Vector3 homePosition = Vector3.zero;

    [SerializeField] CharacterMovement characterMovement;

    void Start(){
        

    }

    // Update is called once per frame
    void Update()
    {
         Vector3 input = Vector3.zero;

        if (Input.GetKey(KeyCode.A))
        {
            input.x += -1;
        }

        if (Input.GetKey(KeyCode.D))
        {
            input.x += 1;
        }
        
        if (Input.GetKeyDown(KeyCode.Space))
        {
            characterMovement.Jump();
        }


        if (characterMovement!= null)
        {
            characterMovement.MoveCharacterRigidbody2D(input);
        }

 
        
    }
}
