using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class BasicSpell : MonoBehaviour
{
    protected Player player;

    public float spellCooldown;
    public float timer;
   
    public int minAmount;
    public int maxAmount;

    protected int lvl;
    public virtual void Start()
    {
        timer = 0;
        player = GetComponent<Player>();
    }

    void Update()
    {
        if (timer > 0)
        {
            timer -= 1 * Time.deltaTime;
        }
    }

    //This method has to be overriden in the subclass
    public virtual void CastSpell()
    {
        Debug.Log("Casting basic spell!");
    }


}
