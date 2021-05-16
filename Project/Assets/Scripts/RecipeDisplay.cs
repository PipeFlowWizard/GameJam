using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using TMPro;

public class RecipeDisplay : MonoBehaviour
{
    public Sprite leftArm, rightArm, leftLeg, rightLeg, empty;
    public TextMeshProUGUI lArm, rArm, lLeg, rLeg;

    private SpriteRenderer[] rend;
    // Start is called before the first frame update
    void Start()
    {
        rend = GetComponentsInChildren<SpriteRenderer>();
        UpdateRecipe(1, 0, 2, 0);
    }

    /// <summary>
    /// Update the recipe display with specified number o limbs
    /// </summary>
    /// <param name="lA">left arms</param>
    /// <param name="rA">right arms</param>
    /// <param name="lL">left Legs</param>
    /// <param name="rL">right Legs</param>
    public void UpdateRecipe(int lA, int rA, int lL, int rL)
    {
        int index = 1, n = lA;
        while(n > 0)
        {
            rend[index++].sprite = leftArm;
            n--;
        }
        n = rA;
        while (n > 0)
        {
            rend[index++].sprite = rightArm;
            n--;
        }
        n = lL;
        while (n > 0)
        {
            rend[index++].sprite = leftLeg;
            n--;
        }
        n = rL;
        while (n > 0)
        {
            rend[index++].sprite = rightLeg;
            n--;
        }
        while(index < rend.Length)
        {
            rend[index++].sprite = empty;
        }

        //for(int i = 0; i < rend.Length; i++)
        //{
        //    rend[i].rectTransform.pivot = rend[i].sprite.pivot / (rend[i].rectTransform.sizeDelta);
        //}

        if (!lArm)
            return;
        lArm.text = "Left Arms: " + lA;
        rArm.text = "Right Arms: " + rA;
        lLeg.text = "Left Legs: " + lL;
        rLeg.text = "Right Legs: " + rL;
    }
}
