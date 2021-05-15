using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Socket : MonoBehaviour
{
    public AudioClip[] playOnAttach;

    public Appendage appendage;
    private bool _hasAppendage = false;
    
    public bool HasAppendage {get => _hasAppendage;}

        public void Attach(Appendage a)
    {
        if(!a.isSocketed)
        {
            a.Attach(transform);
            appendage = a;
            _hasAppendage = true;
            appendage.isSocketed = true;

            Collider2D col = GetComponentInParent<Collider2D>();
            if(col)
                Physics2D.IgnoreCollision(col, a.GetComponentInChildren<Collider2D>());

            AudioSource aSource = gameObject.AddComponent<AudioSource>();
            aSource.clip = playOnAttach[Random.Range(0, playOnAttach.Length)];
            aSource.Play();

            RemoveArrowsFrom(transform);
            RemoveArrowsFrom(a.transform);
        }
        else Debug.Log("This appendage is already socketed");
    }

    private void RemoveArrowsFrom(Transform t)
    {
        List<GameObject> toDestroy = new List<GameObject>();
        RemoveArrowsFromRecurse(t.root, toDestroy);

        while(toDestroy.Count > 0)
        {
            Destroy(toDestroy[0]);
            toDestroy.RemoveAt(0);
        }
    }

    private void RemoveArrowsFromRecurse(Transform t, List<GameObject> toDestroy)
    {
        foreach(Transform child in t)
        {
            if (child.CompareTag("Arrow"))
                toDestroy.Add(child.gameObject);
            RemoveArrowsFromRecurse(child, toDestroy);
        }
    }
}