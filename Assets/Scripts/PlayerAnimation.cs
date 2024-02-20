using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerAnimation : MonoBehaviour
{
    [SerializeField]
    private Animator player;
   
    // Start is called before the first frame update
    void Start()
    {
        player = GetComponentInChildren<Animator>();
    }
    public void Move(float move)
    {
        player.SetFloat("Move",Mathf.Abs(move));
    }
    public void Jump(bool isJumping)
    {
        player.SetBool("Jumping", isJumping);
    }
}
