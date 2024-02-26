using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Spider : Enemy
{
    protected override void Update()
    {
        Debug.Log("Updating Spider");
    }

    // Start is called before the first frame update
    void Start()
    {
        Attack();
    }

 
}
