using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SwordRotations : MonoBehaviour {


    //public Transform target;
    //private Vector3 followOffset;
    //private Vector3 ShieldOffset;

    //public GameObject Thrust; 
    //public GameObject Shield;
    //public GameObject Parent;
     Animator Anim;
    public GameObject Sword;
    public static bool Xatking = false; // are you doing X
    public static bool Yatking = false; // are you doing Y
    //public float rotate = -20;
    public float length = .5f; // Timer for combo
    public float atkspd; // "StartingLength"
    //bool combo = false;
    //public float RightSLashLeft = .5f;
    public bool LeftSlash = false; // are you doing X-X
    public bool YX = false; // are you doing Y-X
    public bool YXX = false; // are you doing Y-X-X
    public static bool XThrust = false; // are you doing X-X-X
    public bool ShieldBash = false; // are you blocking?
    bool reset = false;
 

   public bool Xbutton = false; // Are you doing X
    bool Ybutton = false; // are you doing Y
    public bool Bbutton = false; // are you raising your shield?




    public int ComboState = 0; // How deep in the X combo tree you are
    public int SecondComboState = 0; // How deep in the Y combo tree you are
    public bool XcomboTree = true; // are you in the X combo tree
    public bool YcomboTree = true; // are you in the Y combo tree

    private void Start()
    {
        Anim = gameObject.GetComponent<Animator>();
        atkspd = length;
        
    }



    void LateUpdate()
    {
         Xbutton = Input.GetButtonDown("X"); // X button is pressed
         Ybutton = Input.GetButtonDown("Y"); // Y button is pressed
         Bbutton = Input.GetButton("B"); // B button is pressed


      
        Anim.SetBool("ShieldUp", Bbutton); // set shieldRaise animation

      




    }

    void Update()
    {
        length -= Time.deltaTime;
        

        if(ComboState >3) // ComboState cant go above 3
        {
            ComboState = 3;
        }
        if (SecondComboState > 3)// ComboState cant go above 3
        {
            SecondComboState = 3;
        }


        if(ComboState > 0 || SecondComboState > 0) // turns the collider for the sword on while you are attacking, and off when you are not
        {
            Sword.GetComponent<Collider>().enabled = true;
        }
        else
        {
            Sword.GetComponent<Collider>().enabled = false;
        }



        //if (Input.GetButtonDown("B") && length <= 0 && ShieldBash == false)
        //{
        //    ShieldBash = true;
        //    Anim.SetBool("ShieldUp", ShieldBash);
        //    length = atkspd;
        //}

       
      

        if (Input.GetButtonDown("Y") && SecondComboState <= 1) // ++SecondComboState on Y button press, sets animation
        {
            if (YcomboTree == true) { SecondComboState++; length = atkspd; }
            XcomboTree = false;

            if (SecondComboState == 1 )
            {
                Anim.SetTrigger("Yattack");
            }
           
        }
        if (Input.GetButtonDown("X") && XcomboTree == false) // ++ secondComboState on X button press, sets animation
        {
            if (YcomboTree == true) { SecondComboState++; length = atkspd; }
            XcomboTree = false;
            Debug.Log("Y");
            if (SecondComboState == 2)
            {
                Debug.Log("Y-X ATTACK");
                Anim.SetTrigger("Y-X");
            }
            if (SecondComboState == 3)
            {
                Anim.SetTrigger("Y-X-X");
            }
        }


            //if(SecondComboState > 0)
            //{
            //    YcomboTree = true;
            //}
            //if (ComboState > 0)
            //{
            //    XcomboTree = true;
            //}

            if (Input.GetButtonDown("X")) // ++ComboState on X button press, sets animation
        {
            if (XcomboTree == true) { ComboState++; length = atkspd; ; YcomboTree = false; }
           

           
            //length = atkspd;

            if(ComboState == 1 )
            {
                Anim.SetTrigger("Xattack");
            }
            else if(ComboState == 2 )
            {
                Anim.SetTrigger("X-Xattack");
            }
            else if (ComboState == 3)
            {
                Anim.SetTrigger("X-X-Xattack");
            }
        }
        //if (Anim.GetCurrentAnimatorStateInfo(0).IsName("sword_and_shield_idle")) // Resets comboStates and ComboTree availability once you are in the Idle Animation
        //{
        //    ComboState = 0;
        //    SecondComboState = 0;
        //    length = atkspd;
        //    XcomboTree = true;
        //    YcomboTree = true;
        //}

        if (length <= 0)
        {
            ComboState = 0;
            SecondComboState = 0;
            length = atkspd;
            XcomboTree = true;
            YcomboTree = true;
        }

        //if (Input.GetButtonDown("X") && length <= 0 && Xatking == false && ComboState == 0)
        //{
        //    // X attack
        //    //REDO ALL ANIMATIONS WITH TRIGGERS INSTEAD OF BOOLS
        //    Anim.SetTrigger("Xattack");
        //    Xatking = true;
        //    combo = true;
        //    length = atkspd;
        //    ComboState++;
        //}
        //else if(Input.GetButtonDown("X") && length <= 0 &&  Xatking == true && LeftSlash == false && ComboState == 1)
        //{
        //    // X-X attack
        //    length += 1f;
        //    LeftSlash = true;
        //   // Anim.SetBool("X-Xattack", LeftSlash);
        //    Anim.SetTrigger("X-Xattack");
        //    length = atkspd;
        //    ComboState++;
        //}
        //else if (Input.GetButtonDown("X") && length <= 0  && Xatking == true && LeftSlash == true && XThrust == false && ComboState == 2)
        //{
        //    // X-X-X attack
        //    length += 1f;
        //    Debug.Log("X-X-X");
        //    XThrust = true;
        //    Anim.SetTrigger("X-X-Xattack");
        //    length = atkspd;
        //    ComboState++;
        //}



        //if (Anim.GetCurrentAnimatorStateInfo(0).IsName("sword_and_shield_idle"))
        //{
        //    //timer2 -= Time.deltaTime;
        //    Xatking = false;
        //    Yatking = false;
        //    LeftSlash = false;
        //    XThrust = false;
        //    ShieldBash = false;
        //    ComboState = 0;
        //    reset = true;
        //    combo = false;
        //    YX = false;
        //    YXX = false;
        //}

        //if (length <= 0)
        //{
        //    //timer2 -= Time.deltaTime;
        //    Xatking = false;
        //    Yatking = false;
        //    LeftSlash = false;
        //    // XThrust = false;
        //    ShieldBash = false;

        //    reset = true;
        //    combo = false;
        //    YX = false;
        //    YXX = false;

        //}






        //if (reset == true)
        //{
        //    reset = false;
        //    Thrust.transform.position = target.position + followOffset;
        //    Shield.transform.position = target.position + ShieldOffset;
        //    //Shield.transform.position = target.position + followOffset;
        //    transform.eulerAngles = new Vector3(Parent.transform.eulerAngles.x, Parent.transform.eulerAngles.y, Parent.transform.eulerAngles.z);
        //}





        //        if (ExplosiveATK == true)
        //    {

        //        ExplosiveTimer -= Time.deltaTime;
        //    }
        //    if(ExplosiveTimer <= 0)
        //    {
        //        ExplosiveATK = false;
        //    }
        //}
        // Update is called once per frame
    }
}
