using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class KeepCameraLoaded : MonoBehaviour {

    public static KeepCameraLoaded Instance
    {
        get;
        set;
    }

	void Start () {
        DontDestroyOnLoad(transform.gameObject);
        Instance = this;
    }

	void Update () {
		if (SceneManager.GetActiveScene() == SceneManager.GetSceneByName("death"))
        {
            Destroy(gameObject);
        }
	}
}
