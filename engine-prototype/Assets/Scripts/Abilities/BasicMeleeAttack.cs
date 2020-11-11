using Abilities;
using Actors;
using Effects;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace Abilities
{
    public class BasicMeleeAttack : Ability
    {
        public BasicMeleeAttack(Actor actor)
        {
            this.Initialise(actor);
        }
        public void Initialise(Actor actor)
        {
            base.Initialise("Basic Melee Attack", EffectType.BasicDamage, 1f, 1f, 0f, 1f, 0f, actor);
        }
        protected override void statModifierCalculations(Dictionary<string, float> stats)
        {
            power = (basePower * (0.2f * stats["strength"]));
        }
    }


}
