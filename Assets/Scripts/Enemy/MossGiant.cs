using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MossGiant : Enemy,IDamageable
{
    
    public  int Health { get; set; }
    public override void Init()
    {
        base.Init();
        Health = base.health;
    }
    public override void Movement()
    {
        base.Movement();
       
    }

    public void Damage()
    {
        if (isDead == true)
        { 
            return;
        }
           
        Debug.Log("Damage");
        Health--;
        anim.SetTrigger("Hit");
        isHit = true;
        anim.SetBool("InCombat", true);
        if (Health<1)
        {
            isDead = true;
            GetComponent<Collider2D>().enabled = false;
            anim.SetTrigger("Death");
            var go=Instantiate(diamondPrefab, transform.position, Quaternion.identity);
             go.GetComponent<Diamond>().value=gems;
            
        }
        
    }
}
