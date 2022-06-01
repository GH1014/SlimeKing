using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Sound_Camera : MonoBehaviour
{
    // Start is called before the first frame update

    public Camera cam;
    public GameObject player;

    public AudioClip[] BackgroundAudio;

    AudioSource AudioSource;

    void Start()
    {
        AudioSource = GetComponent<AudioSource>();
    }

    // Update is called once per frame
    void Update()
    {
        //카메라 위치 변경과 그에 따른 배경음 변경
        if (player.transform.position.y < 5)
        {
            cam.transform.position = new Vector3(0, 0, -10);
            AudioChange(BackgroundAudio[0], AudioSource);
        }
        else if (player.transform.position.y < 15)
        {
            cam.transform.position = new Vector3(0, 10, -10);
            AudioChange(BackgroundAudio[0], AudioSource);
        }
        else if (player.transform.position.y < 25)
        {
            cam.transform.position = new Vector3(0, 20, -10);
            AudioChange(BackgroundAudio[1], AudioSource);
        }
        else if (player.transform.position.y < 35)
        {
            cam.transform.position = new Vector3(0, 30, -10);
            AudioChange(BackgroundAudio[1], AudioSource);
        }
        else if (player.transform.position.y < 45)
        {
            cam.transform.position = new Vector3(0, 40, -10);
            AudioChange(BackgroundAudio[2], AudioSource);
        }
        else if (player.transform.position.y < 55)
        {
            cam.transform.position = new Vector3(0, 50, -10);
            AudioChange(BackgroundAudio[2], AudioSource);
        }
        else if (player.transform.position.y < 65)
        {
            cam.transform.position = new Vector3(0, 60, -10);
            AudioChange(BackgroundAudio[2], AudioSource);
        }
        else if (player.transform.position.y < 75)
        {
            cam.transform.position = new Vector3(0, 70, -10);
            AudioChange(BackgroundAudio[3], AudioSource);
        }
        else if (player.transform.position.y < 85)
        {
            cam.transform.position = new Vector3(0, 80, -10);
            AudioChange(BackgroundAudio[3], AudioSource);
        }
        else if (transform.position.y < 95)
        {
            cam.transform.position = new Vector3(0, 90, -10);
            AudioChange(BackgroundAudio[3], AudioSource);
        }
    }

    //배경음 변경
    void AudioChange(AudioClip audioClip, AudioSource audioSource)
    {
        if (audioClip != audioSource.clip)
        {
            audioSource.clip = audioClip;
            audioSource.Play();
        }

    }

    //배경음 볼륨 조절
    public void SetMusicVolume(float volume)
    {
        AudioSource.volume = volume;
    }
}
