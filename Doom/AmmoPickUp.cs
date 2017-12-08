using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class AmmoPickUp : MonoBehaviour {


	/*void Start ()
    {
        GameObject thePlayer = GameObject.Find("FPS Player");
        Shoot shootScript = thePlayer.GetComponent<Shoot>();
    }*/

    void OnTriggerEnter(Collider other)
    {
        if(other.gameObject.tag == "Player")
        {
            GameObject thePlayer = GameObject.Find("FPS Player");
            Shoot shootScript = thePlayer.GetComponent<Shoot>();
            shootScript.ammoStach += 10;
            Destroy(gameObject);
        }
    }
}
