using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class HealthPickUp : MonoBehaviour {

    void OnTriggerEnter(Collider other)
    {
        if (other.gameObject.tag == "Player")
        {
            GameObject thePlayer = GameObject.Find("FPS Player");
            Player_Health healthScript = thePlayer.GetComponent<Player_Health>();
            if(healthScript.health <= 9)
            {
                healthScript.health += 2;
                Destroy(gameObject);

                if (healthScript.health > 10)
                {
                    healthScript.health = 10;
                }
            }
        }
    }
}
