using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Spawner : MonoBehaviour
{
    public GameObject[] blobPrefabs, limbPrefabs;
    public Vector2 spawnBounds;

    private void OnDrawGizmos()
    {
        Gizmos.DrawWireCube(Vector3.zero, spawnBounds);
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
