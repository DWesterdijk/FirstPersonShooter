using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class Key_Behaviour : MonoBehaviour
{
    /// <summary>
    /// This script will check if a player picks up a key, and destroys the key on pickup
    /// </summary>
    public bool keyBlue = false;
    public bool keyRed = false;
    public bool keyYellow = false;
    [SerializeField]
    private RawImage blu;
    [SerializeField]
    private RawImage ylw;
    [SerializeField]
    private RawImage red;

    void Start()
    {
        blu.enabled = false;
        ylw.enabled = false;
        red.enabled = false;
    }

    void OnTriggerEnter(Collider other)
    {
        if (other.tag == "key_blue")
        {
            Debug.Log("Key Picked up");
            keyBlue = true;
            blu.enabled = true;
            Destroy(other.gameObject);
        }
        if (other.tag == "key_yellow")
        {
            Debug.Log("Key Picked up");
            keyYellow = true;
            ylw.enabled = true;
            Destroy(other.gameObject);
        }
        if (other.tag == "key_red")
        {
            Debug.Log("Key Picked up");
            keyRed = true;
            red.enabled = true;
            Destroy(other.gameObject);
        }
    }
}