using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class AIDeath : MonoBehaviour
{
    Animator anim;

    void Start()
    {
        anim = GetComponent<Animator>();
    }

    public void OnDeath()
    {
        anim.SetBool("IsWalking", false);
        anim.SetBool("IsDieing", true);
    }
}
