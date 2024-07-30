using System;
using UnityEngine;

namespace Patterns
{
    public static class SpecialEffectsObserverManager
    {
        public static event Action OnPlayParticle,OnStopParticle;
        public static event Action<Vector3> OnSpawnParticle;

        public static void PlayParticle()
        {
            OnPlayParticle?.Invoke();
        }

        public static void StopParticle()
        {
            OnStopParticle?.Invoke();
        }

        public static void SpawnParticle(Vector3 obj)
        {
            OnSpawnParticle?.Invoke(obj);
        }
    }
}
