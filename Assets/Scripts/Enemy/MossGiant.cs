using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MossGiant : Enemy
{
    private Vector3 currentTarget;
    private SpriteRenderer mossGiantSprite;
    private Animator mossGiantAnim;
    // Start is called before the first frame update
    void Start()
    {
        mossGiantSprite = transform.GetChild(0).GetComponent<SpriteRenderer>();
        mossGiantAnim = GetComponentInChildren<Animator>();
    }
    protected override void Attack()
    {
        base.Attack();
    }
    protected override void Update()
    {
        if (mossGiantAnim.GetCurrentAnimatorStateInfo(0).IsName("Idle"))
        {
            Debug.Log("Check State");
            return;
        }
       
        Movement();
   
    }
    void Movement()
    {
        if (currentTarget == pointA.position)
        {
            mossGiantSprite.flipX = true;
        }
        else
        {
            mossGiantSprite.flipX = false;
        }
        if (transform.position == pointA.position)
        {
            currentTarget = pointB.position;
            mossGiantAnim.SetTrigger("Idle");
        }
        else if (transform.position==pointB.position)
        {
            currentTarget = pointA.position;
            mossGiantAnim.SetTrigger("Idle");

        }
        transform.position = Vector3.MoveTowards(transform.position, currentTarget, speed * Time.deltaTime);
    }
}
