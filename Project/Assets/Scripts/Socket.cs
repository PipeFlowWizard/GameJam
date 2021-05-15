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

            Collider2D col = GetComponentInParent<Collider2D>();
            Physics2D.IgnoreCollision(col, a.GetComponentInChildren<Collider2D>());
            
        }
        else Debug.Log("This appendage is already socketed");
    }
}