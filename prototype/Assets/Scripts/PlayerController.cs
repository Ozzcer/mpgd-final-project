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
    public float speed;

    public RangedController ranged;
    public MeleeController melee;
    private float damageDealt;
    private Vector3 lastPos;
    private Vector3 currentPos;

    // Start is called before the first frame update
    void Start()
    {
        currentHealth = MAX_HEALTH;
    }

    void FixedUpdate() {
        lastPos = currentPos;
        // getting inputs
        float horAxis = Input.GetAxis("Horizontal");
        float verAxis = Input.GetAxis("Vertical");
        Vector3 movement = new Vector3(horAxis, 0.0f, verAxis);
        //moving player
        currentPos = GetComponent<Rigidbody>().position + (movement * speed * Time.fixedDeltaTime);
        GetComponent<Rigidbody>().position = currentPos;
    }

    // Update is called once per frame
    void Update()
    {

    }

    void OnTriggerEnter(Collider other)
    {
        if (other.gameObject.tag == "Projectile")
        {
            damageDealt = ranged.ATTACK_DAMAGE * (1 - (ARMOUR / 100));
            currentHealth = currentHealth - damageDealt;
            Debug.Log("Ranged: " + damageDealt);
        } else if(other.gameObject.tag == "StandardCollider1"){
            Instantiate(ranged, new Vector3(Random.Range(-53f,-37f),0.5f,Random.Range(-26f, -10f)), Quaternion.Euler(0, 0, 0));
        } else if(other.gameObject.tag == "StandardCollider2"){
            Instantiate(melee, new Vector3(Random.Range(-53f,-37f),0.5f,Random.Range(10f,26f)), Quaternion.Euler(0, 0, 0));
        } else{
            Instantiate(melee, new Vector3(Random.Range(-98f,-82f),0.5f,Random.Range(-18f, 18f)), Quaternion.Euler(0, 0, 0));
            Instantiate(ranged, new Vector3(Random.Range(-98f,-82f),0.5f,Random.Range(-18f, 18f)), Quaternion.Euler(0, 0, 0));
        }
        Destroy(other.gameObject);
    }
}
