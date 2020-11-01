using System.Collections;
using System.Collections.Generic;
using System.Runtime.CompilerServices;
using System.Runtime.InteropServices;
using UnityEngine;

public class RangedController : MonoBehaviour
{
    // all stats that the monsters will have
    // values set arbitrarily for prototype, scale might be largely different for full game
    public static int LEVEL = 1;
    public float MOVEMENT_SPEED = 5f;
    public float ATTACK_SPEED = 0.8f;
    // range is a magnitude of 6
    public float ATTACK_RANGE = 6f;
    public float ATTACK_DAMAGE = 10f;
    public static float MAX_HEALTH = 20f;
    public float currentHealth;
    public float armour;

    // player object
    public GameObject player;

    private float timeElapsed;
    private float distance;

    public GameObject projectile;

    // start is called before the first frame update
    void Start()
    {
        currentHealth = MAX_HEALTH;
        player = GameObject.Find("Player");
    }

    // update is called once per frame
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
                Instantiate(projectile, transform.position, Quaternion.Euler(0, 0, 0));
            }
        }
    }
}
