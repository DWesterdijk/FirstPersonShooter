using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;

public class Player_Score : MonoBehaviour {
    public int score;
    public int kills;
    [SerializeField]
    private int scoreCountDown = 60;
    [SerializeField]
    private Text scoreText;
    private bool isInEndScene = false;
    public static Player_Score Instance
    {
        get;
        set;
    }
	// Use this for initialization
	void Start () {
        DontDestroyOnLoad(transform.gameObject);
        Instance = this;
        score = 100;
        kills = 0;
	}

    IEnumerator HighScore(int score, int kills)
    {
        WWW request = new WWW("http://21598.hosts.ma-cloud.nl/bewijzenmap/tests/php-sql/index.php?name=Player&score=" + score + "&kills=" + kills);
        yield return request;
    }

    // Update is called once per frame
    void Update () {
        if (SceneManager.GetActiveScene() == SceneManager.GetSceneByName("death") && !isInEndScene)
        {
            StartCoroutine(HighScore(score, kills));
            isInEndScene = true;
        }
        scoreCountDown--;
		if (scoreCountDown <= 0)
        {
            score--;
            scoreCountDown = 60;
        }
        scoreText.text = score.ToString();
    }
    public void AddScore(int increase)
    {
        score += increase;
    }
    public void AddKill()
    {
        kills += 1;
    }
}
