using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CharacterMovement : MonoBehaviour
{
    [SerializeField] string CreatureName = "GraveRobber";
    [SerializeField] float speed = 0f;
    [SerializeField] GameObject square;
    [SerializeField] float jumpForce = 5f;
    private float groundRadius = 0.1f;
    private bool isGrounded = true;
    [SerializeField] GameObject groundCheck;
    [SerializeField] LayerMask groundLayer;
    [SerializeField] Animator animator;
    [SerializeField] SpriteRenderer spriteRenderer;
    public static int livesText = 3;
    [SerializeField] private GameObject body;
    [SerializeField] private List<AnimationChanger> animationChanger;
    public enum CharacterMovementType { tf, physics };
    [SerializeField] CharacterMovementType movementType = CharacterMovementType.tf;
    [SerializeField] Vector3 homePosition = Vector3.zero;

    CharacterInput characterInput;

    Rigidbody2D rb;

    void Update()
    {

    }


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

               //set animation
        if(direction.x != 0){
            foreach(AnimationChanger asc in animationChanger){
                asc.ChangeAnimation("Walk");
            }
        }else{
            foreach(AnimationChanger asc in animationChanger){
                asc.ChangeAnimation("Idle");
            }
        }
    }

    public void MoveCharacterRigidbody2D(Vector3 direction)
    {
        Vector3 currentVelocity = new Vector3(0, rb.velocity.y, 0);

        rb.velocity = (currentVelocity) + (direction * speed);
        if(rb.velocity.x < 0){
            body.transform.localScale = new Vector3(-1,1,1);
        }else if(rb.velocity.x > 0){
            body.transform.localScale = new Vector3(1,1,1);
        }
    }

    public void MoveCharacterTransform(Vector3 direction)
    {
        transform.position += direction * Time.deltaTime * speed;
    }

    public void Jump()
    {
        isGrounded = Physics2D.OverlapCircle(groundCheck.transform.position, groundRadius, groundLayer);
        if(Input.GetKeyDown(KeyCode.Space) && isGrounded)
        {
             rb.AddForce(Vector3.up * jumpForce, ForceMode2D.Impulse);
        }

    }

}
