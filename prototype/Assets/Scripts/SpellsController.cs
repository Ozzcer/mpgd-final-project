using System.Collections;
using System.Collections.Generic;
using UnityEditor;
using UnityEngine;

public class SpellsController : MonoBehaviour
{
    public float generalCooldown;
    private float timer;

    private FireBallSpell fireBallSpell;
    public KeyCode fireBallSpellKey;

    private StaffAttack staffAttack;
    public KeyCode staffAttackKey;

    // Start is called before the first frame update
    void Start()
    {
        timer = 0;
        fireBallSpell = GetComponent<FireBallSpell>();
        staffAttack = GetComponent<StaffAttack>();
    }

    // Update is called once per frame
    void Update()
    {
        if (timer <= 0)
        {
            if (Input.GetKeyDown(fireBallSpellKey))
            {
                fireBallSpell.castSpell();
                timer = generalCooldown;
            }

            if (Input.GetKeyDown(staffAttackKey))
            {
                staffAttack.PerformAttack();
                timer = generalCooldown;
            }
        }
        else {
            timer -= 1 * Time.deltaTime;
        }


    }
}
