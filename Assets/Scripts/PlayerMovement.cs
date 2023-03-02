using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerMovement : MonoBehaviour
{
    private Rigidbody2D rigid;
    private Animator anim;

    private BoxCollider2D collider;
    [SerializeField] private LayerMask isGround;

    private SpriteRenderer sprite;
    private float dirX = 0f;
    [SerializeField] private float MoveSpeed = 0f;
    [SerializeField] private float jumpHeight = 14f;

    private enum MovementState { PlayerIdle, PlayerRun, PlayerJump, PlayerFall }
    private MovementState state = MovementState.PlayerIdle;

    // Start is called before the first frame update
    private void Start()
    {
        rigid = GetComponent<Rigidbody2D>();
        sprite = GetComponent<SpriteRenderer>();
        anim = GetComponent<Animator>();
        collider = GetComponent<BoxCollider2D>();
    }

    // Update is called once per frame
    private void Update()
    {
        dirX  = Input.GetAxisRaw("Horizontal");
        rigid.velocity = new Vector2(dirX * MoveSpeed, rigid.velocity.y);

        if (Input.GetKeyDown("space") && CheckGround())
        {
            rigid.velocity = new Vector3(rigid.velocity.x,jumpHeight);
        }

        UpdateAnimation();
    }
    
    private void UpdateAnimation() //For animation
    {
        MovementState state;

        if (dirX > 0f) //Running
        {
            state = MovementState.PlayerRun;
            sprite.flipX = false;
        }
        else if (dirX < 0f)
        {
            state = MovementState.PlayerRun;
            sprite.flipX = true;
        }
        else
        {
            state = MovementState.PlayerIdle;
        }

        if (rigid.velocity.y > 0.1f)//Jumping
        {
            state = MovementState.PlayerJump;
        }
        else if (rigid.velocity.y < -0.1f)//Falling
        {
            state = MovementState.PlayerFall;
        }

        anim.SetInteger("state", (int)state);
    }
   
    private bool CheckGround()
    {
        return Physics2D.BoxCast(collider.bounds.center, collider.bounds.size, 0f, Vector2.down, 0.1f, isGround);
    }  
}
