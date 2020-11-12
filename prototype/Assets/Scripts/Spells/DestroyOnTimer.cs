using UnityEngine;
using System.Collections;

public class DestroyOnTimer : MonoBehaviour
{

    public float destroyTimer;
    private float currentTimer;

    private void Start()
    {
        currentTimer = destroyTimer;
    }
    void Update()
    {
        if (currentTimer <= 0)
        {
            Destroy(gameObject);
        }
        currentTimer -= 1 * Time.deltaTime;
    }
}
