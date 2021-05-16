using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ArrowDispenser : MonoBehaviour
{
    public GameObject arrowPrefab;

    private ControlKey input;

    private AudioSource aSource;
    // Start is called before the first frame update
    void Start()
    {
        input = GetComponent<ControlKey>();
        aSource = GetComponent<AudioSource>();
    }

    // Update is called once per frame
    void Update()
    {
        if (PauseMenu.paused)
            return;
        if (input["fire"])
        {
            Instantiate(arrowPrefab, transform.position + transform.up,
                transform.rotation);
            aSource.Play();
        }
    }
}
