using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SwordDMG : MonoBehaviour {

    public float Damage;

	// Use this for initialization
	void Start () {
		
	}
	
    void OnTriggerEnter(Collider other)
    {
        if(other.tag == "Enemy")
        {
           // Debug.Log("Attempted Damage?");
            Health enemy = other.GetComponent<Health>();
            if (enemy == null) { return; }

            enemy.TakeDamage(Damage);
               
            
        }
    
    }

	// Update is called once per frame
	void Update () {
		
	}
}
