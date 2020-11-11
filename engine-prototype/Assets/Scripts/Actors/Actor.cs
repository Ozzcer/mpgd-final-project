using Abilities;
using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace Actors
{
    /** 
     * Abstract class Actor
     * The actor class is a super class for all actors within the game, it has functions to handle movement, recieving of abilities and sending of abilities to other actors.
     * The actor class initialises stats based on a prefab.
     */
    public enum Race { BasicPlayer, BasicMeleeEnemy };
    public abstract class Actor : MonoBehaviour
    {
        protected Race race;
        protected int level;
        protected Dictionary<string, float> stats = new Dictionary<string, float>();
        protected bool moving = false;
        protected Vector3 target;
        protected List<Ability> abilities;
        protected List<Ability> abilitiesOnCooldown;
        protected List<Ability> activeAbilities;

       protected void Update()
        {
            actionGenerator();
            handleMovement();
        }

        public void handleMovement()
        {
            if (moving)
            {
                transform.position = Vector3.MoveTowards(transform.position, target, stats["moveSpeed"] * Time.deltaTime);
                if (Vector3.Distance(transform.position, target) < 0.001f)
                {
                    moving = false;
                }
            }
        }
        
        public Dictionary<string, float> getStats(){ return stats; }

        public virtual void Die()
        {
            Destroy(this.gameObject);
        }

        public abstract void actionGenerator();

        protected void Initialise(Race race, int level, float baseHealth, float baseStrength, float baseAgility, float baseIntelligence, float baseMoveSpeed, float baseAttackSpeed, float baseAttackDamage)
        {
            this.race = race;
            this.level = level;
            this.stats.Add("baseHealth", baseHealth);
            this.stats.Add("baseStrength", baseStrength);
            this.stats.Add("baseAgility", baseAgility);
            this.stats.Add("baseIntelligence", baseIntelligence);
            this.stats.Add("baseMoveSpeed", baseMoveSpeed);
            this.stats.Add("baseAttackSpeed", baseAttackSpeed);
            this.stats.Add("baseAttackDamage", baseAttackDamage);
            this.stats.Add("health", baseHealth);
            this.stats.Add("strength", baseStrength);
            this.stats.Add("agility", baseAgility);
            this.stats.Add("intelligence", baseIntelligence);
            this.stats.Add("moveSpeed", baseMoveSpeed);
            this.stats.Add("attackSpeed", baseAttackSpeed);
            this.stats.Add("attackDamage", baseAttackDamage);

            //TODO add available abilities 
        }

        public void printStatsToConsole()
        {
            foreach (KeyValuePair<string, float> stat in stats)
            {
                Debug.Log(stat.Key.ToString() + ": " + stat.Value.ToString());
            }

        }
    }
}