using System.Collections;
using System.Collections.Generic;
using UnityEngine;

/// <summary>
/// ���[�_�[�p�̃A�C�R���p�x����
/// </summary>

public class RadarIcon : MonoBehaviour
{


    // Update is called once per frame
    void Update()
    {
        //�e�I�u�W�F�N�g�̊p�x
        Vector3 parentAngle = transform.parent.transform.localRotation.eulerAngles;
        //�p�x�C��
        gameObject.transform.rotation = Quaternion.Euler(90, parentAngle.y, parentAngle.z);
    }
}
