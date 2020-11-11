using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Actors;
using Effects;
namespace Abilities
{
    public enum ExistingAbilities {BasicMeleeAttack};

    public abstract class Ability : MonoBehaviour
    {
        protected string title;
        protected EffectType effect;
        protected float basePower;
        protected float power;
        protected float baseRange;
        protected float range;
        protected float baseAoeRange;
        protected float aoeRange;
        protected float baseDuration;
        protected float duration;
        protected float baseCooldown;
        protected float cooldown;
        protected GameObject abilityPrefab;

        //TODO spawn ability prefab



        protected void Initialise(string name, EffectType effectType, float basePower, float baseRange, float baseAoeRange, float baseDuration, float baseCooldown, Actor actor)
        {
            this.title = name;
            this.effect = effectType;

            this.basePower = basePower;
            this.power = basePower;

            this.baseRange = baseRange;
            this.range = baseRange;

            this.baseAoeRange = baseAoeRange;
            this.aoeRange = baseAoeRange;

            this.baseDuration = baseDuration;
            this.duration = baseDuration;

            this.baseCooldown = baseCooldown;
            this.cooldown = baseCooldown;

            statModifierCalculations(actor.getStats());
        }

        protected abstract void statModifierCalculations(Dictionary<string, float> stats);
    }
}

