using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class hpChunkScript : MonoBehaviour {

    public float timer;
	void Start () {
        timer = 0;
      }
	
	// Update is called once per frame
	void Update () {
        timer += Time.deltaTime;
        transform.position += new Vector3(timer/4, timer*4, 0);
        GetComponent<Image>().color -= new Color(timer / 3, timer / 3, timer / 3, timer / 6);
        if (timer > 1.2f)
        {
            Destroy(gameObject);
        }
	}
}
