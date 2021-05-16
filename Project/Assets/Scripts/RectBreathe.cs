using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class RectBreathe : MonoBehaviour
{
    public Vector2 amplitude;
    public Vector2 frequency;
    private RectTransform _rectTransform;
    private Vector2 scale;
    // Start is called before the first frame update
    void Start()
    {
        _rectTransform = GetComponent<RectTransform>();
        scale = _rectTransform.localScale;
        
    }

    // Update is called once per frame
    void Update()
    {
        if (_rectTransform != _rectTransform.root)
            Destroy(this);
        _rectTransform.localScale = scale + new Vector2(
            amplitude.x * Mathf.Sin(Time.time * frequency.x), amplitude.y * Mathf.Cos(Time.time * frequency.y));
    }
    
}
