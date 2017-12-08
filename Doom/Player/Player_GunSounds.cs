using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Player_GunSounds : MonoBehaviour
{
    /// <summary>
    /// This script will play a given sound when it's function is called
    /// </summary>
    public void GunSound(AudioSource sound)
    {
        sound.Play();
    }
}
