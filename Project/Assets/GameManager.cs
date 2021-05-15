using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.InputSystem.Interactions;

public static class GameManager
{
   static public GameObject selectedObject1, selectedObject2;
    static public int selectedArrow = 1;
    static public Queue<GameObject> selected = new Queue<GameObject>();
    
    
    
    
    public static void AssignSelection(GameObject gameObject)
    {
        if (gameObject.CompareTag("Appendage") || gameObject.CompareTag("Blob"))
        {
            if (selected.Count >= 2) selected.Dequeue();
            selected.Enqueue(gameObject);
            Debug.Log("popped: " + gameObject.tag);
            Debug.Log("pushed: " + gameObject.tag);
        }
        
        Debug.Log("selection arrow: " + selectedArrow);
    }
}
