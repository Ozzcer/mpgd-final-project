using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DestroyOnCollision : MonoBehaviour
{
    public GameObject explosionAnim;
    [HideInInspector]
    public int damage;
    private void Start()
    {
    }
    private void OnTriggerEnter(Collider other)
    {
        
        if (other.tag == "Enemy")
        {
            other.gameObject.GetComponent<Enemy>().TakeDamage(damage);
            Debug.Log("Spell successful");
        }
        Destroy(gameObject);
        Instantiate(explosionAnim, transform.position, transform.rotation);

    }
}
