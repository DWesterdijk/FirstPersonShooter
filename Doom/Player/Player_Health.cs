using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;

public class Player_Health : MonoBehaviour {
    /// <summary>
    /// This script initializes and updates the player health
    /// </summary>
    public int health = 10;
    [SerializeField]
    public Text healthText;

    void Update()
    {
        healthText.text = (10*health).ToString() + " %";
    }
    public void GetHurt()
    {
        health -= 1;
        if (health <= 0)
        {
            SceneManager.LoadScene("death");
        }
    }

    private void OnTriggerEnter(Collider other)
    {
        if (other.tag == "EnemyBullet")
        {
            GetHurt();
        }
    }
}