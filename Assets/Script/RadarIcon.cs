using System.Collections;
using System.Collections.Generic;
using UnityEngine;

/// <summary>
/// レーダー用のアイコン角度調整
/// </summary>

public class RadarIcon : MonoBehaviour
{


    // Update is called once per frame
    void Update()
    {
        //親オブジェクトの角度
        Vector3 parentAngle = transform.parent.transform.localRotation.eulerAngles;
        //角度修正
        gameObject.transform.rotation = Quaternion.Euler(90, parentAngle.y, parentAngle.z);
    }
}
