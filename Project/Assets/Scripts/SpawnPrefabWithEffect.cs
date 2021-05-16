using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SpawnPrefabWithEffect : MonoBehaviour
{
    public System.Action<Vector2> spawnFunction;

    private ParticleSystem pSystem;
    private bool hasSpawned;
    // Start is called before the first frame update
    void Start()
    {
        pSystem = GetComponent<ParticleSystem>();
        hasSpawned = false;
    }

    // Update is called once per frame
    void Update()
    {
        if (!pSystem.isEmitting && !hasSpawned)
        {
            spawnFunction(transform.position);
            hasSpawned = true;
        }
        
        if (!pSystem.IsAlive())
            Destroy(gameObject);
    }
}
