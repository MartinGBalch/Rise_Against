using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class hpScript : MonoBehaviour {

    private GameObject player;
    public GameObject chunk;
    float last;
    float now;
    public float diff;
	void Start () {
        diff = 0;
        player = GameObject.FindGameObjectWithTag("Player");
	}
	
	// Update is called once per frame
	void Update () {
        GetComponent<Image>().fillAmount = player.GetComponent<Health>().HealthValue / 50;
        now = player.GetComponent<Health>().HealthValue;
        if (last > now)
        {
            diff = last - now;
            var c = Instantiate(chunk, gameObject.transform);

            float g = GetComponent<RectTransform>().rect.width * GetComponent<Image>().fillAmount;

            Vector3 v = new Vector3(g, 0, 0);
            c.GetComponent<RectTransform>().localPosition = v;

            c.GetComponent<Image>().fillAmount = diff / 50;

            
        }
        else if( last < now)
        {

        }
        last = player.GetComponent<Health>().HealthValue;

    }
}
