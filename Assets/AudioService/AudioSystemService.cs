using System;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Audio;


namespace TaxiManiac.AudioSystem
{
    public abstract class AudioSystemService : MonoBehaviour, IAudioSystemService
    {
        public static AudioSystemService audioSystemServiceInstance;
        protected bool isInitialized = false;
        public abstract Dictionary<AmbientType, AudioClip> AmbientsDictionary { get; protected set; }
        public abstract Dictionary<SoundType, AudioClip> SoundsDictionary { get; protected set; }
        public abstract Dictionary<UiSoundType, AudioClip> UiSoundsDictionary { get; protected set; }
        
        
        public abstract void Initialize();
        
        public abstract void SetVolume(AudioSystemType type, float volume);

        public abstract void SetVolume(AudioSystemType type, bool status);

        public abstract AudioMixerGroup GetAudioMixerGroup(AudioSystemType type);

        public abstract AudioSource CreateAudioSource(GameObject audioSourceParent, AudioSystemType type);

        public void Awake()
        {
            if (audioSystemServiceInstance == null)
            {
                audioSystemServiceInstance = this;
                DontDestroyOnLoad(this);
                Initialize();
            }
            else
            {
                Destroy(this);
            }
        }
    }
}