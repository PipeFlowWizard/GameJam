using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ArrowDispenser : MonoBehaviour
{
    public GameObject arrowPrefab;

    private ControlKey input;
    // Start is called before the first frame update
    void Start()
    {
        input = GetComponent<ControlKey>();
    }

    // Update is called once per frame
    void Update()
    {
        if (input["fire"])
            Instantiate(arrowPrefab, transform.position + transform.up,
                transform.rotation);
    }
}
