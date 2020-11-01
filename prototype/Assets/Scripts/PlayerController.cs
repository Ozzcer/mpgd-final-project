using System.Collections;
using System.Collections.Generic;
using System.Collections.Specialized;
using System.Configuration;
using UnityEngine;

public class PlayerController : MonoBehaviour
{
    // Basic player stats for testing monsters
    private static float MAX_HEALTH = 100;
    public float currentHealth;
    public float ARMOUR = 5;

    public RangedController ranged;
    private float damageDealt;

    // Vector to hold new position
    Vector3 newPos;

    // Start is called before the first frame update
    void Start()
    {
        currentHealth = MAX_HEALTH;
    }

    // Update is called once per frame
    void Update()
    {
        if (currentHealth <= 0)
        {
            newPos = new Vector3(Random.Range(-9.5f, 9.5f), 0.5f, Random.Range(-9.5f, 9.5f));
            transform.position = newPos;
            currentHealth = MAX_HEALTH;
        }
    }

    void OnTriggerEnter(Collider other)
    {
        if (other.gameObject.tag == "Projectile")
        {
            other.gameObject.SetActive(false);
            Destroy(other.gameObject);
            damageDealt = ranged.ATTACK_DAMAGE * (1 - (ARMOUR / 100));
            currentHealth = currentHealth - damageDealt;
            Debug.Log("Ranged: " + damageDealt);
        }
    }
}
