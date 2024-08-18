using System;
using UnityEngine;
using UnityEngine.UI;

namespace Patterns
{
    public class VolumeBarController : MonoBehaviour
    {
        [SerializeField] private Slider volumeSlider;
        [SerializeField] private Toggle toggle;

        private void Awake()
        {
            TryGetComponent(out volumeSlider);
            TryGetComponent(out toggle);
        }

        private void Start()
        {
           // volumeSlider.onValueChanged.AddListener(OnVolumeSliderChanged);
        }

        public void OnVolumeSliderChanged(float volume)
        {
            AudioObserverManager.VolumeChanged(DenormalizeVolume(volume));
        }

        //arrastar isso para o componente de slider
        /*public void OnVolumeChanged(float value)
        {
            AudioManager.instance.ProcessarMudancaVolume(value);
        }
        */

        float NormalizarVolume(float volume)
        {
            float minVolume = -80f;
            float maxVolume = 6f;
            float result = (volume - minVolume) / (maxVolume - minVolume);
            return result;
        }
        
        float DenormalizeVolume(float normalizedVolume)
        {
            if (normalizedVolume <= 0.5f)
            {
                // Desnormalizar de 0 a 0.5 para -80 a -6
                return normalizedVolume * (-6 - (-80)) / 0.5f + (-80);
            }
            else
            {
                // Desnormalizar de 0.5 a 1 para -6 a 6
                return (normalizedVolume - 0.5f) * (6 - (-6)) / 0.5f + (-6);
            }
            
        }

        public void ToggleLowpass(bool lowpass)
        {
            //AudioObserverManager.OnToggleLowpass(lowpass);
            AudioObserverManager.OnUnderwaterSnapshotEvent(lowpass);
        }

    }
}
