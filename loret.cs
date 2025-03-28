using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class loret : MonoBehaviour
{
    public Transform BING;
    // Start is called before the first frame update
    void Start()
    {
        BING = GetComponent<Transform>();
        StartCoroutine(Rolet());
    }

    // Update is called once per frame
    void Update()
    {

    }
    IEnumerator Rolet()
    {
        float rotationStep = 2f; // 回転の1フレームあたりの変化量
        float targetRotationY = 0f; // 現在の回転角度
        while (true)
        {
        targetRotationY -= rotationStep; // 回転角度を減らす
        // Z軸やX軸の回転を維持しつつ、Y軸の回転だけ更新する
        Quaternion currentRotation = BING.rotation;
        BING.rotation = Quaternion.Euler(currentRotation.eulerAngles.x, targetRotationY, currentRotation.eulerAngles.z);

        // 指定した秒数待つ（ここでは0.05秒）
        yield return new WaitForSeconds(0.05f);
        }
       
    }
}
