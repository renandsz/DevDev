using System;
using System.Collections;
using System.Collections.Generic;
using Patterns;
using Unity.Mathematics;
using UnityEngine;

public class ParticleSpawner : MonoBehaviour
{
    public ParticleSystem loopingParticle;

    public GameObject particlePrefab;

    private void OnEnable()
    {
        SpecialEffectsObserverManager.OnPlayParticle += PlayParticle;
        SpecialEffectsObserverManager.OnStopParticle += StopParticle;
        SpecialEffectsObserverManager.OnSpawnParticle += SpawnParticle;
    }

    private void OnDisable()
    {
        SpecialEffectsObserverManager.OnPlayParticle -= PlayParticle;
        SpecialEffectsObserverManager.OnStopParticle -= StopParticle;
        SpecialEffectsObserverManager.OnSpawnParticle -= SpawnParticle;
    }

    public void PlayParticle()
    {
        if(!loopingParticle.isPlaying)
            loopingParticle.Play();
    }

    public void StopParticle()
    {
        if(loopingParticle.isPlaying)
            loopingParticle.Stop();
    }

    public void SpawnParticle(Vector3 worldpos)
    {
        Instantiate(particlePrefab, worldpos, quaternion.identity);
    }
}
