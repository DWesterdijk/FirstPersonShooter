using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class DeathScreen : MonoBehaviour {

    [SerializeField]
    private Text scoreText;
    [SerializeField]
    private Text killsText;
    private Player_Score scores = Player_Score.Instance;

	void Start () {
        scoreText.text = "Score: " + scores.score.ToString();
        killsText.text = "Kills: " + scores.kills.ToString();
	}
	
	// Update is called once per frame
	void Update () {
		
	}
}
