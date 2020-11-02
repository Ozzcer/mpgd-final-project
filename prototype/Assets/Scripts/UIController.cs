using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class UIController : MonoBehaviour
{
    private CharacterStats charStats;

    public Image healthBar;
    private double maxHealth;
    private double currentHealth;

    public Image expBar;
    private int maxExp;
    private int currentExp;

    private FireBallSpell fireBall;
    public Image firstSpell;
    private float fCoolDown;
    private float fCurrentTimer;

    private StaffAttack staffAttack;
    public Image secondSpell;
    private float sCoolDown;
    private float sCurrentTimer;
    private CheatDeathSelf cheatDeath;
    public Image thirdSpell;
    private float tCoolDown;
    private float tCurrentTimer;


    private void Start()
    {
        fireBall = GetComponent<FireBallSpell>();
        staffAttack = GetComponent<StaffAttack>();
        cheatDeath = GetComponent<CheatDeathSelf>();
        charStats = GetComponent<CharacterStats>();
    }

    private void Update()
    {

        maxHealth = charStats.GetMaxHealth();
        currentHealth = charStats.currentHealth;

        maxExp = charStats.maxExp;
        currentExp = charStats.currentExp;

        fCoolDown = fireBall.spellCooldown;
        fCurrentTimer = fireBall.timer;

        sCoolDown = staffAttack.spellCooldown;
        sCurrentTimer = staffAttack.timer;

        tCoolDown = cheatDeath.spellCooldown;
        tCurrentTimer = cheatDeath.timer;


        //Debug.Log(currentHealth.ToString() + maxHealth.ToString());
        firstSpell.fillAmount = 1 - fCurrentTimer / fCoolDown;
        secondSpell.fillAmount = 1 - sCurrentTimer / sCoolDown;
        thirdSpell.fillAmount = 1 - tCurrentTimer / tCoolDown;
        healthBar.fillAmount = (float) (currentHealth) / (float) maxHealth;
        expBar.fillAmount = (float) (currentExp) / (float) maxExp;
    }
}
