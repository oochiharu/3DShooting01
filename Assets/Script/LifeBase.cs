using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;

/// <summary>
/// �̗͂̕\��
/// </summary>
public class LifeBase : MonoBehaviour
{
	[SerializeField] private TextMeshProUGUI _lifeText;

	/// <summary>
	/// �̗͂�����������
	/// </summary>
	/// <param name="life"></param>
    public void SetLife(int life)
	{
		_lifeText.text = "LIFE:" + life;
	}
}
