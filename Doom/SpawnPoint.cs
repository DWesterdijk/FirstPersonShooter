using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SpawnPoint : MonoBehaviour {
    /// <summary>
    /// This script will move the player to the Spawn Point upon loading the level
    /// </summary>

    [SerializeField]
    private GameObject _player;
	// Use this for initialization
	void Start () {
        _player.transform.forward = gameObject.transform.forward;
        _player.transform.right = gameObject.transform.right;
	}
	
	// Update is called once per frame
	void Update () {
		
	}
}
