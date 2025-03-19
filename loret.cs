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
        float rotationStep = 2f; // ‰ñ“]‚Ì1ƒtƒŒ[ƒ€‚ ‚½‚è‚Ì•Ï‰»—Ê
        float targetRotationY = 0f; // Œ»İ‚Ì‰ñ“]Šp“x
        while (true)
        {
        targetRotationY -= rotationStep; // ‰ñ“]Šp“x‚ğŒ¸‚ç‚·
        // Z²‚âX²‚Ì‰ñ“]‚ğˆÛ‚µ‚Â‚ÂAY²‚Ì‰ñ“]‚¾‚¯XV‚·‚é
        Quaternion currentRotation = BING.rotation;
        BING.rotation = Quaternion.Euler(currentRotation.eulerAngles.x, targetRotationY, currentRotation.eulerAngles.z);

        // w’è‚µ‚½•b”‘Ò‚Âi‚±‚±‚Å‚Í0.05•bj
        yield return new WaitForSeconds(0.05f);
        }
       
    }
}
