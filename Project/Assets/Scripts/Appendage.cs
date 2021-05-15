
using UnityEngine;

public class Appendage : MonoBehaviour
{
    public bool isSocketed = false;
    public Socket socket;
    public string Side;
    public string Type;
    public Rigidbody2D rb;

    private Transform parentJoint;

    private void Start()
    {
        rb = GetComponent<Rigidbody2D>();
        
    }

    private void FixedUpdate()
    {
        if (parentJoint)
            rb.MovePosition(parentJoint.position);
    }

    public void Attach(Transform tr)
    {
        transform.parent = tr;
        transform.localPosition = Vector2.zero;
        parentJoint = tr;
    }
}

