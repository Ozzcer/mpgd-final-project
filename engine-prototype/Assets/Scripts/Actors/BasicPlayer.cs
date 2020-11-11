using Abilities;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace Actors
{
    public class BasicPlayer : Actor
    {
        // Update is called once per frame
        new void Update()
        {
            base.Update();
        }


        public void Initialise(int level)
        {
            base.Initialise(Race.BasicPlayer, level, 50f, 3f, 3f, 3f, 5f, 1f, 4f);
            //TODO abilities.Add(new BasicMeleeAttack(this));
            Debug.Log(this.race);
            Debug.Log(this.level);
            printStatsToConsole();
            //Debug.Log(abilities.ToString());
        }

        public override void actionGenerator()
        {
            if(Input.GetMouseButtonDown(0))
            {
                Ray ray = Camera.main.ScreenPointToRay(Input.mousePosition);
                RaycastHit hit;

                if (Physics.Raycast(ray, out hit))
                {
                    target = hit.point;
                    moving = true;
                }
            }
        }

    }
}
