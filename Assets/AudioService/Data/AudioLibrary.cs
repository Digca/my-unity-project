using UnityEngine;


namespace TaxiManiac.AudioSystem
{
    [CreateAssetMenu(menuName = "Sound system/Sound Library")]
    public class AudioLibrary : ScriptableObject
    {
        [SerializeField] private AmbientLibrary _ambientLibrary;
        [SerializeField] private UiSoundsLibrary _uiSoundsLibrary;
        [SerializeField] private SoundsLibrary _soundsLibrary;


        public AmbientLibrary AmbientLibrary => _ambientLibrary;

        public UiSoundsLibrary UiSoundsLibrary => _uiSoundsLibrary;

        public SoundsLibrary SoundsLibrary => _soundsLibrary;
    }
}
