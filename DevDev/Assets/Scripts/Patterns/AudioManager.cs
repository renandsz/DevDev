using System;
using Unity.Collections;
using UnityEngine;
using UnityEngine.Audio;

namespace Patterns
{
    public class AudioManager : MonoBehaviour
    {
        [SerializeField] private float volume = 1f;
            
        public static AudioManager instance;

        public AudioMixer mixer;

        private void Awake()
        {
            if (instance == null)
            {
                instance = this;
                DontDestroyOnLoad(gameObject);
            }
            else
            {
                Destroy(gameObject);
            }
        }

        private void OnEnable()
        {
            AudioObserverManager.OnVolumeChanged += ProcessarMudancaVolume;
        }

        public void ProcessarMudancaVolume(float valor)
        {
            volume = valor;
            mixer.SetFloat("Volume", volume);
        }

        private void OnDisable()
        {
            AudioObserverManager.OnVolumeChanged -= ProcessarMudancaVolume;
        }
    }
}
