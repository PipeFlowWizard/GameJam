using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ArrowBehavior : MonoBehaviour
{
    public float speed;

    private Rigidbody2D rb;

    private ParticleSystem onHitParticles;

    private bool ignoreTrigger;

    // Start is called before the first frame update
    void Start()
    {
        rb = GetComponent<Rigidbody2D>();
        rb.velocity = transform.up * speed;

        onHitParticles = GetComponentInChildren<ParticleSystem>();
        ignoreTrigger = false;
    }

    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (ignoreTrigger)
            return;
        ignoreTrigger = true;

        rb.constraints = RigidbodyConstraints2D.FreezeAll;
        transform.parent = collision.transform;
        // selector.Select(collision.GetComponent<Shootable>());
        Debug.Log("Arrow hit GameObject: " + collision.gameObject.transform.root.gameObject + " With tag: " + collision.transform.root.gameObject.tag);
        GameManager.AssignSelection(collision.gameObject);
        
        
        Destroy(rb);
        Destroy(GetComponent<BoxCollider2D>());
        Destroy(this);

        onHitParticles.Play();
    }
}
