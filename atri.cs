using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class atri : MonoBehaviour
{
    public Transform BING;
    public GameObject Coin_prefab;
    public GameObject Boll;
    private float y;
    bool increasing = true; // �p�x�𑝉������邩�ǂ���
    bool increasing1 = true; // �͂𑝉������邩�ǂ���
    bool increasing2 = true; // �́iBoll�j�𑝉������邩�ǂ���
    public Transform spawnPosition;
    public float forceAmount = 5f;   // �R�C���ɉ�����͂̑傫��
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
        float rotationStep = 1f; // ��]��1�t���[��������̕ω���
        float targetRotationY = 0f; // ���݂̉�]�p�x
        while (true)
        {
            // y �� 0 �ȏ� 25 �ȉ��̊Ԃ͊p�x�𑝉�������
            if (increasing)
            {
                if (targetRotationY < 25)
                {
                    targetRotationY += rotationStep; // ��]�p�x�𑝂₷
                }
                else
                {
                    increasing = false; // 25�x�ɒB�����猸���ɐ؂�ւ�
                }
            }
            // y �� -25 �ȏ�̊Ԃ͊p�x������������
            else
            {
                if (targetRotationY > -25)
                {
                    targetRotationY -= rotationStep; // ��]�p�x�����炷
                }
                else
                {
                    increasing = true; // -25�x�ɒB�����瑝���ɐ؂�ւ�
                }
            }

            // Z����X���̉�]���ێ����AY���̉�]�����X�V����
            Quaternion currentRotation = BING.rotation;
            BING.rotation = Quaternion.Euler(currentRotation.eulerAngles.x, targetRotationY, currentRotation.eulerAngles.z);

            // �w�肵���b���҂i�����ł�0.05�b�j
            yield return new WaitForSeconds(0.05f);
        }
    }
    IEnumerator instantCoin()
    {
        while (true)
        {
            if ((clistion.Atri || clostin_.Atri || clostion_200.Atri) && !Panel_controall.Camera_shop_Controller)
            {
                // �R�C���𐶐�����
                Vector3 spawnPosition1 = spawnPosition.position;
                Quaternion spawnRotation = Quaternion.identity; // ��]�͖���]
                GameObject coinInstance = Instantiate(Coin_prefab, spawnPosition1, spawnRotation);

                // Rigidbody���擾
                Rigidbody coinRigidbody = coinInstance.GetComponent<Rigidbody>();
                if (coinRigidbody != null)
                {
                    if (increasing1)
                    {
                        if (forceAmount < 10)
                        {
                            forceAmount++; // Powre�𑝂₷
                        }
                        else
                        {
                            increasing1 = false; // 25�x�ɒB�����猸���ɐ؂�ւ�
                        }
                    }
                    // y �� -25 �ȏ�̊Ԃ͊p�x������������
                    else
                    {
                        if (forceAmount > 2)
                        {
                            forceAmount--; // Powre�����炷
                        }
                        else
                        {
                            increasing1 = true; // -25�x�ɒB�����瑝���ɐ؂�ւ�
                        }
                    }
                    // ������ɗ͂�������
                    coinRigidbody.AddForce(Vector3.left * forceAmount, ForceMode.Impulse);
                }
                // �w�肵���b���҂i�����ł�0.5�b�j
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
                // �R�C���𐶐�����
                Vector3 spawnPosition12 = spawnPosition.position;
                Quaternion spawnRotation1 = Quaternion.identity; // ��]�͖���]
                GameObject BollInstance = Instantiate(Boll, spawnPosition12, spawnRotation1);

                // Rigidbody���擾
                Rigidbody BollRigidbody = BollInstance.GetComponent<Rigidbody>();

                if (BollRigidbody != null)
                {
                    if (increasing2)
                    {
                        if (forceAmount < 10)
                        {
                            forceAmount++; // Powre�𑝂₷
                        }
                        else
                        {
                            increasing2 = false; // 25�x�ɒB�����猸���ɐ؂�ւ�
                        }
                    }
                    // y �� -25 �ȏ�̊Ԃ͊p�x������������
                    else
                    {
                        if (forceAmount > 2)
                        {
                            forceAmount--; // Powre�����炷
                        }
                        else
                        {
                            increasing2 = true; // -25�x�ɒB�����瑝���ɐ؂�ւ�
                        }
                    }
                    // ������ɗ͂�������
                    BollRigidbody.AddForce(Vector3.left * forceAmount, ForceMode.Impulse);
                }
            }
            // �w�肵���b���҂i�����ł�0.5�b�j
            yield return new WaitForSeconds(4.5f);
        }
    }
}
