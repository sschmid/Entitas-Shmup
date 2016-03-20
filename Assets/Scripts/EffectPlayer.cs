using UnityEngine;
using System;

public class EffectPlayer : MonoBehaviour {

    public string name;
    public GameObject[] effects;
}

public static class EffectPlayerExtension {

    public static GameObject[] Play(this EffectPlayer effectPlayer, Vector3 position) {
        if (effectPlayer == null) {
            return null;
        }

        var newEffects = new GameObject[effectPlayer.effects.Length];
        foreach (var effect in effectPlayer.effects) {
            var newEffect = Assets.Clone(effect);
            newEffect.transform.position = position;

            var pfxs = newEffect.GetComponentsInChildren<ParticleSystem>();
            var totalDuration = 0f;
            foreach (var pfx in pfxs) {
                var duration = pfx.startDelay + pfx.startLifetime + pfx.duration;
                if (duration > totalDuration) {
                    totalDuration = duration;
                }
            }

            Assets.Destroy(newEffect, totalDuration);
        }

        return newEffects;
    }
}