using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class AudioManager : MonoBehaviour
{

    public AudioSource Audio;

    public void PlaySound(AudioClip Sound)
    {
        Audio.PlayOneShot(Sound);
    }
}
