using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Light_of_Boll : MonoBehaviour
{
    public Transform target;
    public Vector3 offset = new Vector3(0, 0, -10); // 追従ライトのオフセット
    public Vector3 offset_naname = new Vector3(0, 5, 5); // 追従ライトのオフセット
    void Update()
    {
        if (target != null)
        {
            // ターゲットの位置にオフセットを加えて追従
            transform.position = target.position + offset;
        }
    }
}
