using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Shop : MonoBehaviour
{
    [SerializeField]
    private GameObject shop;
    public int currentSelectedItem;
    public int currentItemPrice;
    private Player player;
    private void OnTriggerEnter2D(Collider2D other)
    {
        if (other.gameObject.tag == "Player")
        {
            player = other.GetComponent<Player>();
            if (player != null)
            {
                UIManager.instance.OpenShop(player.diamonds);
            }
            shop.SetActive(true);
        }
    }
    private void OnTriggerExit2D(Collider2D other)
    {
        if (other.gameObject.tag == "Player")
        {
            shop.SetActive(false);
          
        }
    }
    public void SelectItem(int Item)
    {
        switch (Item)
        {
            case 0:
                UIManager.instance.UpdateSelection(90);
                currentSelectedItem = 0;
                currentItemPrice = 200;
                break;
            case 1:
                UIManager.instance.UpdateSelection(-20);
                currentSelectedItem = 1;
                currentItemPrice = 400;
                break;
            case 2:
                UIManager.instance.UpdateSelection(-125);
                currentSelectedItem = 2;
                currentItemPrice = 100;
                break;
        }
    }
    public void BuyItem()
    {
        if (currentSelectedItem == 2)
        {
            GameManager.instance.hasKey = true;
        }
        if (player.diamonds >= currentItemPrice)
        {
            player.diamonds -= currentItemPrice;
            UIManager.instance.playerGemCountText.text = player.diamonds.ToString() + "G";
        }
        else
        {
            Debug.Log("Not Enough Gold");
        }
    }
}
