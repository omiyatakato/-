using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Light_of_Boll : MonoBehaviour
{
    public Transform target;
    public Vector3 offset = new Vector3(0, 0, -10); // �Ǐ]���C�g�̃I�t�Z�b�g
    public Vector3 offset_naname = new Vector3(0, 5, 5); // �Ǐ]���C�g�̃I�t�Z�b�g
    void Update()
    {
        if (target != null)
        {
            // �^�[�Q�b�g�̈ʒu�ɃI�t�Z�b�g�������ĒǏ]
            transform.position = target.position + offset;
        }
    }
}
