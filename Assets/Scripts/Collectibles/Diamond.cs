using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Diamond : MonoBehaviour
{

    [SerializeField]
    public int value = 1;
    private void OnTriggerEnter2D(Collider2D other)
    {
       
        if (other.gameObject.tag == "Player")
        { 
            Player player = other.GetComponent<Player>();
            player.diamonds += value;
            UIManager.instance.playerCoinCountText.text = player.diamonds.ToString();
            Destroy(this.gameObject);
        }
    }
}
