
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
        socket = GetComponentInChildren<Socket>();
    }
    
    private void FixedUpdate()
    {
        if (parentJoint)
            rb.MovePosition(parentJoint.position);
    }

    public void AttachToOther(Transform tr)
    {
        transform.parent = tr;
        transform.localRotation = Quaternion.identity;
        transform.localPosition = Vector2.zero;
        parentJoint = tr;
    }
    public void AttachToMe(Appendage a)
    {
        socket.Attach(a);
        Invoke(nameof(DestroySelf), 5f);
    }

    private void DestroySelf()
    {
        Destroy(this.gameObject);
    }
}

