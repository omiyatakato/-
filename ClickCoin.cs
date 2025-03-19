using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ClickCoin : MonoBehaviour
{
    public GameObject itemPrefab; // ��������A�C�e���̃v���n�u
    public Camera mainCamera; // �g�p����J�����i�ʏ��Main Camera�j
    public LayerMask clickableLayer; // �N���b�N�\�ȃ��C���[���w��
    public static int Coin_Click = 0;
    void Start()
    {
        // �J���������ݒ�̏ꍇ�A���C���J�����������I�Ɏg�p
        if (mainCamera == null)
        {
            mainCamera = Camera.main;
        }
    }

    void Update()
    {
        // �}�E�X�̍��N���b�N�����o
        if (Input.GetMouseButtonDown(0))
        {
            SpawnItemAtMousePosition();
        }
    }

    void SpawnItemAtMousePosition()
    {
        if (Coin_Count.Coin_count > 0)
        {
            // �N���b�N�����}�E�X�̈ʒu���擾
            Ray ray = mainCamera.ScreenPointToRay(Input.mousePosition);
            RaycastHit hit;

            // Raycast���΂��ăN���b�N�����ꏊ���m�F
            if (Physics.Raycast(ray, out hit, Mathf.Infinity, clickableLayer))
            {
                Coin_Click++;
                // �q�b�g�����ꏊ�̈ʒu�ɃA�C�e���𐶐�
                Vector3 spawnPosition = hit.point;
                Quaternion spawnRotation = Quaternion.identity;

                // �A�C�e���̐���
                Instantiate(itemPrefab, spawnPosition, spawnRotation);
            }
        }
        
    }
}
