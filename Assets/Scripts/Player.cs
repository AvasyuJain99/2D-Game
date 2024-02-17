using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Player : MonoBehaviour
{
    private Rigidbody2D rb;
    [SerializeField]
    private float jumpForce;
    [SerializeField]
    private bool isGrounded=false;
    [SerializeField]
    private LayerMask layerMask;
    // Start is called before the first frame update
    void Start()
    {
        rb = GetComponent<Rigidbody2D>();
    }

    // Update is called once per frame
    void Update()
    {
        Movement();
        if (Input.GetKeyDown(KeyCode.Space) && isGrounded == true)
            Jump();
        RaycastHit2D hitInfo = Physics2D.Raycast(transform.position, Vector2.down,0.6f,layerMask);
        Debug.DrawRay(transform.position, Vector2.down,Color.green,0.6f);
        if (hitInfo.collider != null)
        {
            isGrounded = true;
        }
    }
    void Movement()
    {
        float hInput = Input.GetAxisRaw("Horizontal");
        rb.velocity = new Vector2(hInput, rb.velocity.y);
        if (Input.GetKeyDown(KeyCode.A))
        {
            gameObject.GetComponentInChildren<SpriteRenderer>().flipX = true;
        }
        else if (Input.GetKeyDown(KeyCode.D))
        {
            gameObject.GetComponentInChildren<SpriteRenderer>().flipX = false;
        }
    }
    private void Jump()
    {
            rb.velocity = new Vector2(rb.velocity.x, jumpForce);
        
        StartCoroutine(jumpCooldown());
    }
    private IEnumerator jumpCooldown()
    {
        yield return new WaitForSeconds(0.1f);
        isGrounded=false;

    }
}
