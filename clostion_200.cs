using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class clostion_200 : MonoBehaviour
{
    private float Timer = 0;
    private bool CountDonw = false;
    public static bool Atri = false;
    public static bool BGM = false;
    private void Update()
    {
        if (CountDonw)
        {
            Timer += Time.deltaTime;
            if (Timer > 40)
            {
                Atri = false;
                CountDonw = false;
                Timer = 0;
                Debug.Log("20��i��");
            }
            
        }
    }
    public void OnTriggerStay(Collider other)
    {
        if (other.CompareTag("boll"))
        {
            Timer += Time.deltaTime;
            if (Timer > 4.5f)
            {
                BGM = true;
            }

            if (Timer > 5)
            {
                BGM = false;
                CountDonw = true;
                Atri = true;
                Destroy(other.gameObject);
                Debug.Log("80coinGet");
            }
        }
    }
}
