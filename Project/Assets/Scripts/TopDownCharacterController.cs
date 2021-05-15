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

    // Update is called once per frame
    void Update()
    {
        if (input["up"])
            Move(Vector2.up);
        if (input["down"])
            Move(Vector2.down);

        if (input["right"])
            Move(Vector2.right);
        if (input["left"])
            Move(Vector2.left);

        transform.rotation = Quaternion.LookRotation(Camera.main.ScreenToWorldPoint(
            Mouse.current.position.ReadValue()) - transform.position, Vector3.forward);
    }

    private void Move(Vector2 v)
    {
        rb.AddForce(v * moveForce);
    }
}
