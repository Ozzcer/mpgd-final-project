using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class StaffAttackCollision : MonoBehaviour
{
    [HideInInspector]
    public int damage;
    [HideInInspector]
    public bool isAttacked;


    private void OnTriggerEnter(Collider other)
    {
        if (!isAttacked)
        {
            if (other.tag == "Enemy")
            {
                other.gameObject.GetComponent<Enemy>().TakeDamage(damage);
                isAttacked = true;

            }
        }
    }
}
