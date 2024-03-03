using System;
using UnityEngine;


namespace TaxiManiac.AudioSystem
{
    [Serializable]
    public class SoundAudioData : AudioData
    {
        [SerializeField] private SoundType soundType;


        public SoundType SoundType => soundType;
    }
}