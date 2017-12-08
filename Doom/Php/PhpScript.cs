using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PhpScript : MonoBehaviour {
    /// <summary>
    /// Scoreboard!
    /// </summary>

    IEnumerator HighScore(int score, int kills)
    {
        WWW request = new WWW("http://21598.hosts.ma-cloud.nl/bewijzenmap/tests/php-sql/index.php?name=player&score=" + score + "&kills=" + kills);
        yield return request;
    }

    IEnumerator DoPHP()
    {
        WWW request = new WWW("http://21598.hosts.ma-cloud.nl/bewijzenmap/tests/php-sql/gpr-fps-db.php?pos=[" + transform.position.x + "," + transform.position.y + "," + transform.position.z + "]&player_id=17");
        yield return request;
    }
}
