using UnityEngine;
using UnityEngine.UI;

namespace Patterns
{
    public class ExplodeButtonController : MonoBehaviour
    {
        private Button button;
        private bool toggle = false;
        public Vector3 spawnPos;

        public void ToggleParticle()
        {
            toggle = !toggle;
            if (toggle)
            {
                SpecialEffectsObserverManager.PlayParticle();
            }
            else
            {
                SpecialEffectsObserverManager.StopParticle();
            }
        }

        public void Explode()
        {
            SpecialEffectsObserverManager.SpawnParticle(spawnPos);
        }
    }
}
