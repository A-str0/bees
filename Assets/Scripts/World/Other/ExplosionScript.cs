using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ExplosionScript : MonoBehaviour
{
    public AudioSource sound;
    private void Awake() {
        sound.pitch = Random.RandomRange(1.1f, 1.3f);
        sound.Play();
    }
}
