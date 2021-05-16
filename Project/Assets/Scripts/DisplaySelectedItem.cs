using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using TMPro;

public class DisplaySelectedItem : MonoBehaviour
{
    public Sprite blob, leftArm, rightArm, leftLeg, rightLeg, empty;
    public TextMeshProUGUI text;

    private Image rend;
    // Start is called before the first frame update
    void Start()
    {
        rend = GetComponent<Image>();
        DisplayNoSelection();
    }

    public void UpdateDisplay(GameObject obj)
    {
        if (!obj)
        {
            DisplayNoSelection();
            return;
        }

        if (obj.CompareTag("Blob"))
        {
            rend.sprite = blob;
            SetText("Cutie");
            return;
        }

        Appendage ap = obj.GetComponent<Appendage>();
        if (!obj.CompareTag("Appendage"))
        {
            DisplayNoSelection();
            return;
        }

        if(ap.Type == "Arm")
        {
            if(ap.Side == "Left")
            {
                rend.sprite = leftArm;
                SetText("Left Arm");
            }
            else
            {
                rend.sprite = rightArm;
                SetText("Right Arm");
            }
        }
        else
        {
            if (ap.Side == "Left")
            {
                rend.sprite = leftLeg;
                SetText("Left Leg");
            }
            else
            {
                rend.sprite = rightLeg;
                SetText("Right Leg");
            }
        }
    }

    private void DisplayNoSelection()
    {
        rend.sprite = empty;
        SetText("None");
    }

    private void SetText(string s)
    {
        if (text)
            text.text = "Selected:\n" + s;
    }
}
