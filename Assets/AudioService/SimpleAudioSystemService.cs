using System;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Audio;


namespace TaxiManiac.AudioSystem
{
    public class SimpleAudioSystemService : AudioSystemService
    {
		private const float DB_MINIMUM = -80f;
		private const float DB_MAXIMUM = 0f;


		[SerializeField] private AudioMixer _audioMixer;
		[SerializeField] private AudioLibrary _audioLibrary;


        public override Dictionary<AmbientType, AudioClip> AmbientsDictionary { get; protected set; }
        public override Dictionary<SoundType, AudioClip> SoundsDictionary { get; protected set; }
        public override Dictionary<UiSoundType, AudioClip> UiSoundsDictionary { get; protected set; }
        

        public override void Initialize()
        {
            AmbientsDictionary = _audioLibrary.AmbientLibrary.GetAmbientDictionary();
            SoundsDictionary = _audioLibrary.SoundsLibrary.GetSoundsDictionary();
            UiSoundsDictionary = _audioLibrary.UiSoundsLibrary.GetUiSoundsDictionary();
            
	        SetVolume(AudioSystemType.Ambient, 1);
	        SetVolume(AudioSystemType.Sounds, 1);
	        SetVolume(AudioSystemType.UISounds, 1);
        }

        public override void SetVolume(AudioSystemType type, float volume)
        {
            if (!isInitialized)
                return;

            if (!_audioMixer.SetFloat(type.ToString(),
                    Mathf.Lerp(DB_MINIMUM, DB_MAXIMUM, volume)))
            {
                Debug.LogError($"Not found {type.ToString()} audio type!");
            }
        }

        public override void SetVolume(AudioSystemType type, bool status)
        {

            if (!isInitialized)
                return;

            float volume;
            if (status)
                volume = DB_MINIMUM;
            else
                volume = DB_MAXIMUM;
            
            if (!_audioMixer.SetFloat(type.ToString(),
                    Mathf.Lerp(DB_MINIMUM, DB_MAXIMUM, volume)))
            {
                Debug.LogError($"Not found {type.ToString()} audio type!");
            }
        }

        public override AudioSource CreateAudioSource(GameObject audioSourceParent, AudioSystemType type)
        {
            AudioSource audioSource = audioSourceParent.AddComponent<AudioSource>();
            audioSource.playOnAwake = false;
            audioSource.outputAudioMixerGroup = GetAudioMixerGroup(type);

            return audioSource;
        }

		public override AudioMixerGroup GetAudioMixerGroup(AudioSystemType type)
        {
            return _audioMixer.FindMatchingGroups(type.ToString())[0];
        }
        
    }
}
