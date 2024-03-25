using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UIElements;

public class CharacterMovement : MonoBehaviour
{
    [SerializeField] string CreatureName = "GraveRobber";
    [SerializeField] float speed = 0f;
    float inputHorizontal;
    float inputVertical;
    bool faceRight = true;
    [SerializeField] GameObject square;
    [SerializeField] float jumpForce = 10;

    public enum CharacterMovementType { tf, physics };
    [SerializeField] CharacterMovementType movementType = CharacterMovementType.tf;
    [SerializeField] Vector3 homePosition = Vector3.zero;

    CharacterInput characterInput;

    Rigidbody2D rb;

    void Start()
    {
        rb = gameObject.GetComponent<Rigidbody2D>();
    }

    void FlipCharacter()
    {
        inputHorizontal = Input.GetAxisRaw("Horizontal");
        inputVertical = Input.GetAxisRaw("Vertical");

        if (inputHorizontal != 0)
        {
            rb.AddForce(new Vector2(inputHorizontal * speed, 0f));
        }
        if (inputHorizontal > 0 && !faceRight)
        {
            FlipUpdated();
        }
        if (inputHorizontal < 0 && faceRight)
        {
            FlipUpdated();
        }
    }

    void FlipUpdated()
    {
        Vector3 currentScale = gameObject.transform.localScale;
        currentScale.x *= -1;
        gameObject.transform.localScale = currentScale;

        faceRight = !faceRight;
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
