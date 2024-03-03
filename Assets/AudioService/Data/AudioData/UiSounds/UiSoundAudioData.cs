using System;
using UnityEngine;


namespace TaxiManiac.AudioSystem
{
    [Serializable]
    public class UiSoundAudioData : AudioData
    {
        [SerializeField] private UiSoundType _uiSoundType;
        
        
        public UiSoundType UiSoundType => _uiSoundType;
    }
}