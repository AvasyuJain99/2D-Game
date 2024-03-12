using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Player : MonoBehaviour,IDamageable
{
    private Rigidbody2D rb;
    [SerializeField]
    private float jumpForce;
    [SerializeField]
    private LayerMask layerMask;
    private bool resetJump = false;
    private bool grounded = false;
    [SerializeField]
    private float speed;
    private PlayerAnimation playerAnimation;
    public int diamonds;
    public int Health { get; set; }
    // Start is called before the first frame update
    void Start()
    {
        rb = GetComponent<Rigidbody2D>();
        playerAnimation = GetComponent<PlayerAnimation>();
    }

    // Update is called once per frame
    void Update()
    {
        Movement();
        if (Input.GetMouseButtonDown(0) && IsGrounded() == true)
        {
            playerAnimation.Attack();
           
        }
    }
    void Movement()
    {
        float hInput = Input.GetAxisRaw("Horizontal");
        grounded = IsGrounded();
        playerAnimation.Move(hInput);
        if (Input.GetKeyDown(KeyCode.Space) && IsGrounded() == true)
        {
            Debug.Log("Jump");  
            rb.velocity = new Vector2(rb.velocity.x, jumpForce);
            StartCoroutine(JumpCooldown());
            playerAnimation.Jump(true);
        }
        rb.velocity = new Vector2(hInput * speed, rb.velocity.y);
        flipPlayer(hInput);
    }
   bool IsGrounded()
    {
     RaycastHit2D hitInfo = Physics2D.Raycast(transform.position, Vector2.down, 1f, layerMask);
        Debug.DrawRay(transform.position, Vector2.down);
         if (hitInfo.collider != null)
        {
            if (resetJump == false)
            {
                playerAnimation.Jump(false);
                return true;
            }
        }
        return false;
    }
    void flipPlayer(float hInput)
    {
        if (hInput > 0)
        {
            GetComponentInChildren<SpriteRenderer>().flipX = false;
            transform.GetChild(1).GetComponent<SpriteRenderer>().flipX = false;
            transform.GetChild(1).GetComponent<SpriteRenderer>().flipY = false;
            Vector2 pos = transform.GetChild(1).GetComponent<SpriteRenderer>().transform.localPosition;
            pos.x = 1.01f;
            transform.GetChild(1).GetComponent<SpriteRenderer>().transform.localPosition = pos;

        }
        else if (hInput < 0)
        {
            GetComponentInChildren<SpriteRenderer>().flipX = true;
            transform.GetChild(1).GetComponent<SpriteRenderer>().flipX = false;
            transform.GetChild(1).GetComponent<SpriteRenderer>().flipY = true;
            Vector2 pos = transform.GetChild(1).GetComponent<SpriteRenderer>().transform.localPosition;
            pos.x = -1.01f;
            transform.GetChild(1).GetComponent<SpriteRenderer>().transform.localPosition = pos;

        }
    }
  
    IEnumerator JumpCooldown()
    {
        resetJump = true;
        yield return new WaitForSeconds(0.1f);
        resetJump = false;
    }

    public void Damage()
    {
        Debug.Log("Player got hit");
        Health--;
    }
}
