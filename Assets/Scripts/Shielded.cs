using UnityEngine;
using System.Collections;

public class Shielded : MonoBehaviour {

    public float duration = 10f;
    
    private Animator anim;

    void Start() {
        anim = gameObject.GetComponent<Animator>(); 
    }

	void Update () {
        
        duration -= Time.deltaTime;
        anim.SetFloat("timeout", duration);
        if (duration < 0)
        {
            Destroy(gameObject);
        }
	}
    
    void OnTriggerEnter2D(Collider2D collider)
    {
        Laser _laser = collider.gameObject.GetComponent<Laser>();
        if (_laser)
        {
            _laser.Hit();            
        }
    }
}
