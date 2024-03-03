using System;
using UnityEngine;
using UnityEngine.Serialization;

namespace TaxiManiac.AudioSystem
{
    [Serializable]
    public abstract class AudioData
    {
        [SerializeField] private AudioClip audioClip;


        public AudioClip AudioClip => audioClip;
    }
}