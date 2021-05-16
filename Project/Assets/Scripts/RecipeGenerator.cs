using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class RecipeGenerator : MonoBehaviour
{
    public void GenerateRecipe()
    {
        
    }
}

public class Recipe : ScriptableObject
{
    public Appendage[] requiredParts = new Appendage[5];

    public bool RecipeFollowed(Blob blob)
    {
        return true;
    }
    
}
