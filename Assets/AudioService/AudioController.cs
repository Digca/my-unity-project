using System.Collections.Generic;
using UnityEngine;

namespace TaxiManiac.AudioSystem
{
	public class AudioController
	{
		private readonly Dictionary<AudioClip, AudioSource> loopedAudioSources;
		private AudioSource audioSource = default;
		

		public AudioController(AudioSource audioSource)
		{
			this.audioSource = audioSource;

			loopedAudioSources = new Dictionary<AudioClip, AudioSource>();
		}


		public void PlaySound(AudioClip clip, bool loop = false)
		{
			if (audioSource == null || clip == null)
				return;

			audioSource.clip = clip;
			audioSource.loop = loop;
			audioSource.Play();
		}

		public void PlayOneShotSound(AudioClip clip)
		{
			if (audioSource == null || clip == null)
				return;

			audioSource.PlayOneShot(clip);
		}

		public void PlayLoopedSound(AudioClip clip)
		{
			if (audioSource == null || clip == null)
				return;

			if (loopedAudioSources.ContainsKey(clip))
			{
				Debug.LogError($"Attempt to start play looped sound {clip.name} when it already played");
				return;
			}

			AudioSource newLoopedAudioSource = audioSource.gameObject.AddComponent<AudioSource>();

			newLoopedAudioSource.outputAudioMixerGroup = audioSource.outputAudioMixerGroup;
			newLoopedAudioSource.clip = clip;
			newLoopedAudioSource.loop = true;
			newLoopedAudioSource.Play();

			loopedAudioSources.Add(clip, newLoopedAudioSource);
		}

		public void StopLoopedSound(AudioClip clip)
		{
			if (audioSource == null || clip == null)
				return;

			if (!loopedAudioSources.TryGetValue(clip, out AudioSource loopedAudioSource))
				return;

			loopedAudioSource.Stop();
			Object.Destroy(loopedAudioSource);
			loopedAudioSources.Remove(clip);
		}

		public void StopSound()
		{
			if (audioSource == null)
				return;

			audioSource.Stop();
		}
	}
}
