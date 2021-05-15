using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Spawner : MonoBehaviour
{
    public float limbSpawnDelay, blobSpawnDelay;

    public GameObject[] blobPrefabs, limbPrefabs;
    public Vector2 spawnBounds;

    private float limbTimer = 0, blobTimer = 0;

    private void OnDrawGizmos()
    {
        Gizmos.DrawWireCube(Vector3.zero, spawnBounds);
    }

    private void Update()
    {
        limbTimer += Time.deltaTime;
        blobTimer += Time.deltaTime;
        
        if(limbTimer > limbSpawnDelay)
        {
            limbTimer = 0;
            SpawnAppendage();
        }

        if(blobTimer > blobSpawnDelay)
        {
            blobTimer = 0;
            // pass a random int if you wnat appendages on the blob
            SpawnBlob();
        }
    }

    public void SpawnBlob()
    {
        Vector2 spawnPos = GenerateSpawnPosition();
        Instantiate(blobPrefabs[Random.Range(0, blobPrefabs.Length)], spawnPos, Quaternion.identity);
    }

    public void SpawnBlob(int n)
    {
        Vector2 spawnPos = GenerateSpawnPosition();
        Blob blob = Instantiate(blobPrefabs[Random.Range(0, blobPrefabs.Length)], spawnPos,
            Quaternion.identity).GetComponent<Blob>();

        while( n > 0)
        {
            blob.Attach(Instantiate(limbPrefabs[Random.Range(0, limbPrefabs.Length)]).GetComponent<Appendage>());
            n--;
        }
    }

    public void SpawnAppendage()
    {
        Vector2 spawnPos = GenerateSpawnPosition();
        Instantiate(limbPrefabs[Random.Range(0, limbPrefabs.Length)], spawnPos, Quaternion.identity);
    }

    private Vector2 GenerateSpawnPosition()
    {
        Vector2 spawnPos = Vector2.zero;
        spawnPos.x = Random.Range(-spawnBounds.x, spawnBounds.x);
        spawnPos.y = Random.Range(-spawnBounds.y, spawnBounds.y);
        return spawnPos;
    }
}
