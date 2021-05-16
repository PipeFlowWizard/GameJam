using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Spawner : MonoBehaviour
{
    public float limbSpawnDelay, blobSpawnDelay;

    public GameObject spawnEffect;
    public GameObject[] blobPrefabs, limbPrefabs;
    public Vector2 spawnBounds;

    private float limbTimer = 0, blobTimer = 0;

    private void OnDrawGizmos()
    {
        Gizmos.DrawWireCube(Vector3.zero, spawnBounds * 2);
    }

    private void Update()
    {
        limbTimer += Time.deltaTime;
        blobTimer += Time.deltaTime;
        
        if(limbTimer > limbSpawnDelay)
        {
            limbTimer = 0;
            //SpawnAppendage();
            InitiateSpawnProcess(SpawnAppendageAtPosition);
        }

        if(blobTimer > blobSpawnDelay)
        {
            blobTimer = 0;
            // pass a random int if you wnat appendages on the blob
            if (Random.Range(0, 100) < 5)
                InitiateSpawnProcess(SpawnBlobWithLimbsAtPosition);
            else
                InitiateSpawnProcess(SpawnBlobAtPosition);
            //SpawnBlob();
        }
    }

    private void InitiateSpawnProcess(System.Action<Vector2> a)
    {
        Vector2 spawnPos = GenerateSpawnPosition();
        Instantiate(spawnEffect, spawnPos, Quaternion.identity).
            GetComponent<SpawnPrefabWithEffect>().spawnFunction = a;
    }

    public void SpawnBlobAtPosition(Vector2 v)
    {
        Instantiate(blobPrefabs[Random.Range(0, blobPrefabs.Length)], v, Quaternion.identity);
    }

    public void SpawnBlobWithLimbsAtPosition(Vector2 v)
    {
        GameObject item = Instantiate(blobPrefabs[Random.Range(0, blobPrefabs.Length)], v, Quaternion.identity);
        var rb = item.GetComponent<Rigidbody2D>();
        rb.AddForce(UnityEngine.Random.insideUnitCircle);
        rb.AddTorque(UnityEngine.Random.Range(0, 2));

        Blob blob = item.GetComponent<Blob>();
        int n = Random.Range(0, 5);
        while (n > 0)
        {
            blob.Attach(Instantiate(limbPrefabs[Random.Range(0, limbPrefabs.Length)]).GetComponent<Appendage>());
            n--;
        }
    }

    public void SpawnAppendageAtPosition(Vector2 v)
    {
        var item = Instantiate(limbPrefabs[Random.Range(0, limbPrefabs.Length)], v, Quaternion.Euler(0, 0, UnityEngine.Random.Range(0, 360)));
        var rb = item.GetComponent<Rigidbody2D>();
        rb.AddForce(UnityEngine.Random.insideUnitCircle * 2.5f, ForceMode2D.Impulse);
    }


    public GameObject SpawnBlob()
    {
        Vector2 spawnPos = GenerateSpawnPosition();
        var blob = Instantiate(blobPrefabs[Random.Range(0, blobPrefabs.Length)], spawnPos, Quaternion.identity);
        return blob;
    }

    public void SpawnBlob(int n)
    {
        var item = SpawnBlob();
        var rb = item.GetComponent<Rigidbody2D>();
        rb.AddForce(UnityEngine.Random.insideUnitCircle);
        rb.AddTorque(UnityEngine.Random.Range(0,2));
        
        Blob blob = item.GetComponent<Blob>();
        
        while( n > 0)
        {
            blob.Attach(Instantiate(limbPrefabs[Random.Range(0, limbPrefabs.Length)]).GetComponent<Appendage>());
            n--;
        }
    }

    public void SpawnAppendage()
    {
        Vector2 spawnPos = GenerateSpawnPosition();
        var item = Instantiate(limbPrefabs[Random.Range(0, limbPrefabs.Length)], spawnPos, Quaternion.Euler(0,0,UnityEngine.Random.Range(0,360)));
        var rb = item.GetComponent<Rigidbody2D>();
        rb.AddForce(UnityEngine.Random.insideUnitCircle * 2.5f,ForceMode2D.Impulse);
    }

    private Vector2 GenerateSpawnPosition()
    {
        Vector2 spawnPos = Vector2.zero;
        spawnPos.x = Random.Range(-spawnBounds.x, spawnBounds.x);
        spawnPos.y = Random.Range(-spawnBounds.y, spawnBounds.y);
        return spawnPos;
    }
}
