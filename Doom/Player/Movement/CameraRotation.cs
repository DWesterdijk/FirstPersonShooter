
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CameraRotation : MonoBehaviour
{
    /// <summary>
    /// This is a messy script for Camera rotation.
    /// We turned off the possibility to look up and down
    /// as that was affecting the player, at that point
    /// we decided to make a Doom-like game.
    /// </summary>
    public enum RotationAxes { MouseXAndY = 0, MouseX = 1, MouseY = 2 }
    public RotationAxes axes = RotationAxes.MouseXAndY;
    public float sensitivityY = 15F;
    public float sensitivityX = 15F;
    public float minimumX = -360F;
    public float maximumX = 360F;
    public float minimumY = -60F;
    public float maximumY = 60F;
    float rotationY = 0F;

    //private GameObject cameraObject;
    //private GameObject playerObject;
    private InputManager inputManager;

    void Start()
    {
        Cursor.lockState = CursorLockMode.Locked;
        //cameraObject = Camera.main.gameObject;
        //playerObject = GameObject.FindGameObjectWithTag("Player");
        //check if the inputmanager is present. If it's not, add it.
        if (!(inputManager = this.GetComponent<InputManager>()))
        {
            inputManager = this.gameObject.AddComponent<InputManager>();
        }
    }

    void Update()
    {
        if (axes == RotationAxes.MouseXAndY)
        {
            float rotationX = transform.localEulerAngles.y + inputManager.GetXRot() * sensitivityX;

            //rotationY -= inputManager.GetYRot() * sensitivityY;
            //rotationY = Mathf.Clamp(rotationY, minimumY, maximumY);

            transform.localEulerAngles = new Vector3(-rotationY, rotationX, 0);
        }
        //else if (axes == RotationAxes.MouseX)
        //{
        //    transform.Rotate(0, inputManager.GetYRot() * sensitivityY, 0);
        //}
        //else
        //{
        //    rotationY += inputManager.GetYRot() * sensitivityY;
        //    rotationY = Mathf.Clamp(rotationY, minimumY, maximumY);
        //
        //    transform.localEulerAngles = new Vector3(-rotationY, transform.localEulerAngles.y, 0);
        //}
        if (inputManager.RotateLeft())
        {
            transform.Rotate(0, -3, 0);
        }
        if (inputManager.RotateRight())
        {
            transform.Rotate(0, 3, 0);
        }

        if (inputManager.MouseLock())// && inputManager.MouseLock() == true)
        {
            Cursor.lockState = CursorLockMode.None;
        }
        //else if(inputManager.MouseLock() == false)
        //{
        //    Cursor.lockState = CursorLockMode.Locked;
        //}
    }
}

/*
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CameraRotation : MonoBehaviour {

    private GameObject cameraObject;
    private InputManager inputManager;

    [SerializeField]
    private float cameraSpeed = 5;


    void Start(){
        cameraObject = Camera.main.gameObject;
        //check if the inputmanager is present. If it's not, add it.
        if(!(inputManager = this.GetComponent<InputManager>())){
            inputManager = this.gameObject.AddComponent<InputManager>();
        }
    }

	void Update () {
        //rotate the entire gameobject
        this.transform.Rotate(0, inputManager.GetXRot()* cameraSpeed, 0);
        //rotate the camera only. 
		cameraObject.transform.Rotate(inputManager.GetYRot() * cameraSpeed, 0, 0);
	}
}
*/
