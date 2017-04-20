using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.AI;

public class Movement : MonoBehaviour {

    Rigidbody rb;
    public float speed = 50;
    public float RotSpeed = 2;
     Animator anim;
    Health health;
    public float dodge;
    public float DodgeCD;
    private float StartDodgeCD;
    public float StaminaDrainage;

    //public static int Health = 100;
    //int Run = Animator.StringToHash("Walk");
    //int Stand = Animator.StringToHash("Stand");


    //float bombTimer = 2.4f;
    //bool BombEffect = false;
    void Start ()
    {
        health = GetComponent<Health>();
        anim = GetComponent<Animator>();
        rb = gameObject.GetComponent<Rigidbody>();
        StartDodgeCD = DodgeCD;
    }

    // Update is called once per frame
    void Update()
    {
        DodgeCD -= Time.deltaTime;
        float horizontal = Input.GetAxis("LeftJoystickX");
        float vertical = Input.GetAxis("LeftJoystickY");
        float Rotation = Input.GetAxis("RightJoystickX");


        Vector2 delta = new Vector2(horizontal, vertical);

        if (health.HealthValue > 0)
        {
            rb.AddForce(transform.forward * -vertical * speed);
            rb.AddForce(transform.right * horizontal * speed);
            anim.SetFloat("Vertical", vertical);
            anim.SetFloat("Horizontal", horizontal);
            transform.Rotate(0, Rotation * RotSpeed, 0);
        }



        if (Input.GetButtonDown("A") && DodgeCD <= 0)
        {
            gameObject.GetComponent<Health>().StaminaDrain(StaminaDrainage);
            DodgeCD = StartDodgeCD;
            rb.AddForce(rb.velocity * dodge);
            if (rb.velocity == new Vector3(0, 0, 0)) { rb.AddForce(transform.forward * dodge); }
        }
    }

  

        //if(horizontal != 0 || vertical != 0)
        //{
        //    anim.SetTrigger(Run);
        //}
        //else
        //{
        //    anim.SetTrigger(Stand);
        //}



    
}
