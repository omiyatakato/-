using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Coin_stats : MonoBehaviour
{
    private Rigidbody rb;

    void Start()
    {
        rb = GetComponent<Rigidbody>();

        // �d�̓X�P�[���𒲐� (�f�t�H���g�ł�1.0�A�����ł͋��߂�3.0)
        rb.mass = 1f;  // ���ʂ͂��܂�傫�����Ȃ������ǂ�
        rb.useGravity = true;  // �d�͂�L����
        rb.AddForce(Vector3.down * 9.81f * 20f, ForceMode.Acceleration);  // 20�{�̏d�͂ɑ���
    }
}
