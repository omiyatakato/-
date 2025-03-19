using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Click_Boll : MonoBehaviour
{
    public GameObject Boll;
    public GameObject LightPrefab; // �Ǐ]���C�g��Prefab
    public GameObject LightPrefab_right; // �Ǐ]���C�g��Prefab
    public GameObject LightPrefab_Left; // �Ǐ]���C�g��Prefab
    public Camera mainCamera;
    public LayerMask clickableLayer; // �N���b�N�\�ȃ��C���[���w��
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
        // �N���b�N�����}�E�X�̈ʒu���擾
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
        // �N���b�N�����}�E�X�̈ʒu���擾
        Ray ray = mainCamera.ScreenPointToRay(Input.mousePosition);
        RaycastHit hit;
        if (create_Coin.Camera_Bool && boll_index && !Panel_controall.Camera_shop_Controller)
        {
            // Raycast���΂��ăN���b�N�����ꏊ���m�F
            if (Physics.Raycast(ray, out hit, Mathf.Infinity, clickableLayer))
            {
                audioSource.PlayOneShot(SE1);
                Debug.Log("�����������G���A");
                // �q�b�g�����ꏊ�̈ʒu�ɃA�C�e���𐶐�
                Vector3 spawnPosition = hit.point;
                Quaternion spawnRotation = Quaternion.identity;

                // �{�[���̐���
                GameObject newBoll = Instantiate(Boll, spawnPosition, spawnRotation);

                // ���C�g�̐����ƒǏ]�ݒ�
                GameObject lightObj = Instantiate(LightPrefab, spawnPosition, spawnRotation);
                lightObj.AddComponent<Light_of_Boll>().target = newBoll.transform;

                // ���C�g�̐����ƒǏ]�ݒ�
                GameObject lightObj_Right = Instantiate(LightPrefab_right, spawnPosition, spawnRotation);
                lightObj.AddComponent<Light_of_Boll>().target = newBoll.transform;

                // ���C�g�̐����ƒǏ]�ݒ�
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
            Debug.Log("15�b�ҋ@");
            boll_count = 0;
        }
    }
}
