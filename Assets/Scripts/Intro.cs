using System.Collections;
using UnityEngine;
using UnityEngine.Video;

public class Intro : MonoBehaviour
{
    public VideoPlayer player;
    public GameObject image;

    void Start() {
        StartCoroutine(PlayVideo());
    }
    IEnumerator PlayVideo() {
        player.Play();
        yield return new WaitForSeconds(14f);
        gameObject.SetActive(false);
        image.SetActive(false);
        yield return null;
    }
}
