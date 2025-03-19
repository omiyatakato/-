using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class atri : MonoBehaviour
{
    public Transform BING;
    public GameObject Coin_prefab;
    public GameObject Boll;
    private float y;
    bool increasing = true; // 角度を増加させるかどうか
    bool increasing1 = true; // 力を増加させるかどうか
    bool increasing2 = true; // 力（Boll）を増加させるかどうか
    public Transform spawnPosition;
    public float forceAmount = 5f;   // コインに加える力の大きさ
    private float Count = 0;

    void Start()
    {
        BING = GetComponent<Transform>();
        StartCoroutine(RepeatAction());
        StartCoroutine(instantCoin());
        StartCoroutine(instantBoll());
    }

    // Update is called once per frame
    void Update()
    {
        if (clistion.Atri)
            Count += Time.deltaTime;
    }
    IEnumerator RepeatAction()
    {
        float rotationStep = 1f; // 回転の1フレームあたりの変化量
        float targetRotationY = 0f; // 現在の回転角度
        while (true)
        {
            // y が 0 以上 25 以下の間は角度を増加させる
            if (increasing)
            {
                if (targetRotationY < 25)
                {
                    targetRotationY += rotationStep; // 回転角度を増やす
                }
                else
                {
                    increasing = false; // 25度に達したら減少に切り替え
                }
            }
            // y が -25 以上の間は角度を減少させる
            else
            {
                if (targetRotationY > -25)
                {
                    targetRotationY -= rotationStep; // 回転角度を減らす
                }
                else
                {
                    increasing = true; // -25度に達したら増加に切り替え
                }
            }

            // Z軸やX軸の回転を維持しつつ、Y軸の回転だけ更新する
            Quaternion currentRotation = BING.rotation;
            BING.rotation = Quaternion.Euler(currentRotation.eulerAngles.x, targetRotationY, currentRotation.eulerAngles.z);

            // 指定した秒数待つ（ここでは0.05秒）
            yield return new WaitForSeconds(0.05f);
        }
    }
    IEnumerator instantCoin()
    {
        while (true)
        {
            if ((clistion.Atri || clostin_.Atri || clostion_200.Atri) && !Panel_controall.Camera_shop_Controller)
            {
                // コインを生成する
                Vector3 spawnPosition1 = spawnPosition.position;
                Quaternion spawnRotation = Quaternion.identity; // 回転は無回転
                GameObject coinInstance = Instantiate(Coin_prefab, spawnPosition1, spawnRotation);

                // Rigidbodyを取得
                Rigidbody coinRigidbody = coinInstance.GetComponent<Rigidbody>();
                if (coinRigidbody != null)
                {
                    if (increasing1)
                    {
                        if (forceAmount < 10)
                        {
                            forceAmount++; // Powreを増やす
                        }
                        else
                        {
                            increasing1 = false; // 25度に達したら減少に切り替え
                        }
                    }
                    // y が -25 以上の間は角度を減少させる
                    else
                    {
                        if (forceAmount > 2)
                        {
                            forceAmount--; // Powreを減らす
                        }
                        else
                        {
                            increasing1 = true; // -25度に達したら増加に切り替え
                        }
                    }
                    // 上方向に力を加える
                    coinRigidbody.AddForce(Vector3.left * forceAmount, ForceMode.Impulse);
                }
                // 指定した秒数待つ（ここでは0.5秒）
            }
            yield return new WaitForSeconds(0.2f);
        }
    }
    IEnumerator instantBoll()
    {
        while (true)
        {
            if ((clistion.Atri || clostin_.Atri || clostion_200.Atri) && !Panel_controall.Camera_shop_Controller)
            {
                // コインを生成する
                Vector3 spawnPosition12 = spawnPosition.position;
                Quaternion spawnRotation1 = Quaternion.identity; // 回転は無回転
                GameObject BollInstance = Instantiate(Boll, spawnPosition12, spawnRotation1);

                // Rigidbodyを取得
                Rigidbody BollRigidbody = BollInstance.GetComponent<Rigidbody>();

                if (BollRigidbody != null)
                {
                    if (increasing2)
                    {
                        if (forceAmount < 10)
                        {
                            forceAmount++; // Powreを増やす
                        }
                        else
                        {
                            increasing2 = false; // 25度に達したら減少に切り替え
                        }
                    }
                    // y が -25 以上の間は角度を減少させる
                    else
                    {
                        if (forceAmount > 2)
                        {
                            forceAmount--; // Powreを減らす
                        }
                        else
                        {
                            increasing2 = true; // -25度に達したら増加に切り替え
                        }
                    }
                    // 上方向に力を加える
                    BollRigidbody.AddForce(Vector3.left * forceAmount, ForceMode.Impulse);
                }
            }
            // 指定した秒数待つ（ここでは0.5秒）
            yield return new WaitForSeconds(4.5f);
        }
    }
}
