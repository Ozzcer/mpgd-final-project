using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class StaffAttack : BasicSpell
{
    private Animator characterAnimator;
    private Animator staffAnimator;

    private int baseDamage;
    public GameObject staff;

    public override void Start()
    {
        timer = 0;
        player = GetComponent<Player>();
        characterAnimator = GetComponent<Animator>();
        staffAnimator = staff.GetComponent<Animator>();
    }
    public override void CastSpell()
    {
        if (timer <= 0)
        {
            int attackPower = player.GetAttackPower();
            baseDamage = Random.Range(minAmount, maxAmount);
            staff.GetComponent<StaffAttackCollision>().damage = baseDamage + attackPower;
            staff.GetComponent<StaffAttackCollision>().isAttacked = false;

            characterAnimator.SetTrigger("Base_attack");
            staffAnimator.SetTrigger("Base_attack");
            timer = spellCooldown;
        }

    }
}
