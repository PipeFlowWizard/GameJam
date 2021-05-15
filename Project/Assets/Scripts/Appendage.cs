
using UnityEngine;

public class Appendage : MonoBehaviour
{
    public bool isSocketed = false;
    public Socket socket;
    public string Side;
    public string Type;
    public AppendageAsset asset;
    public GameObject appendage;

    private void Start()
    {
        this.Side = asset.Side;
        this.tag = asset.Type;
        if(asset != null)
            ResetAppendage();
    }

    public void ResetAppendage()
    {
        appendage = Instantiate(asset.AppendagePrefab, transform);
    }
}

