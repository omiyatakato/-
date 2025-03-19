using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Click_Boll : MonoBehaviour
{
    public GameObject Boll;
    public GameObject LightPrefab; // 追従ライトのPrefab
    public GameObject LightPrefab_right; // 追従ライトのPrefab
    public GameObject LightPrefab_Left; // 追従ライトのPrefab
    public Camera mainCamera;
    public LayerMask clickableLayer; // クリック可能なレイヤーを指定
    private int boll_count = 0;
    private bool boll_index = false;
    public static bool is_state;
    public AudioSource audioSource;
    public AudioClip SE1;
    // Start is called before the first frame update
    void Start()
    {
        
    }

    void Update()
    {
        // クリックしたマウスの位置を取得
        Ray ray = mainCamera.ScreenPointToRay(Input.mousePosition);
        RaycastHit hit;
        if (Physics.Raycast(ray, out hit, Mathf.Infinity, clickableLayer))
        {
            if (Input.GetMouseButtonDown(0) && create_Coin.Camera_Bool && boll_count < 1)
            {
                boll_count += 1;
                boll_index = true;
                StartCoroutine(boll_ceack());
            }
        }
    }
    void Boll_Instante()
    {
        // クリックしたマウスの位置を取得
        Ray ray = mainCamera.ScreenPointToRay(Input.mousePosition);
        RaycastHit hit;
        if (create_Coin.Camera_Bool && boll_index && !Panel_controall.Camera_shop_Controller)
        {
            // Raycastを飛ばしてクリックした場所を確認
            if (Physics.Raycast(ray, out hit, Mathf.Infinity, clickableLayer))
            {
                audioSource.PlayOneShot(SE1);
                Debug.Log("ここが生成エリア");
                // ヒットした場所の位置にアイテムを生成
                Vector3 spawnPosition = hit.point;
                Quaternion spawnRotation = Quaternion.identity;

                // ボールの生成
                GameObject newBoll = Instantiate(Boll, spawnPosition, spawnRotation);

                // ライトの生成と追従設定
                GameObject lightObj = Instantiate(LightPrefab, spawnPosition, spawnRotation);
                lightObj.AddComponent<Light_of_Boll>().target = newBoll.transform;

                // ライトの生成と追従設定
                GameObject lightObj_Right = Instantiate(LightPrefab_right, spawnPosition, spawnRotation);
                lightObj.AddComponent<Light_of_Boll>().target = newBoll.transform;

                // ライトの生成と追従設定
                GameObject lightObj_Left = Instantiate(LightPrefab_Left, spawnPosition, spawnRotation);
                lightObj.AddComponent<Light_of_Boll>().target = newBoll.transform;
            }
        }
    }
    IEnumerator boll_ceack()
    {
        Boll_Instante();
        if(boll_index)
        {
            yield return new WaitForSeconds(10f);
            Debug.Log("15秒待機");
            boll_count = 0;
        }
    }
}
