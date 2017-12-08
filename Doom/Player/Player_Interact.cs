using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Player_Interact : MonoBehaviour {
    /// <summary>
    /// This is a secret.
    /// </summary>

    private InputManager inputManager;
    private Key_Behaviour keys;
    // Use this for initialization
    void Start ()
    {
        if (!(inputManager = this.GetComponent<InputManager>()))
        {
            inputManager = this.gameObject.AddComponent<InputManager>();
        }
        keys = GetComponent<Key_Behaviour>();
    }

    // Update is called once per frame
    void Update()
    {
        if (inputManager.Use())
        {
            Vector3 rayOrigin = (Camera.main.ViewportToWorldPoint(new Vector3(0.5f, 0.5f, 0f)));
            RaycastHit hit;
            if (Physics.Raycast(rayOrigin, Camera.main.transform.forward, out hit, 10f))
            {
                DoorMove script = hit.collider.GetComponent<DoorMove>();
                Collider interactable = hit.collider.GetComponent<Collider>();
                if (script != null)
                {
                    if (interactable.tag == "Door_Normal" || interactable.tag == "Door_Secret")
                    {
                        script.OpenSesame();
                    }
                    if (interactable.tag == "Door_Blue" && keys.keyBlue)
                    {
                        script.OpenSesame();
                    }
                    if (interactable.tag == "Door_Red" && keys.keyRed)
                    {
                        script.OpenSesame();
                    }
                    if (interactable.tag == "Door_Yellow" && keys.keyYellow)
                    {
                        script.OpenSesame();
                    }
                    if (interactable.tag == "button")
                    {
                        Debug.Log("Pushed");
                        script.PressCrouton();
                    }
                }
            }
        }
    }
}