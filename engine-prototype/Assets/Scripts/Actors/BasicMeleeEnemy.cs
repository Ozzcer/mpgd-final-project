using Abilities;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace Actors
{
    public class BasicMeleeEnemy : Actor
    {
        // Start is called before the first frame update
        void Start()
        {

        }

        // Update is called once per frame
        new void Update()
        {
            base.Update();
        }
        public void Initialise(int level)
        {
            base.Initialise(Race.BasicMeleeEnemy, level, 10f, 3f, 1f, 1f, 7f, 2f, 3f);

            //TODO abilities.Add(new BasicMeleeAttack(this));
            Debug.Log(this.race);
            Debug.Log(this.level);
            this.printStatsToConsole();
        }

        public override void actionGenerator()
        {
            //TODO basic AI
            //throw new System.NotImplementedException();
        }
    }
}
