using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ParticleEffectAtPosition : MonoBehaviour
{
    private static ParticleEffectAtPosition instance;
    private Transform toFollow;
    private ParticleSystem pSystem;

    // Update is called once per frame
    void Update()
    {
        if (toFollow)
            transform.position = toFollow.position;
    }

    public static void DisplaySelection(Transform tr)
    {
        if (!instance)
            instance = FindObjectOfType<ParticleEffectAtPosition>();
        if (!instance)
        {
            Debug.Log("There is no instance of selection particles int he scene");
            return;
        }

        instance.toFollow = tr;
        if (!instance.pSystem.isPlaying)
            instance.pSystem.Play();
    }

    public static void Deselect()
    {
        instance.pSystem.Stop();
    }
}
