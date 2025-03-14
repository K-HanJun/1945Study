using UnityEngine;

public class Background : MonoBehaviour
{
    public float moveSpeed = 0.01f;
    
    private Material material;

    void Start()
    {
        material = GetComponent<Renderer>().material;
    }

    void Update()
    {
        float newoffsetY = material.mainTextureOffset.y + moveSpeed * Time.deltaTime;

        Vector2 newOffset = new Vector2(0, newoffsetY);

        material.mainTextureOffset = newOffset;
    }
}
