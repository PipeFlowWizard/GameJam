using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.InputSystem;

public class TopDownCharacterController : MonoBehaviour
{
    public float moveForce, turnSpeed;

    /// <summary>
    /// A script that i use/wrote to manage input,
    /// feel free to remove if you want to use inputsystem actions or a hardcoded solution
    /// </summary>
    private ControlKey input;
    private Rigidbody2D rb;
    // Start is called before the first frame update
    void Start()
    {
        rb = GetComponent<Rigidbody2D>();
        input = GetComponent<ControlKey>();
    }

    private void FixedUpdate()
    {
        if (input["up"])
            Move(Vector2.up);
        if (input["down"])
            Move(Vector2.down);

        if (input["right"])
            Move(Vector2.right);
        if (input["left"])
            Move(Vector2.left);
    }

    // Update is called once per frame
    void Update()
    {
        if (PauseMenu.paused)
            return;
        Vector2 mousePos = Camera.main.ScreenToWorldPoint(Mouse.current.position.ReadValue());
        float angle = Mathf.Atan2(mousePos.y - transform.position.y, mousePos.x - transform.position.x);
        angle *= (180 / Mathf.PI);
        transform.rotation = Quaternion.Euler(0, 0, angle - 90);
    }

    private void Move(Vector2 v)
    {
        rb.AddForce(v * moveForce);
    }
}
