using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Socket : MonoBehaviour
{
    public Appendage appendage;
    public bool hasAppendage = false;
    public void Attach(Appendage a)
    {
        if(!a.isSocketed)
        {
            a.Attach(transform);
            appendage = a;
            hasAppendage = true;
        }
        else Debug.Log("This appendage is already socketed");
    }
}