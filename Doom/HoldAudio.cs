using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class HoldAudio : MonoBehaviour {

    public static HoldAudio Instance
    {
        get;
        set;
    }

    void Start()
    {
        DontDestroyOnLoad(gameObject);
        Instance = this;
    }
    
    void Update()
    {
        if (SceneManager.GetSceneByName("main") == SceneManager.GetActiveScene())
        {
            Destroy(gameObject);
        }
    }

}
