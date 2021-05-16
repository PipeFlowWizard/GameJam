using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Breathe : MonoBehaviour
{
    public Vector2 amplitude;
    public Vector2 frequency;

    private Vector2 scale;
    // Start is called before the first frame update
    void Start()
    {
        scale = transform.localScale;
    }

    // Update is called once per frame
    void Update()
    {
        if (transform != transform.root)
            Destroy(this);
        transform.localScale = scale + new Vector2(
            amplitude.x * Mathf.Sin(Time.time * frequency.x), amplitude.y * Mathf.Cos(Time.time * frequency.y));
    }
}
