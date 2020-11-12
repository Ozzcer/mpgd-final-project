using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class UIController : MonoBehaviour
{
    private Player player;

    public Image healthBar;
    private float maxHealth;
    private float currentHealth;

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

   // public Image thirdSpell;
   // private float tCoolDown;
   // private float tCurrentTimer;


    private void Start()
    {
        fireBall = GetComponent<FireBallSpell>();
        staffAttack = GetComponent<StaffAttack>();
        player = GetComponent<Player>();

    }

    private void Update()
    {

        maxHealth = player.GetMaxHealth();
        currentHealth = player.currentHealth;

        maxExp = player.maxExp;
        currentExp = player.currentExp;

        fCoolDown = fireBall.spellCooldown;
        fCurrentTimer = fireBall.timer;

        sCoolDown = staffAttack.spellCooldown;
        sCurrentTimer = staffAttack.timer;

        //Debug.Log(currentHealth.ToString() + maxHealth.ToString());
        firstSpell.fillAmount = 1 - fCurrentTimer / fCoolDown;
        secondSpell.fillAmount = 1 - sCurrentTimer / sCoolDown;
        healthBar.fillAmount = (float) (currentHealth) / (float) maxHealth;
        expBar.fillAmount = (float) (currentExp) / (float) maxExp;
    }
}
