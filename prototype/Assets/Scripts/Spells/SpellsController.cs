using System.Collections;
using System.Collections.Generic;
using UnityEditor;
using UnityEngine;

public class SpellsController : MonoBehaviour
{
    public float generalCooldown;
    private float timer;

    private BasicSpell firstSpell;
    public KeyCode firstSpellKey;

    private BasicSpell secondSpell;
    public KeyCode secondSpellKey;

    // Start is called before the first frame update
    void Start()
    {
        timer = 0;
        secondSpell = GetComponent<FireBallSpell>();
        firstSpell = GetComponent<StaffAttack>();
    }

    // Update is called once per frame
    void Update()
    {
        if (timer <= 0)
        {
            if (Input.GetKeyDown(firstSpellKey))
            {
                firstSpell.CastSpell();
                timer = generalCooldown;
            }

            if (Input.GetKeyDown(secondSpellKey))
            {
                secondSpell.CastSpell();
                timer = generalCooldown;
            }
        }
        else {
            timer -= 1 * Time.deltaTime;
        }


    }
}
