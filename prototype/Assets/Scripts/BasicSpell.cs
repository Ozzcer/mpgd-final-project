using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class BasicSpell : MonoBehaviour
{
    public GameObject spawnLocation;

    public GameObject spellPrefab;
    public float spellCooldown;
    public float timer;


    // Start is called before the first frame update
    void Start()
    {
        timer = 0;
    }

    // Update is called once per frame
    void Update()
    {
        if (timer > 0)
        {
            timer -= 1 * Time.deltaTime;
        }
    }

    //This method has to be overriden in the subclass
    public virtual void castSpell()
    {
        Debug.Log("Casting basic spell!");
    }
}
