using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerAnimation : MonoBehaviour
{
   
    private Animator player;
    private Animator swordEffect;
   
    void Start()
    {
        player = GetComponentInChildren<Animator>();
        swordEffect = transform.GetChild(1).GetComponent<Animator>();
       
    }
    public void Move(float move)
    {
        player.SetFloat("Move",Mathf.Abs(move));
    }
    public void Jump(bool isJumping)
    {
        player.SetBool("Jumping", isJumping);
    }
    public void Attack()
    {
        player.SetTrigger("Attack");
        swordEffect.SetTrigger("SwordEffect");
    
    }
   public void Hit()
    {
        player.SetTrigger("Hit");

    }
    public void Death()
    {
        player.SetTrigger("Death");
    }
}
