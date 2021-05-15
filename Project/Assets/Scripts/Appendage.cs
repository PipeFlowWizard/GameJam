
using UnityEngine;

public class Appendage : MonoBehaviour
{
    public bool isSocketed = false;
    public Socket socket;
    public string Side;
    public string Type;
    public AppendageAsset asset;
    public GameObject appendage;
    public Rigidbody2D rb;

    private void Start()
    {
        rb = GetComponent<Rigidbody2D>();
        this.Side = asset.Side;
        this.tag = asset.Type;
        if(asset != null)
            ResetAppendage();
    }

    public void ResetAppendage()
    {
        appendage = Instantiate(asset.appendagePrefab, transform);
    }
}

