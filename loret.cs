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
        float rotationStep = 2f; // ��]��1�t���[��������̕ω���
        float targetRotationY = 0f; // ���݂̉�]�p�x
        while (true)
        {
        targetRotationY -= rotationStep; // ��]�p�x�����炷
        // Z����X���̉�]���ێ����AY���̉�]�����X�V����
        Quaternion currentRotation = BING.rotation;
        BING.rotation = Quaternion.Euler(currentRotation.eulerAngles.x, targetRotationY, currentRotation.eulerAngles.z);

        // �w�肵���b���҂i�����ł�0.05�b�j
        yield return new WaitForSeconds(0.05f);
        }
       
    }
}
