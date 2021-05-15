using System;
using System.Collections;
using System.Collections.Generic;
using Cinemachine;
using TMPro;
using Unity.Mathematics;
using UnityEngine;
using UnityEngine.UI;

public class GameManager : MonoBehaviour
{
    private static GameManager _instance;
    public static GameManager Instance
    {
        get => _instance;
    }
    
    static public GameObject[] selected = new GameObject[2];
    public int score = 0;
    public float timeLimit = 120;
    public TextMeshProUGUI timeText, scoreText;
    private float remainingTime;
    public GameObject matchParticleBurst;
    public CinemachineVirtualCamera cam;
    public CinemachineImpulseSource impulse;
    

    
    /// <summary>
    /// Instantiate singleton
    /// </summary>
    private void Awake()
    {
        if (_instance != null && _instance != this)
        {
            Destroy(this.gameObject);
        } else {
            _instance = this;
        }
    }
    
    void Start()
    {
        impulse = GetComponent<CinemachineImpulseSource>();
        score = 0;
        remainingTime = timeLimit;
        DisplayRemainingTime();
        UpdateScoreDisplay();
    }

    // Update is called once per frame
    void Update()
    {
        remainingTime -= Time.deltaTime;
        DisplayRemainingTime();
    }

    public void AddScore(int amount)
    {
        score += amount;
        UpdateScoreDisplay();
    }

    private void DisplayRemainingTime()
    {
        if (!timeText)
            return;
        timeText.text = (int)remainingTime / 60 + " : " + remainingTime % 60;
    }

    private void UpdateScoreDisplay()
    {
        if (!scoreText)
            return;
        scoreText.text = "" + score;
    }
    
    
    
    /// <summary>
    /// Called by the arrow behaviour when an arrow hits an object
    /// </summary>
    /// <param name="gameObject">The gameobject hit by the arrow</param>
    public void AssignSelection(GameObject gameObject)
    {
        // Get the top most object in the gameobject tree
        var mainObject = gameObject.transform.root.gameObject;

        if (mainObject.CompareTag("Appendage") && (mainObject.GetComponent<Appendage>().isSocketed || mainObject.GetComponent<Appendage>().socket.HasAppendage))
        {
            Debug.Log("This appendage is already attached to something");
            return;
        }

        // Ensure that the object is an appendage or a blob
        if (mainObject.CompareTag("Appendage") || mainObject.CompareTag("Blob"))
        {
            if (selected[0] == null)
            {
                selected[0] = mainObject;
            }
            else if (selected[1] == null && (selected[0] != mainObject))
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
                    MatchBlobs(selected[0].GetComponent<Blob>(), selected[1].GetComponent<Blob>());
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
                Array.Clear(selected,0,2);

            }
            
        }

    }

    /// <summary>
    /// Matches two blobs together
    /// </summary>
    /// <param name="other">Blob to be matched with</param>
    public void MatchBlobs(Blob blob1, Blob blob2)
    {
        var totalNumLegs = blob1.NumLegs + blob2.NumLegs;
        var totalNumArms = blob1.NumArms + blob2.NumArms;
        var totalNumLeftArms = blob1.numLeftArms + blob2.numLeftArms;
        var totalNumRightArms = blob1.numRightArms + blob2.numRightArms;
        var totalNumLeftLegs = blob1.numLeftLegs + blob2.numLeftLegs;
        var totalNumRightLegs = blob1.numRightLegs + blob2.numRightLegs;
        
        int points = 0;
        
        // Criteria for now
        // if blobs have nothing on them, - 5 points
        if (totalNumLegs == 0 && totalNumArms == 0)
        {
            points = -5;
        }
        else
        {
            points += totalNumArms;
            points += totalNumLegs;
            
            if (totalNumLeftArms == totalNumRightArms) points += totalNumArms;
            if (totalNumLeftLegs == totalNumRightLegs) points += totalNumLegs;
        }
        AddScore(points);
        
        // Play particles
        impulse.GenerateImpulse();
        Instantiate(matchParticleBurst,blob1.transform.position,quaternion.identity);
        Instantiate(matchParticleBurst,blob2.transform.position,quaternion.identity);
        
        Destroy(blob1.gameObject);
        Destroy(blob2.gameObject);
    }
}
