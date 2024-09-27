using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[RequireComponent(typeof(AudioSource))]
public class Music : MonoBehaviour
{
    public AudioClip startMusic;
    public AudioClip normalmusic;
    // Start is called before the first frame update
    void Start()
    {

        StartCoroutine(playEngineSound());
    }

    // Update is called once per frame
    void Update()
    {
        
    }
    IEnumerator playEngineSound()
    {
        GetComponent<AudioSource>().clip = startMusic;
        GetComponent<AudioSource>().Play();
        yield return new WaitForSeconds(startMusic.length);
        GetComponent<AudioSource>().clip = normalmusic;
        GetComponent<AudioSource>().Play();
        GetComponent<AudioSource>().loop = true;
    }
}