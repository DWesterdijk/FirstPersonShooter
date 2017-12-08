using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class DoorMove : MonoBehaviour {
    /// <summary>
    /// This script is for the doors.
    /// When you press the action button to
    /// open a door, it opens.
    /// </summary>

    private Key_Behaviour key_Behaviour;
    public bool keyRed = false;
    public bool keyBlue = false;
    public bool keyYellow = false;
    bool opened = false;
    int moveTimer = 0;
    Vector3 position;

	void Update () {
        if (opened)
        {
            if (moveTimer <100)
            {
                Vector3 position = new Vector3();
                position -= this.transform.up / 5;
                this.transform.position += position;
                moveTimer++;
            }
        }
    }
    public void OpenSesame()
    {
        opened = true;
    }
    public void PressCrouton()
    {
        int nextSceneIndex = SceneManager.GetActiveScene().buildIndex + 1;
        SceneManager.LoadScene(nextSceneIndex);
    }
}
