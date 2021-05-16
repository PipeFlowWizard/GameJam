using System;
using System.Collections;
using System.Collections.Generic;
using System.Security.Cryptography;
using TMPro;
using UnityEngine;

public class TextPopup : MonoBehaviour
{
    [SerializeField] private Transform textPopupPrefab;
    private TextMeshPro _textMesh;
    private float _disappearTimer =1;
    private Color _textColor;
    private float disappearSpeed = 4f;
    float moveYSpeed = 10f;


    public TextPopup Create(Vector2 position, string text)
    {
        Transform textPopupTransform = Instantiate(textPopupPrefab, position + new Vector2(UnityEngine.Random.Range(-2,2),UnityEngine.Random.Range(-2,2)), Quaternion.identity);
        TextPopup textPopup = textPopupTransform.GetComponent<TextPopup>();
        textPopup.Setup(text);
        return textPopup;
    }
    
    public TextPopup Create(Vector2 position, string text, Color color)
    {
        Transform textPopupTransform = Instantiate(textPopupPrefab, position + new Vector2(UnityEngine.Random.Range(-2,2),UnityEngine.Random.Range(-2,2)), Quaternion.identity);
        TextPopup textPopup = textPopupTransform.GetComponent<TextPopup>();
        textPopup.Setup(text);
        textPopup._textMesh.color = color;
        return textPopup;
    }
    
    private void Awake()
    {
        _textMesh = transform.GetComponent<TextMeshPro>();
        _textColor = new Color(1,1,1,1);
    }

    public void Setup(float points)
    {
     _textMesh.SetText(points.ToString());
     _textColor = _textMesh.color;
     _disappearTimer = 1;
    }

    public void Setup(string match)
    {
        _textMesh.SetText(match);
        _textColor = _textMesh.color;
        _disappearTimer = 1;
    }

    private void Update()
    {
        if(_textMesh != null)
        {
            transform.position += new Vector3(0, moveYSpeed) * Time.deltaTime;
            _disappearTimer -= Time.deltaTime;
            if (_disappearTimer < 0)
            {
                // Start disappearing
                _textColor.a -= disappearSpeed * Time.deltaTime;
                _textMesh.color = _textColor;
                if (_textColor.a < 0)
                {
                    Destroy(gameObject);
                }
            }
        }
    }
}
