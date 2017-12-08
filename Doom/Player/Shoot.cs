using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class Shoot : MonoBehaviour
{
    /// <summary>
    /// This is so the player can shoot.
    /// This also registers every shot in the database
    /// </summary>
    public GameObject bullet;
    public Transform gun;
    private InputManager inputManager;
    private float ammoReloadAmount = 10;
    public float ammoStach = 30;
    private float currentAmmo = 10;
    private float ammoMax = 10;
    private float ammoBackUp;
    [SerializeField]
    private Text ammo;
    private int enemy = 0;
    [SerializeField]
    private AudioSource shootSound;
    [SerializeField]
    private AudioSource reloadSound;
    [SerializeField]
    private AudioSource emptySound;
    private Player_GunSounds sounds;


    void Start()
    {
        if (!(inputManager = this.GetComponent<InputManager>()))
        {
            inputManager = this.gameObject.AddComponent<InputManager>();
        }
        sounds = this.gameObject.GetComponent<Player_GunSounds>();
    }
    void Update()
    {
        ammo.text = currentAmmo.ToString() + "/" + ammoStach.ToString();
        if (inputManager.ShootBullet())
        {
            Vector3 rayOrigin = (Camera.main.ViewportToWorldPoint(new Vector3(0.5f, 0.5f, 0f)));
            RaycastHit hit;
            if (Physics.Raycast(rayOrigin, Camera.main.transform.forward, out hit) && currentAmmo >= 1)
            {

                Enemy_Health Enemy = hit.collider.GetComponent<Enemy_Health>();
                if (Enemy != null)
                {
                    Enemy.Damage();
                    if (Enemy.currentHealth == 0)
                    {
                        Player_Score score = this.GetComponent<Player_Score>();
                        score.AddScore(100);
                        score.AddKill();
                        enemy = 1;
                    }
                }
                else
                {
                    enemy = 0;
                }
                Instantiate(bullet, gun.position, gun.rotation);
                currentAmmo -= 1;
                sounds.GunSound(shootSound);
                Vector3 vec = new Vector3();
                vec.x = Mathf.Round(hit.point.x);
                vec.y = Mathf.Round(hit.point.y);
                vec.z = Mathf.Round(hit.point.z);
                StartCoroutine(HitLog(vec, enemy));
            }
            else if (currentAmmo <= 0)
            {
                sounds.GunSound(emptySound);
            }
        }
        Reloader();
    }

    IEnumerator HitLog(Vector3 vec, int enemy)
    {
        WWW request = new WWW("http://21598.hosts.ma-cloud.nl/bewijzenmap/tests/php-sql/gpr-fps-db.php?pos=[" + vec.x + "," + vec.y + "," + vec.z +"]&enemy_hit=" + enemy + "&player_id=1");
        yield return request;
    }

    void Reloader()
    {
        /// <summary>
        /// This function will reload your bullets back to 10.
        /// </summary>

        if (inputManager.Reload() && ammoStach >= 1 && currentAmmo <= 9)
        {
            ammoReloadAmount -= currentAmmo;
            if (ammoReloadAmount >= ammoStach)
            {  
                ammoReloadAmount = ammoStach;
                if (currentAmmo > ammoMax)
                {
                    ammoBackUp = currentAmmo;
                    ammoBackUp -= ammoMax;
                    currentAmmo -= ammoBackUp;
                    ammoStach += ammoBackUp;
                    ammoBackUp = 10;
                }
                Debug.Log(ammoReloadAmount);
            }           
            ammoStach -= ammoReloadAmount;
            currentAmmo += ammoReloadAmount;
            ammoReloadAmount = 10;
            sounds.GunSound(reloadSound);
        }
    }
}


