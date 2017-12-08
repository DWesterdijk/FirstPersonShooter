using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CameraSelector : MonoBehaviour {
    /// <summary>
    /// This script switches between Camera's
    /// for the main screen and the map.
    /// </summary>
    [SerializeField]
    private Camera _cam;
    [SerializeField]
    private Canvas _radar;
    private InputManager _inputManager;
	// Use this for initialization
	void Start () {
        if (!(_inputManager = this.GetComponent<InputManager>()))
        {
            _inputManager = this.gameObject.AddComponent<InputManager>();
        }
        _cam.enabled = false;
        _radar.enabled = true;
	}
	
	// Update is called once per frame
	void Update () {
        if (_inputManager.ChangeCamera())
        {
            _cam.enabled = !_cam.enabled;
            _radar.enabled = !_radar.enabled;
        }
	}
}
