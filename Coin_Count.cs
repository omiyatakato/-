using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
public class Coin_Count : MonoBehaviour
{
    public Text Coin;
    public Text Bool;
    private int boll;
    public static int Coin_count=0;
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        Coin_count = 200 + create_Coin.Coin - Keihin_get.Coin_down-ClickCoin.Coin_Click;
        boll = create_Coin.boll;
        Coin.text = "×：" + Coin_count;
        Bool.text = "×：" + create_Coin.boll;
    }

    public void SaveGame()
    {
        PlayerPrefs.SetInt("CoinCount", Coin_count);
        PlayerPrefs.SetInt("BallCount", boll);
        PlayerPrefs.Save();
        Debug.Log("Game Saved");
    }

    public void LoadGame()
    {
        Coin_count = PlayerPrefs.GetInt("CoinCount", 0); // デフォルトは0
        boll = PlayerPrefs.GetInt("BallCount", 0);
        Debug.Log("Game Loaded");
    }

}