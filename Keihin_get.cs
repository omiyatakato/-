using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Keihin_get : MonoBehaviour
{
    [SerializeField] GameObject ShopPanel;
    [SerializeField] GameObject SelectPanel;
    [SerializeField] GameObject Buy_No_Panel;
    [SerializeField] GameObject Buy_Yes_Panel;
    public GameObject jewel;//3dモデルのプレハブ
    public List<GameObject> inventory = new List<GameObject>();//1持ち物リスト
    public Transform viewerPosition; // モデルを表示する位置
    private GameObject currentModel;
    private bool jewel_controller=true;
    public GameObject cofe;//3dモデルのプレハブ
    private bool cofe_controller = true;
    public static int  Coin_down=0;
    public GameObject stave;//3dモデルのプレハブ
    private bool stave_controller = true;
    public AudioSource audioSource;
    public AudioClip OK_SE;
    public AudioClip Btn_Ok;
    public AudioClip Btn_No;
    public AudioClip launch;
    public void Getjewel()
    {
        if (jewel_controller & Coin_Count.Coin_count >= 100)
        {
            Buy_Yes_Panel.SetActive(true);
            audioSource.PlayOneShot(OK_SE);
            Coin_down += 100;
            inventory.Add(jewel);
            jewel_controller = false;
        }
        else
        if (jewel_controller & Coin_Count.Coin_count < 100)
        {
            audioSource.PlayOneShot(Btn_No);
            Buy_No_Panel.SetActive(true);
            Debug.Log("コインが足り線");
        }
        else
        if (!jewel_controller)
        {
            audioSource.PlayOneShot(launch);
            SelectPanel.SetActive(true);
            ShopPanel.SetActive(false);
            // 新しいモデルを表示位置にインスタンス化
            currentModel = Instantiate(jewel, viewerPosition.position, viewerPosition.rotation);
        }
    }
    public void SerectBtn()
    {
        if (currentModel != null)
        {
            Destroy(currentModel); // 以前のモデルを破棄
        }
        if (!jewel_controller)
        {
            SelectPanel.SetActive(false);
            ShopPanel.SetActive(true);
        }
        if (!cofe_controller)
        {
            SelectPanel.SetActive(false);
            ShopPanel.SetActive(true);
        }
        if (!stave_controller)
        {
            SelectPanel.SetActive(false);
            ShopPanel.SetActive(true);
        }
    }
    public void Getcofe()
    {
        if (cofe_controller & Coin_Count.Coin_count >= 50)
        {
            Buy_Yes_Panel.SetActive(true);
            audioSource.PlayOneShot(OK_SE);
            Coin_down += 100;
            inventory.Add(cofe);
            cofe_controller = false;
        }
        else
        if (cofe_controller & Coin_Count.Coin_count < 50)
        {
            audioSource.PlayOneShot(Btn_No);
            Buy_No_Panel.SetActive(true);
            Debug.Log("コインが足り線");
        }
        else
        if (!cofe_controller)
        {
            audioSource.PlayOneShot(launch);
            SelectPanel.SetActive(true);
            ShopPanel.SetActive(false);
            // 新しいモデルを表示位置にインスタンス化
            currentModel = Instantiate(cofe, viewerPosition.position, viewerPosition.rotation);
        }
    }
    public void Getstave()
    {
        if (stave_controller & Coin_Count.Coin_count >= 50)
        {
            Buy_Yes_Panel.SetActive(true);
            audioSource.PlayOneShot(OK_SE);
            Coin_down += 100;
            inventory.Add(stave);
            stave_controller = false;
        }
        else
        if (stave_controller & Coin_Count.Coin_count < 50)
        {
            audioSource.PlayOneShot(Btn_No);
            Buy_No_Panel.SetActive(true);
            Debug.Log("コインが足り線");
        }
        else
        if (!stave_controller)
        {
            audioSource.PlayOneShot(launch);
            SelectPanel.SetActive(true);
            ShopPanel.SetActive(false);
            // 新しいモデルを表示位置にインスタンス化
            currentModel = Instantiate(stave, viewerPosition.position, viewerPosition.rotation);
        }
    }
    public void OKBtn()
    {
        audioSource.PlayOneShot(Btn_Ok);
    }
    public void REturnNo()
    {
        Buy_No_Panel.SetActive(false);
    }
    public void REturnYes()
    {
        Buy_Yes_Panel.SetActive(false);
    }
}
