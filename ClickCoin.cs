using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ClickCoin : MonoBehaviour
{
    public GameObject itemPrefab; // 生成するアイテムのプレハブ
    public Camera mainCamera; // 使用するカメラ（通常はMain Camera）
    public LayerMask clickableLayer; // クリック可能なレイヤーを指定
    public static int Coin_Click = 0;
    void Start()
    {
        // カメラが未設定の場合、メインカメラを自動的に使用
        if (mainCamera == null)
        {
            mainCamera = Camera.main;
        }
    }

    void Update()
    {
        // マウスの左クリックを検出
        if (Input.GetMouseButtonDown(0))
        {
            SpawnItemAtMousePosition();
        }
    }

    void SpawnItemAtMousePosition()
    {
        if (Coin_Count.Coin_count > 0)
        {
            // クリックしたマウスの位置を取得
            Ray ray = mainCamera.ScreenPointToRay(Input.mousePosition);
            RaycastHit hit;

            // Raycastを飛ばしてクリックした場所を確認
            if (Physics.Raycast(ray, out hit, Mathf.Infinity, clickableLayer))
            {
                Coin_Click++;
                // ヒットした場所の位置にアイテムを生成
                Vector3 spawnPosition = hit.point;
                Quaternion spawnRotation = Quaternion.identity;

                // アイテムの生成
                Instantiate(itemPrefab, spawnPosition, spawnRotation);
            }
        }
        
    }
}
