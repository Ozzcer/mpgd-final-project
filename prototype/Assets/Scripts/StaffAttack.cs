using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class StaffAttack : MonoBehaviour
{
    private Animator characterAnimator;
    private Animator staffAnimator;
    private CharacterStats charStats;

    public int minDmg;
    public int maxDmg;
    private int baseDamage;
    public GameObject staff;
    public float spellCooldown;
    public float timer;
   // protected int lvl;

    private void Start()
    {
        timer = 0;
        charStats = GetComponent<CharacterStats>();
        characterAnimator = GetComponent<Animator>();
        staffAnimator = staff.GetComponent<Animator>();
    }
    private void Update()
    {
        if (timer > 0)
        {
            timer -= 1 * Time.deltaTime;
        }
    }
    public void PerformAttack()
    {
        if (timer <= 0)
        {
            int spellPower = (int)charStats.GetTotalSpellPower();
            baseDamage = Random.Range(minDmg, maxDmg);
            staff.GetComponent<StaffAttackCollision>().damage = baseDamage + spellPower;
            staff.GetComponent<StaffAttackCollision>().isAttacked = false;

            characterAnimator.SetTrigger("Base_attack");
            staffAnimator.SetTrigger("Base_attack");
            timer = spellCooldown;
        }

    }
}
