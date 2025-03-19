using System.Collections;
using System.Collections.Generic;
using System.Threading;
using UnityEngine;

public class kabe_Up : MonoBehaviour
{
    private float timedate;
    private float timedate2;
    private int Count;
    // Start is called before the first frame update
    void Start()
    {
        timedate = 0;
    }

    // Update is called once per frame
    void Update()
    {
        Vector3 pos = transform.position;
        timedate += Time.deltaTime;
        timedate2 += Time.deltaTime;
        if (timedate2 > 1)
        {
            Count++;
            timedate2 = 0;
        }
        if(Count > 0 && Count < 4)
        {
            pos.z -= 2f*Time.deltaTime;
            timedate = 0;
        }
        if (Count > 4 && Count < 8)
        {
            pos.z += 2f * Time.deltaTime;
            timedate = 0;
        }
        if (Count == 8)
        {
            Count = 0;
        }
        transform.position = pos;  // À•W‚ğİ’è
    }
}