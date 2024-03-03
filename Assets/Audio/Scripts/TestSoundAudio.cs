using System.Collections;
using System.Collections.Generic;
using TaxiManiac.AudioSystem;
using UnityEngine;

public class TestSoundAudio : MonoBehaviour
{
    [SerializeField] private AudioSource _audioSource;
    [SerializeField] private SoundType _soundType;
    

    public void PlaySound()
    {
        AudioClip sound = AudioSystemService.audioSystemServiceInstance.SoundsDictionary[_soundType];
        _audioSource.clip = sound;
        _audioSource.Play();
        
    }

    public void SetAudioOn()
    {
        AudioSystemService.audioSystemServiceInstance.SetVolume(AudioSystemType.Sounds, true);
    }

    public void SetAudioOff()
    {
        AudioSystemService.audioSystemServiceInstance.SetVolume(AudioSystemType.Sounds, false);
    }
}
