using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Key_Rotation : MonoBehaviour
{
    /// <summary>
    /// This script will make the keys rotate towards the player
    /// </summary>
    private Transform player;

    void Start()
    {
        player = GameObject.FindGameObjectWithTag("Player").transform;
    }

    void Update()
    {
        transform.LookAt(player);
    }
}