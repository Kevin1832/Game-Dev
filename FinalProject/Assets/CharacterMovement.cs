using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UIElements;

public class CharacterMovement : MonoBehaviour
{
    [SerializeField] string CreatureName = "GraveRobber";
    [SerializeField] float speed = 0f;
    [SerializeField] GameObject square;
    [SerializeField] float jumpForce = 7;
    [SerializeField] float doubleTapTimeThreshold = 0.5f; // Time window for double tap

    public enum CharacterMovementType { tf, physics };
    [SerializeField] CharacterMovementType movementType = CharacterMovementType.tf;
    [SerializeField] Vector3 homePosition = Vector3.zero;

    CharacterInput characterInput;

    Rigidbody2D rb;

    void Start()
    {
        rb = gameObject.GetComponent<Rigidbody2D>();
    }

    public void MoveCreature(Vector3 direction)
    {
        if (movementType == CharacterMovementType.tf)
        {
            MoveCharacterTransform(direction);
        }
        else if (movementType == CharacterMovementType.physics)
        {
            MoveCharacterRigidbody2D(direction);
        }
    }

    public void MoveCharacterRigidbody2D(Vector3 direction)
    {
        Vector3 currentVelocity = new Vector3(0, rb.velocity.y, 0);
        rb.velocity = (currentVelocity) + (direction * speed);
    }

    public void MoveCharacterTransform(Vector3 direction)
    {
        transform.position += direction * Time.deltaTime * speed;
    }

    public void Jump()
    {
        rb.AddForce(Vector3.up * jumpForce, ForceMode2D.Impulse);
    }
}
