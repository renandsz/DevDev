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
        public static event Action<bool> ToggleLowpass;

        public static event Action<bool> UnderwaterSnapshotEvent;

        public static event Action<string> SfxPlayEvent;


        public static void VolumeChanged(float volume)
        {
            OnVolumeChanged?.Invoke(volume);
        }

        public static void OnToggleLowpass(bool lowpass)
        {
            ToggleLowpass?.Invoke(lowpass);
        }

        public static void OnUnderwaterSnapshotEvent(bool obj)
        {
            UnderwaterSnapshotEvent?.Invoke(obj);
        }

        public static void OnSfxPlayEvent(string obj)
        {
            SfxPlayEvent?.Invoke(obj);
        }
    }
}
