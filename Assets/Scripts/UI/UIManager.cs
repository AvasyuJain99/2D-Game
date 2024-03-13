using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;
using UnityEngine.UI;
public class UIManager : MonoBehaviour
{
    public static UIManager instance;
    private void Awake()
    {
        if (instance == null)
        {
            instance = this;
        }
        else
        {
            Destroy(gameObject);
        }
    }
    public TextMeshProUGUI playerCoinCountText;
    public Image Selection;
    public TextMeshProUGUI playerGemCountText;
    public void OpenShop(int gemCount)
    {
        playerGemCountText.text =gemCount.ToString()+"G";
    }
    public void UpdateSelection(int yPos)
    {
        Selection.rectTransform.anchoredPosition = new Vector2(Selection.rectTransform.anchoredPosition.x, yPos);
    }
}
