using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class Maneagetitle : MonoBehaviour
{
    [SerializeField] GameObject ShopPanel;
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    // �w�肳�ꂽ�V�[���ɑJ�ڂ���
    public void LoadScene()
    {
        SceneManager.LoadScene("title");
    }
    // �w�肳�ꂽ�V�[���ɑJ�ڂ���
    public void LoadScenestage()
    {
        SceneManager.LoadScene("stage");
    }

    public void setumei()
    {
        ShopPanel.SetActive(true);
    }
}
