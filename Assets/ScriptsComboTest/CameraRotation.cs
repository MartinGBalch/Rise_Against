using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CameraRotation : MonoBehaviour {


    public float sensitivty = 1;

	// Use this for initialization
	void Start () {
		
	}
	
	// Update is called once per frame
	void Update ()
    {
        float Horizontal = Input.GetAxis("RightJoystickX");
        float Vertical = Input.GetAxis("RightJoystickY");


        transform.Rotate(0, (Horizontal * sensitivty), 0);

    }
}
