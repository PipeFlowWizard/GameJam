using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Socket : MonoBehaviour
{
    public void Attach(Socket socket)
    {
        transform.parent = socket.transform;
        transform.localPosition = Vector2.zero;
    }
}