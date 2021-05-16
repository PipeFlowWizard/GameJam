using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class RecipeGenerator
{
    private String[] possibleAppendages = {"RightArm","LeftArm", "RightLeg", "LeftLeg" };
    private List<String> recipe = new List<string>();
    public List<String> GenerateRecipe()
    {
         recipe.Clear();
         for (int i = 0; i < 5; i++)
         {
             if(UnityEngine.Random.value >.8f) continue;
             else recipe.Add(possibleAppendages[UnityEngine.Random.Range(0,3)]);
         }
         return recipe;
    }
}

