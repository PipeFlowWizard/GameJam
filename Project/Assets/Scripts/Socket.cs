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
            var appendageTrans = a.transform;
            appendage = a;
            appendageTrans.parent = transform;
            appendageTrans.localPosition = transform.position;
            hasAppendage = true;
        }
        else Debug.Log("This appendage is already socketed");
    }
}