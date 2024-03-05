using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Diamond : MonoBehaviour
{
    private Player player;
    [SerializeField]
    private int value;
    private void OnTriggerEnter2D(Collider2D other)
    {
        player = other.GetComponent<Player>();
        if (other.gameObject.tag == "Player")
        {
            Destroy(this.gameObject);
            collectDiamond();
        }
    }

    void collectDiamond()
    {
        player.diamonds += value;
    }
}
