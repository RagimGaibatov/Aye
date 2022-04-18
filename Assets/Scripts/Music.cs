using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Music : MonoBehaviour
{
    [SerializeField] private AudioSource playerAudio;

    [SerializeField] private AudioClip[] songs;

    // Start is called before the first frame update
    void Start()
    {
        playerAudio.PlayOneShot(songs[Random.Range(0, songs.Length)], 0.8f);
    }

    // Update is called once per frame
    void Update()
    {
    }
}