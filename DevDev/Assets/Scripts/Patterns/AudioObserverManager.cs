using System;
using System.Collections;
using System.Collections.Generic;
using Unity.VisualScripting;
using UnityEngine;

namespace Patterns
{
    public static class AudioObserverManager
    {
        public static event Action<float> OnVolumeChanged;

        public static void VolumeChanged(float volume)
        {
            OnVolumeChanged?.Invoke(volume);
        }
    }
}
