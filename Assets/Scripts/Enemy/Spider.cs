using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Spider : Enemy,IDamageable
{
    public int Health { get; set; }
    [SerializeField]
    private GameObject acidPrefab;
    public override void Init()
    {
        base.Init();
        Health = base.health;
    }
    public override void Movement()
    {
       
    }
    public void Damage()
    {
        if (isDead == true)
            return;
        Health--;
        if (Health < 1)
        {
            isDead = true;
            anim.SetTrigger("Death");
            GetComponent<Collider2D>().enabled = false;
            var go = Instantiate(diamondPrefab, transform.position, Quaternion.identity);
            go.GetComponent<Diamond>().value = gems;
        }
    }
    public void Attack()
    {
        Instantiate(acidPrefab, transform.position, Quaternion.identity);
    }
}

