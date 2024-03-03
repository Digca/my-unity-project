using System;
using UnityEngine;


namespace TaxiManiac.AudioSystem
{
    [Serializable]
    public class AmbientAudioData : AudioData
    {
        [SerializeField] private AmbientType _ambientType;


        public AmbientType AmbientType => _ambientType;
    }
}