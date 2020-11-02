using System.Collections;
using System.Collections.Generic;
using JetBrains.Annotations;
using UnityEditor;
using UnityEngine;

public class MeleeController : MonoBehaviour
{
    // all stats that the monsters will have
    // values set arbitrarily for prototype
    public static int LEVEL = 1;
    public float MOVEMENT_SPEED = 3f;
    public float ATTACK_SPEED = 1.5f;
    // range is a magnitude of 1
    public float ATTACK_RANGE = 1.5f;
    public float ATTACK_DAMAGE = 40f;
    public static float MAX_HEALTH = 60f;
    public float currentHealth;
    public float armour;

    // player object
    public GameObject player;

    private float timeElapsed;
    private float distance;
    private float damageDealt;

    // start is called before the first frame update
    void Start()
    {
        currentHealth = MAX_HEALTH;
        player = GameObject.Find("Player");
    }

    // Update is called once per frame
    void Update()
    {
        timeElapsed += Time.deltaTime;
        distance = Vector3.Distance(transform.position, player.transform.position);
        // if the player is further away than the attack range
        if ((distance > ATTACK_RANGE))
        {
            // move the monster
            float step = MOVEMENT_SPEED * Time.deltaTime;
            transform.position = Vector3.MoveTowards(transform.position, player.transform.position, step);
        }
        else
        {
            if (timeElapsed > ATTACK_SPEED){
                timeElapsed = 0;
                damageDealt = ATTACK_DAMAGE * (1 - (player.GetComponent<PlayerController>().ARMOUR /100));
                player.GetComponent<PlayerController>().currentHealth = player.GetComponent<PlayerController>().currentHealth - damageDealt;
                Debug.Log("Melee: " + damageDealt);
            }
        }
    }
}
