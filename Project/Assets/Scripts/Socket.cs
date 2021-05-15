using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Socket : MonoBehaviour
{
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

            CircleCollider2D col = GetComponentInParent<CircleCollider2D>();
            //foreach (PolygonCollider2D poly in a.GetComponentsInChildren<PolygonCollider2D>())
            Physics2D.IgnoreCollision(col, a.GetComponentInChildren<PolygonCollider2D>());
            
        }
        else Debug.Log("This appendage is already socketed");
    }
}