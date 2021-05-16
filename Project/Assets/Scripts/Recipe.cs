using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Recipe
{
    private System.Random _random = new System.Random();
    
    private int _numRightLegs = 0;
    private int _numLeftLegs = 0;
    private int _numRightArms = 0;
    private int _numLeftArms = 0;

    public int NumLeftArms => _numLeftArms;
    public int NumLeftLegs => _numLeftLegs;
    public int NumRightArms => _numRightArms;
    public int NumRightLegs => _numRightLegs;

    public int NumArms => _numLeftArms + _numRightArms;
    public int NumLegs => _numLeftLegs + _numRightLegs;
    
    
    public void GenerateRecipe()
    {
        int[] nums = new int[4];
        for(int i = 0; i < 5; i++)
        {
            if (UnityEngine.Random.value > 0.7f) continue;
            else nums[_random.Next(4)] += 1;
        }

        _numLeftArms = nums[0];
        _numRightArms = nums[1];
        _numLeftLegs = nums[2];
        _numRightLegs = nums[3];
        Debug.Log("la: " + _numLeftArms + " ra: " + _numRightArms + " ll: " + _numLeftLegs + " rl: " + _numRightLegs);
    }
}

