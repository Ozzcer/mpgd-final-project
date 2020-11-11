using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace Effects
{
    public enum EffectType { BasicDamage };
    public class Effect
    {
        protected string title;
        protected EffectType type;
        protected float duration;
        protected float power;

        protected bool tickCounter()
        {
            if (duration == 0)
            {
                duration -= 1 * Time.deltaTime;
                return true;
            }
            else
            {
                duration -= 1 * Time.deltaTime;
                return false;
            }
        }
    }
}