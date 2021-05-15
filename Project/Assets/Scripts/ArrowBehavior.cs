using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ArrowBehavior : MonoBehaviour
{
    public float speed;

    private Rigidbody2D rb;

    // Start is called before the first frame update
    void Start()
    {
        rb = GetComponent<Rigidbody2D>();
        rb.velocity = transform.up * speed;
    }

    private void OnTriggerEnter2D(Collider2D collision)
    {
        rb.constraints = RigidbodyConstraints2D.FreezeAll;
        transform.parent = collision.transform;
        // selector.Select(collision.GetComponent<Shootable>());
        GameManager.AssignSelection(collision.gameObject);
        
        
        Destroy(rb);
        Destroy(GetComponent<BoxCollider2D>());
        Destroy(this);
        
    }
}
