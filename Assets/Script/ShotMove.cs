using System.Collections;
using System.Collections.Generic;
using UnityEngine;

/// <summary>
/// ’eŠÛ‚Ìˆ—
/// </summary>
public class ShotMove : MonoBehaviour
{
    /// <summary>
    /// ËŒ‚‚Ì¶‘¶ŠÔ
    /// </summary>
    private float _shotLifeTimer = 2.0f;
    
    //@‰‰ñ‚ÅŒÄ‚Î‚ê‚é
    void Start()
    {
        
    }

    //–ˆ‰ñŒÄ‚Î‚ê‚é
    void Update()
    {
        //•b”‚ğŒ¸‚ç‚·
        _shotLifeTimer -= Time.deltaTime;
        //¶‘¶ŠÔ‚ª‚È‚¢‚È‚ç
        if (_shotLifeTimer <= 0)
		{
            //Object‚ªíœ‚³‚ê‚é
            Destroy(gameObject);
		}
    }

    /// <summary>
    /// ‰½‚©‚É‚Ô‚Â‚©‚Á‚½‚çŒÄ‚Ño‚³‚ê‚éˆ—
    /// </summary>
    /// <param name="other"></param>
	private void OnTriggerEnter(Collider other)
    {
        if (other.tag == "Enemy")
        {
            //Object‚ªíœ‚³‚ê‚é
            Destroy(gameObject);
        }

    }
}
