using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Health : MonoBehaviour, IDamageable, IHealable, IStaminable
{

    public float HealthValue;
    private float startingHealth;
    public float ArmorValue;
    private float startingArmor;
    public float healingMultiplier;
    public float StaminaValue;
    
    public float StaminaBS;


    Animator Anim;
    
    public Health(float startingHealth, float startingArmor)
    {
        HealthValue = startingHealth;
        ArmorValue = startingHealth;
    }

    public float EstimatedDamageTaken(float damageDealt)
    {
        return damageDealt -= ArmorValue;
    }
   public void TakeDamage(float damageDealt)
    {
        float dmg = EstimatedDamageTaken(damageDealt);
        if(dmg <= 0) { return; }

        HealthValue -= dmg;
    }

    public float EstimatedHealingReceived(float healing)
    {
        return healing * healingMultiplier;
    }
    public void TakeHealing(float healing)
    {
        HealthValue += EstimatedHealingReceived(healing);
    }

    public float EstimatedStaminaDrain(float StaminaDrainage)
    {
        return StaminaDrainage *= StaminaBS;
    }


    public void StaminaDrain(float StaminaDrainage)
    {
        StaminaValue -= EstimatedStaminaDrain(StaminaDrainage);
    }


    // Use this for initialization
    void Start ()
    {
        Anim = GetComponent<Animator>();
        startingHealth = HealthValue;
        startingArmor = ArmorValue;
	}
	void Death()
    {
        Anim.SetTrigger("IsDead");
       
          //  DestroyObject(gameObject);
        
        
    }
	// Update is called once per frame
	void LateUpdate ()
    {
		if (HealthValue <= 0)
        {
            Death();
        }
	}
}
