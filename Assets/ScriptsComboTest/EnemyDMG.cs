using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemyDMG : MonoBehaviour {

    public float Damage;
    public GameObject Body;
    AIController controller;
    // Use this for initialization
    void Start()
    {
        controller = Body.GetComponent<AIController>();
    }

    void OnTriggerEnter(Collider other)
    {
        if (other.tag == "Player" && controller.IsAttacking == true)
        {
            Debug.Log("Attempted Damage?");
            Health player = other.GetComponent<Health>();
            if (player == null) { return; }
           bool CanDealDmg = other.GetComponent<SwordRotations>().Bbutton;

            if (CanDealDmg == false) { player.TakeDamage(Damage); }
            if (CanDealDmg == true) { player.StaminaDrain(Damage); }


        }

    }

    // Update is called once per frame
    void Update () {
		
	}
}
