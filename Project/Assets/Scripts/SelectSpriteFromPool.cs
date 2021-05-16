using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SelectSpriteFromPool : MonoBehaviour
{
    public Sprite[] spritePool;
    // Start is called before the first frame update
    void Start()
    {
        GetComponent<SpriteRenderer>().sprite = spritePool[Random.Range(0, spritePool.Length)];
    }
}
