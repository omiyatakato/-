using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
public class Panel_controall : MonoBehaviour
{
    [SerializeField] GameObject KeihinPanel;
    [SerializeField] GameObject ShipPanel;
    public static bool  Camera_shop_Controller;
    void Update()
    {
        if (Camera_shop_Controller)
        {
            // カメラをターゲットの位置に追従させる
            Vector3 targetPosition = new Vector3(255, 650f, -650f);

            // 緩やかにターゲットに近づく（線形補間）
            Camera.main.transform.position = Vector3.Lerp(Camera.main.transform.position, targetPosition, 5 * Time.deltaTime);
        }
    }
         
    public void PanelOn()
    {
        KeihinPanel.SetActive(true);
        ShipPanel.SetActive(false);
        Camera_shop_Controller = true;
    }
    public void PanelOff()
    {
        KeihinPanel.SetActive(false);
        ShipPanel.SetActive(true);
        Camera_shop_Controller = false;
    }
}
