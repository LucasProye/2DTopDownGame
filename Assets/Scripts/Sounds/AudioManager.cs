using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class AudioManager : MonoBehaviour
{
    [SerializeField] private AudioSource _audioSource;
    public static AudioManager _instance { get; private set; }

    private void Awake()
    {
        _instance = this;
    }

    public void PlaySFX(AudioClip clipToPlay)
    {
        _audioSource.PlayOneShot(clipToPlay);
    }
}
