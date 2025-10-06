using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;

/// <summary>
/// ‘Ì—Í‚Ì•\¦
/// </summary>
public class LifeBase : MonoBehaviour
{
	[SerializeField] private TextMeshProUGUI _lifeText;

	/// <summary>
	/// ‘Ì—Í‚ğ‘‚«Š·‚¦‚é
	/// </summary>
	/// <param name="life"></param>
    public void SetLife(int life)
	{
		_lifeText.text = "LIFE:" + life;
	}
}
