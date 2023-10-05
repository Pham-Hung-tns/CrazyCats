using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;
public class MainUI : MonoBehaviour
{
    [Header("Coin Price")]
    public TextMeshProUGUI nbCoinsText; // (text) tong so coin
    public TextMeshProUGUI coinsPriceText; // (text) gia cho tung man choi
    public GameManager gameManager;
    
    int playerNbCoins; // tong so coin
    int coinActualPrice; // gia cho tung man choi
    int initialPrice = 10; // gia cho man dau tien

    public GameObject characterController;
    private void Awake()
    {
        // tong luong coin ma nguoi choi co
        playerNbCoins = PlayerPrefs.GetInt("nbCoin", 0);

        // gia cho tung man choi - mac dinh = 10 PO
        coinActualPrice = initialPrice;

        // (text) tong luong coin
        nbCoinsText.text = ": " + playerNbCoins.ToString();
        // (text) gia man choi hien tai
        coinsPriceText.text = coinActualPrice + " PO";

    }

    public void IncrementCoinLevel()
    {
       
    }

    public void IncreaseTimeLevel()
    {
         // neu button duoc nhan va luong coin du
        if(playerNbCoins >= coinActualPrice)
        {
            // tru di luong coin tuong ung de mo khoa man choi moi
            playerNbCoins -= coinActualPrice;
            gameManager.timeVal += 5;
            
            // cap nhat lai tong luong coin va level (tang them 1 - mo khoa)
            PlayerPrefs.SetInt("nbCoin", playerNbCoins);
            PlayerPrefs.SetInt("coinsLevel", PlayerPrefs.GetInt("coinsLevel", 1) + 1);

            // (text) cap nhat lai tong so coin
            nbCoinsText.text = ": " + playerNbCoins.ToString();

            // (text) cap nhat lai gia de mo khoa man choi tiep theo
            coinActualPrice = initialPrice;
            coinsPriceText.text = coinActualPrice + " PO";

            characterController.transform.position = new Vector3(0, 0, 0);
        }
    }
}
