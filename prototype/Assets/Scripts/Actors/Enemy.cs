using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.AI;

public class Enemy : Character
{
    private Player player;
    public LayerMask aggroLayerMask;

    private Collider[] withinAggroColliders;
    private NavMeshAgent navAgent;
    private Animator animator;


    public override void Start()
    {
        stats.Add(new BaseStat(baseHealth, "base health"));
        stats.Add(new BaseStat(baseMana, "base mana"));

        stats.Add(new BaseStat(strength, "strength"));
        stats.Add(new BaseStat(agility, "agility"));
        stats.Add(new BaseStat(intelligence, "intelligence"));

        stats.Add(new BaseStat(spellPower, "spell power"));
        stats.Add(new BaseStat(attackPower, "attack power"));

        stats.Add(new BaseStat(attackSpeed, "attack speed"));
        stats.Add(new BaseStat(armor, "armor"));

        stats.Add(new BaseStat(baseHealthRegen, "base health regen"));
        stats.Add(new BaseStat(baseManaRegen, "base mana regen"));

        currentHealth = GetMaxHealth();
        currentMana = GetMaxMana();

        navAgent = GetComponent<NavMeshAgent>();
        animator = GetComponent<Animator>();
    }
    private void FixedUpdate()
    {
        withinAggroColliders = Physics.OverlapSphere(transform.position, 10, aggroLayerMask);
        
        if (withinAggroColliders.Length > 0)
        {
            ChasePlayer(withinAggroColliders[0].GetComponent<Player>());
        }
        else
        {
            animator.SetBool("is_walking", false);
        }
    }

    private void ChasePlayer(Player player)
    {
        this.player = player;

        navAgent.SetDestination(player.transform.position);
        animator.SetBool("is_walking", true);

        if (navAgent.remainingDistance <= navAgent.stoppingDistance)
        {
            if (!IsInvoking("PerformAttack"))
            {
                InvokeRepeating("PerformAttack", .5f, 2f); //2f is attack speed
            }
        }
        else
        {
            CancelInvoke("PerformAttack");
        }

    }
    public void PerformAttack()
    {
        animator.SetTrigger("attack");
        player.TakeDamage(GetStat("attack power"));
    }

    public override void Die()
    {
        player.GainExp(100);
        Destroy(gameObject);
    }


}
