using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Coin_stats : MonoBehaviour
{
    private Rigidbody rb;

    void Start()
    {
        rb = GetComponent<Rigidbody>();

        // 重力スケールを調整 (デフォルトでは1.0、ここでは強めに3.0)
        rb.mass = 1f;  // 質量はあまり大きくしない方が良い
        rb.useGravity = true;  // 重力を有効に
        rb.AddForce(Vector3.down * 9.81f * 20f, ForceMode.Acceleration);  // 20倍の重力に相当
    }
}
