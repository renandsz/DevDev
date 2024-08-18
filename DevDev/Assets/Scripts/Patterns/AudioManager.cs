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
        public AudioMixerGroup master;
        

        public AudioMixerSnapshot normalSnapshot,underwaterSnapshot;

        public AudioClip clipPulo, clipAterisar, clipColetavel;

        public AudioSource sfxSource;

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
            AudioObserverManager.ToggleLowpass += AplicarEfeitoLowpass;
            AudioObserverManager.SfxPlayEvent += PlayEfeitoSonoro;
        }

        public void ProcessarMudancaVolume(float valor)
        {
            volume = valor;
            mixer.SetFloat("Volume", volume);
        }

        private void OnDisable()
        {
            AudioObserverManager.OnVolumeChanged -= ProcessarMudancaVolume;
            AudioObserverManager.ToggleLowpass -= AplicarEfeitoLowpass;
            
            AudioObserverManager.SfxPlayEvent -= PlayEfeitoSonoro;
        }

        public void AplicarEfeitoLowpass(bool ligado)
        {
            if (ligado)
            {
                mixer.SetFloat("Lowpass", 2500);
                //mixer.(underwaterSnapshot,1,0);
            }
            else 
            {
                mixer.SetFloat("Lowpass", 22000);
            }
        }

        public void PlayEfeitoSonoro(string clip)
        {
            switch (clip)
            {
                case "pulo":
                    sfxSource.PlayOneShot(clipPulo);
                    break;
                case "aterisar":
                    sfxSource.PlayOneShot(clipAterisar);
                    break;
                case "coletavel":
                    sfxSource.PlayOneShot(clipColetavel);
                    break;
            }
        }
    }
}
