using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.InputSystem.Interactions;

public static class GameManager2
{
    static public GameObject[] selected = new GameObject[2];
    
    
    
    
    
    /// <summary>
    /// Called by the arrow behaviour when an arrow hits an object
    /// </summary>
    /// <param name="gameObject">The gameobject hit by the arrow</param>
    public static void AssignSelection(GameObject gameObject)
    {
        // Get the top most object in the gameobject tree
        var mainObject = gameObject.transform.root.gameObject;
        
            // Ensure that the object is an appendage or a blob
            if (mainObject.CompareTag("Appendage") || mainObject.CompareTag("Blob"))
            {
                if (selected[0] == null)
                {
                    selected[0] = mainObject;
                }
                else if (selected[1] == null)
                {
                    selected[1] = mainObject;
                }
                
                // If two objects are selected, try to attach them depending on the item combo
                if (selected[0] != null && selected[1] != null)
                {

                    //Case 1: Blob x Blob
                    if (selected[0].CompareTag("Blob") && selected[1].CompareTag("Blob"))
                    {
                        // Pair them together
                    }
                    //Case 2: Appendage x Appendage
                    if (selected[0].CompareTag("Appendage") && selected[1].CompareTag("Appendage"))
                    {
                        selected[0].GetComponent<Appendage>().Attach2(selected[1].GetComponent<Appendage>());
                    }
                    //Case 3: Blob x Appendage || Appendage x Blob
                    if (selected[0].CompareTag("Blob") && selected[1].CompareTag("Appendage"))
                    {
                        selected[0].GetComponent<Blob>().Attach(selected[1].GetComponent<Appendage>());
                    }

                    if (selected[0].CompareTag("Appendage") && selected[1].CompareTag("Blob"))
                    {
                        selected[1].GetComponent<Blob>().Attach(selected[0].GetComponent<Appendage>());
                    }


                    // Empty the selected items array
                    //Array.Clear(selected,0,2);

                }
                
            }
            
            
    }
    
    
    
}
